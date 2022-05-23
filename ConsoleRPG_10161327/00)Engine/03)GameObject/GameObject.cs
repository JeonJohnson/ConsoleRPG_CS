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
		GameObject newObj = new GameObject(desc);

		//만들어야함.


		GameObjectManager.Instance.AddGameObject(newObj);

		return newObj;
	}

	public static GameObject Instantiate(Structs.GameObjectDesc desc)
	{
		GameObject newObj = new GameObject(desc);

		GameObjectManager.Instance.AddGameObject(newObj);

		return newObj;
	}

	public static GameObject Instantiate()
	{
		GameObject newObj = new GameObject();


		GameObjectManager.Instance.AddGameObject(newObj);
		return newObj;
	}

	public static void Destroy(GameObject gameObject)
	{
		gameObject.isDead = true;
	}

	public static void DontDestroy(GameObject gameObject)
	{
		gameObject.IsDontDestroyed = true;
	}

	string name;
	public string Name 
	{
		get { return name; }
		set { name = value; }
	}

	int tag;
	public int Tag
	{
		get { return tag; }
		set { tag = value; }
	}
	
	int layer;
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

	bool isActive = true;
	public bool IsActive
	{
		get { return isActive; }
		set { isActive = value; }
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
		get { return IsDontDestroyed; }
		set { isDontDestroyed = value; }
	}

	public Transform transform = null;

	//Renderer renderer = null;

	public T AddComponent<T>(T component = null) where T : Component, new()
	{
		if (this.GetComponent<T>() != null)
		{
			return null;
		}

		string componentName = typeof(T).Name;

		T tempComponent = component;

		if (tempComponent == null)
		{
			tempComponent = new T();
		}
		tempComponent.gameObject = this;

		KeyValuePair<string, Component> componentPair = new KeyValuePair<string, Component>(componentName,tempComponent);

		newComponents.Add(componentPair);

		return component;
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
		this.AddComponent<Transform>();
	}

	public void Update()
	{
		//1. new Component 애들 Component로 넣어주고 초기화 돌리기
		MergeNewComponents();

		foreach (KeyValuePair<string, Component> com in components)
		{
			com.Value.Update();
		}

	}
	public void Release()
	{
	}

}