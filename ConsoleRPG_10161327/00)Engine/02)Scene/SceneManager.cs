using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SceneManager : Manager<SceneManager>
{


	bool isSceneChange = false;

	Scene preScene = null;
	Scene curScene = null;
	Scene nextScene = null;

	//Dictionary<string, Scene> sceneDictionary = new Dictionary<string, Scene>();
	//List<Scene> sceneList = new List<Scene>();
    Dictionary<int, Scene> sceneDictionary = new Dictionary<int, Scene>();

	 
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

	public Scene SetFirstScene<T>(T scene) where T : Scene
	{
		foreach (KeyValuePair<int, Scene> scenePair in sceneDictionary)
		{
			if (scenePair.Value.SceneName == typeof(T).Name)
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
		int num = (int)curScene.SceneNum;

		++num;

		SceneChange((Enums.eScene)num);
	}


	public void Awake()
	{
	}

	public void Start()
	{ 
		

	}

	public void Update()
	{
		SceneChangeCheck();

		curScene.Update();
	}

	public void SceneChangeCheck()
	{
		if (!isSceneChange)
		{
			return;
		}

		curScene.Release();
		//GameObjectManager에서 오브젝트들 지워주기
		//Dont Destoryed 된 게임오브젝트 넘겨주기
		nextScene.Awake();

		preScene = curScene;
		curScene = nextScene;

		isSceneChange = false;
	}
	public void Release()
	{

	}

}
