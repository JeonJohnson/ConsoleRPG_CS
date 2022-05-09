using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GameObjectManager : Manager<GameObjectManager>, Cycle
{
	public GameObjectManager()
	{
		Awake();
	}

	 ~GameObjectManager()
	{ }

	private List<GameObject> gameObjectList;
	private List<GameObject> newGameObjectList;



	public void AddGameObject(GameObject gameObject)
	{
		gameObjectList.Add(gameObject);
	}

	//public GameObject FindGameObjectByTag(string tag)
	//{ 
			
	//}

	//public GameObject FindGameObjectByName(string name)
	//{ 
	
	//}



	public void Awake()
	{
		gameObjectList = new List<GameObject>();
		newGameObjectList = new List<GameObject>();
	}

	public void Start()
	{

	}
	public void Update()
	{
		//new GameObject 기존 List에 추가해주기


		foreach (GameObject obj in gameObjectList)
		{
			obj.Update();
		}

	}

	public void Render()
	{
		foreach (GameObject obj in gameObjectList)
		{
			obj.Render();
		}
	}

	public void Release()
	{
	}
}
