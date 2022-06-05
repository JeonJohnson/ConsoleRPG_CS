using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

sealed public class GameObject : Cycle
{
	public GameObject(Structs.GameObjectDesc desc)
	{
		name = desc.name;
		tag = (int)desc.tag;
		layer = (int)desc.layer;


		Initailize();
		//Awake();
	}

	public GameObject()
	{
		Initailize();
	}

	~GameObject()
	{ }

	public static GameObject Instantiate(Structs.GameObjectDesc desc, params Component[] components)
	{
		//폐기
		GameObject newObj = /*new GameObject(desc)*/ null;

		//GameObjectManager.Instance.AddGameObject(newObj);

		return newObj;
	}

	public static GameObject Instantiate(Structs.GameObjectDesc desc)
	{
		GameObject newObj = new GameObject(desc);

		GameObjectManager.Instance.AddGameObject(newObj);

		return newObj;
	}

	public static GameObject Instantiate(string name)
	{
		GameObject newObj = null;

		newObj = GameObjectManager.Instance.FindGameObjectByName(name);

		if (newObj != null)
		{
			return newObj;
		}

		newObj = new GameObject();



		GameObjectManager.Instance.AddGameObject(newObj);
		newObj.Name = name;

		return newObj;
	}

	public static GameObject Instantiate(int tag)
	{

		GameObject newObj = null;

		newObj = GameObjectManager.Instance.FindGameObjectByTag(tag);

		if (newObj != null)
		{
			return newObj;
		}

		newObj = new GameObject();

		GameObjectManager.Instance.AddGameObject(newObj);
		newObj.tag = tag;

		return newObj;
	}

	public static GameObject Instantiate(string name, int tag)
	{
		GameObject newObj = new GameObject();

		GameObjectManager.Instance.AddGameObject(newObj);
		newObj.Name = name;
		newObj.Tag = tag;

		return newObj;
	}

	public static GameObject Instantiate()
	{
		GameObject newObj = new GameObject();


		GameObjectManager.Instance.AddGameObject(newObj);
		return newObj;
	}

	//public static GameObject CopyObject(GameObject prefab)
	//{ 
	//}

	public static void Destroy(GameObject gameObject)
	{
		gameObject.isDead = true;
	}

	public void Destory()
	{
		this.isDead = true;
	}


	public static void DontDestroy(GameObject gameObject)
	{
		gameObject.IsDontDestroyed = true;
	}
	public void DontDestroy()
	{
		this.IsDontDestroyed = true;
	}


	string name;
	public string Name 
	{
		get { return name; }
		set { name = value; }
	}

	int tag = (int)Enums.Tags.End;
	public int Tag
	{
		get { return tag; }
		set { tag = value; }
	}

	int layer = (int)Enums.Layer.End;
    public int Layer
    {
        get { return layer; }
        set { Layer = (int)value; }
    }

    //<componet 클래스 이름, ㄹㅇ 찐 객체>
    List<KeyValuePair<string, Component>> components =  new List<KeyValuePair<string, Component>>();
	List<KeyValuePair<string, Component>> newComponents = new List<KeyValuePair<string, Component>>();
	//두개 따로 놔둔 이유 : 중간에 컴포넌트가 추가 되더라도
	//다 같은 실행 시기 맞춰주기 위해서.

	List<KeyValuePair<string, Renderer>> renderers = new List<KeyValuePair<string, Renderer>>();


	bool isActive = true;
	public bool IsActive
	{
		get { return isActive; }
		set { isActive = value; }
	}

	public void SetActive(bool _active)
	{
		isActive = _active;
	}

	bool isDead = false;
	public bool IsDead
	{
		get { return isDead; }
		set { isDead = value; }
	}

	bool isDontDestroyed = false;
	public bool IsDontDestroyed
	{
		get { return isDontDestroyed; }
		set { isDontDestroyed = value; }
	} 

	public Transform transform = null;

