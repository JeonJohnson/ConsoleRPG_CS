using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GameObjectManager : Manager<GameObjectManager>, Cycle
{
	//public GameObjectManager()
	//{
	//	Awake();
	//}

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

	private void MergeNewGameObjects()
	{
		if (newGameObjectList.Count == 0)
		{
			return;
		}

		foreach (GameObject obj in newGameObjectList)
		{
			gameObjectList.Add(obj);
		}

		newGameObjectList.Clear();
	}

	public void Delete_DeadGameObject()
	{

		MergeNewGameObjects();

		//C++에서 STL 순회하면서 삭제했을 때 있던 문제처럼
		//C#의 List도 foreach로 순회하면서 삭제하면 exception 뜸.
		//근데 이터레이터가 없으니 
		//
		//1. 지워할 애들 따로 모아두고 그 모아둔 애들 돌면서
		//remove해주면댐!

		//2. 아니면 for문으로 마지막 인덱스부터 돌아가면서 지우면 댐

		//3. foreach에서 .ToList()한(복사한 리스트)리스트 돌리면서 실제 리스트에서 Remove 해주면 됨.

		////1번
		//List<GameObject> deleteObjects = new List<GameObject>();
		//foreach (GameObject obj in gameObjectList)
		//{
		//	if (obj.IsDead)
		//	{
		//		deleteObjects.Add(obj);
		//	}
		//}
		//foreach (GameObject deleteObj in deleteObjects)
		//{
		//	gameObjectList.Remove(deleteObj);
		//}
		////외부적으로 봐도 for문 최소 2번 이상 돌림
		////근데 Remove도 있으니까 더 드는거디

		//2번 방법 
		for (int i = gameObjectList.Count - 1; i >= 0; --i)
		{
			if (gameObjectList[i].IsDead)
			{
				gameObjectList[i] = null;
				gameObjectList.RemoveAt(i);
				//오류안뜰려나?
			}
		}
		//리스트 배열 길이 만큼 한번 돌리고 
		//remove도 한번만

		////3번 방법
		//foreach (GameObject deleteObj in gameObjectList.ToList())
		//{
		//	if (deleteObj.IsDead)
		//	{
		//		gameObjectList.Remove(deleteObj);
		//	}
		//}
		////리스트 자체가 한번 복사되는거니까 비용적인 측면에서 싸진 않을듯.


	}

	public void Release_Scene()
	{
		MergeNewGameObjects();

		for (int i = gameObjectList.Count - 1; i >= 0; --i)
		{
			if (!gameObjectList[i].IsDontDestroyed)
			{
				gameObjectList[i] = null;
				gameObjectList.RemoveAt(i);
			}
		}
	}

		
	public void Initailize()
	{
		gameObjectList = new List<GameObject>();
		newGameObjectList = new List<GameObject>();
	}

	public void Update()
	{
		//new GameObject 기존 List에 추가해주기
		MergeNewGameObjects();
		Delete_DeadGameObject();

		foreach (GameObject obj in gameObjectList)
		{
			obj.Update();
		}

	}


	public void Release()
	{
	}
}
