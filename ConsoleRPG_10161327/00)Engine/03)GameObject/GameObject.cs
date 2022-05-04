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
	int tag;
	int layer;

	List<KeyValuePair<string, Component>> components;
	List<KeyValuePair<string, Component>> newComponents;
	//두개 따로 놔둔 이유 : 중간에 컴포넌트가 추가 되더라도
	//다 같은 실행 시기 맞춰주기 위해서.


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

	public void Awake()
	{
	}

	public void Start()
	{
	}

	public void Update()
	{
	}

	public void Render()
	{
	}
	public void Release()
	{
	}

}