	//Renderer renderer = null;

	public Renderer AddRenderer(Renderer renderer)
	{ 
		renderer.gameObject = this;
		renderer.Initailize();
		string rendererName = typeof(Renderer).Name;

		KeyValuePair<string, Renderer> rendererPair = new KeyValuePair<string, Renderer>(rendererName, renderer);
		renderers.Add(rendererPair);

		return renderer;
	}

	public T AddRenderer<T>(T renderer = null) where T : Renderer, new()
	{
		if (renderer == null)
		{
			T tempRenderer = new T();

			tempRenderer.gameObject = this;
			tempRenderer.Initailize();

			string rendererName = typeof(T).Name;
			KeyValuePair<string, Renderer> rendererPair = new KeyValuePair<string, Renderer>(rendererName, tempRenderer);
			renderers.Add(rendererPair);

			return tempRenderer;
		}
		else
		{
			renderer.gameObject = this;
			renderer.Initailize();


			string rendererName = typeof(T).Name;
			KeyValuePair<string, Renderer> rendererPair = new KeyValuePair<string, Renderer>(rendererName, renderer);
			renderers.Add(rendererPair);

			return renderer;
		}	
	}

	public T GetRenderer<T>() where T : class
	{
		string rendererName = typeof(T).Name;

		//foreach (KeyValuePair<string, Renderer> component in components)
		//{
		//	if (componentName == component.Key)
		//	{
		//		return component.Value as T;
		//	}
		//}

		KeyValuePair<string, Renderer>  renderPair = renderers.Find(renderer => renderer.Key == rendererName);
		
		return renderPair.Value as T;
	}

	public T AddComponent<T>(T component = null) where T : Component, new()
	{
		if (this.GetComponent<T>() != null)
		{
			return null;
		}

		string componentName = typeof(T).Name;


		//if (componentName == "Renderer")
		//{
		//	T tempRenderer = component;

		//	if (tempRenderer == null)
		//	{
		//		tempRenderer = new T();
		//	}
		//	tempRenderer.gameObject = this;

		//	renderers.Add(tempRenderer);

		//}
		//else 
		//{
			T tempComponent = component;

			if (tempComponent == null)
			{
				tempComponent = new T();
				
			}
			tempComponent.gameObject = this;
			tempComponent.Initailize(); 

			KeyValuePair<string, Component> componentPair = new KeyValuePair<string, Component>(componentName, tempComponent);

			newComponents.Add(componentPair);


		return tempComponent;
	}

	public T GetComponent<T>() where T : class
	{
		string componentName = typeof(T).Name;

		foreach(KeyValuePair<string,Component> component in components)
		{
			if (componentName == component.Key)
			{
				return component.Value as T;
			}
		}

		foreach (KeyValuePair<string, Component> newComponent in newComponents)
		{
			if (componentName == newComponent.Key)
			{
				return newComponent.Value as T;
			}
			
		}

		return null;
	}

	private void MergeNewComponents()
	{
		if (newComponents.Count == 0)
		{
			return;
		}

		foreach (KeyValuePair<string, Component> temp in newComponents)
		{
			components.Add(temp);
		}

		newComponents.Clear();

	}

	public void Initailize()
	{
		//components = new List<KeyValuePair<string, Component>>();
		//newComponents = new List<KeyValuePair<string, Component>>();

		//transform = new Transform();
		transform = this.AddComponent<Transform>();
		MergeNewComponents();
	}

	public void Update()
	{
		//1. new Component 애들 Component로 넣어주고 초기화 돌리기
		MergeNewComponents();

		foreach (KeyValuePair<string, Component> com in components)
		{
			if (com.Value.Enabled)
			{ com.Value.Update(); }
			
		}
	}

	public void ReadyRender()
	{
		foreach (KeyValuePair<string, Renderer> renderer  in renderers)
		{
			renderer.Value.ReadyRender();
		}
	}

	public void Release()
	{
	}

}