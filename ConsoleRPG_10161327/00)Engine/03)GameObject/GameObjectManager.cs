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
