using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GameObject : Cycle
{
	public GameObject(Structs.GameObjectDesc desc)
	{
		name = desc.name;
		tag = (int)desc.tag;
		layer = (int)desc.layer;

		Awake();
	}

	public GameObject()
	{
		Awake();
	}

	~GameObject()
	{ }

	public static GameObject Instantiate(Structs.GameObjectDesc desc, params Component[] components)
	{
		GameObject newObj = new GameObject(desc);


		return newObj;
	}
	public static void Destory(GameObject gameObject)
	{

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


	public T AddComponent<T>(T component) where T : Component
	{
		string componentName = typeof(T).Name;

		if (this.GetComponent<T>() != null)
		{
			return null;
		}
		KeyValuePair<string, Component> tempComponent = new KeyValuePair<string, Component>(componentName,component);

		newComponents.Add(tempComponent);

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

	public void NewComponetsInsert()
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

	public void Awake()
	{
		//components = new List<KeyValuePair<string, Component>>();
		//newComponents = new List<KeyValuePair<string, Component>>();
	}

	public void Start()
	{
	}

	public void Update()
	{
		//1. new Component 애들 Component로 넣어주고 초기화 돌리기
		NewComponetsInsert();

		foreach (KeyValuePair<string, Component> com in components)
		{
			com.Value.Update();
		}

	}

	public void Render()
	{
	}
	public void Release()
	{
	}

}
