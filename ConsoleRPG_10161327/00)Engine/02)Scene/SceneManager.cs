using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SceneManager : Manager<SceneManager> , Cycle
{

	public  delegate void SceneLoadEvent(Enums.eScene sceneEnum);
	public SceneLoadEvent sceneLoadEvent = null;


	bool isSceneChange = false;

	Scene preScene = null;
	public Scene PreScene
	{
		get { return preScene; }
	}

	Scene curScene = null;
	public Scene CurScene
	{
		get
		{ return curScene; }
	}
	Scene nextScene = null;

	//Dictionary<string, Scene> sceneDictionary = new Dictionary<string, Scene>();
	//List<Scene> sceneList = new List<Scene>();
    SortedDictionary<int, Scene> sceneDictionary = new SortedDictionary<int, Scene>();

	 
    /// <summary>
    /// 현재씬의 Cycle을 돌려줌.
    /// 각 씬은 그 씬의 GameObject들의 Cycle을 돌려줄꺼임.
    /// =>GameObjectManager이 필요할까? 아니면 SceneManager에서 관리할ㄲㅏ?
    /// =>GameObjectManager ㄱㄱㄱㄱ 
    /// </summary>
    /// 

    public void InsertScene(params Scene[] scenes)
    {
		foreach (Scene scene in scenes)
		{
			sceneDictionary.Add((int)scene.SceneNum, scene);
		}

		//Dictionary<int, Scene> temp = sceneDictionary.OrderBy(x => x.Key).ToDictionary(x=>x.Key, x=>x.Value); 
    }
	public Scene SetFirstScene(Enums.eScene sceneNum)
	{ 
		foreach(KeyValuePair<int,Scene> scenePair in sceneDictionary)
		{
			if (scenePair.Key == (int)sceneNum)
			{
				if (curScene == null)
				{
					curScene = scenePair.Value;
				}
				else
				{
					return null;	
				}

				return scenePair.Value;
			}
		}

		return null;
	}

	public Scene SetFirstScene<T>() where T : Scene
	{
		foreach (KeyValuePair<int, Scene> scenePair in sceneDictionary)
		{
			if (scenePair.Value.SceneName == typeof(T).Name)
			{
				if (curScene == null)
				{
					scenePair.Value.Initailize();
					curScene = scenePair.Value;

				}
				else
				{
					return null;
				}
				return scenePair.Value;
			}
		}
		return null;
	}

	public Scene FindSceneByName(string _sceneName)
	{
		foreach (KeyValuePair<int, Scene> scenePair in sceneDictionary)
		{
			if (scenePair.Value.SceneName == _sceneName)
			{
				return scenePair.Value;
			}
		}
		return null;
	}


    public void SceneChange(string sceneName)
	{
		isSceneChange = true;

		nextScene = FindSceneByName(sceneName);
	}

	public void SceneChange(Enums.eScene scene)
	{
		isSceneChange = true;

		nextScene = sceneDictionary[(int)scene];
	}

	public void NextSceneChange()
	{
		isSceneChange = true;
		int num = (int)curScene.SceneNum;
		++num;
		SceneChange((Enums.eScene)num);
	}

	public void SceneChangeCheck()
	{
		if (!isSceneChange)
		{
			return;
		}

		curScene.Release();
		GameObjectManager.Instance.ReleaseScene();
		//Dont Destoryed 된 게임오브젝트 넘겨주기
		RenderManager.Instance.ReleaseScene();
			

		nextScene.Initailize();

		preScene = curScene;
		curScene = nextScene;
		nextScene = null;

		sceneLoadEvent(curScene.SceneNum);

		isSceneChange = false;
	}

	public void Initailize()
	{
		
	}


	public void Update()
	{
		GameObjectManager.Instance.Update();
	}

	public void ReadyRender()
	{
		GameObjectManager.Instance.ReadyRender();
	}

	public void Render()
	{
		RenderManager.Instance.Render();
	}


	public void Release()
	{
		//GameObjectManager에서 오브젝트들 지워주기
		InputManager.Instance.Release();
		GameObjectManager.Instance.Release();
		RenderManager.Instance.Release();
	}

}
