using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums;

public class Scene : Cycle
{
    public Scene()
    {

    }

    ~Scene()
    { }

    public static Scene Instantiate<T>(Enums.eScene sceneNum) where T : Scene, new()
    {
        Scene scene = new T();
        scene.sceneName = typeof(T).Name;
        scene.sceneNum = sceneNum;

        return scene;
    }


    string sceneName;
    public string SceneName
    {
        get { return sceneName; }
        set { sceneName = value; }
    }

    eScene sceneNum;
    public eScene SceneNum
    {
        get { return sceneNum; }
        set { sceneNum = value; }
    }


        

    public void Awake()
    {
    }
    public void Start()
    {
        GameObjectManager.Instance.Start();
    }
    public void Update()
    {
        GameObjectManager.Instance.Update();
    }

    public void Render()
    {
    }

    public void Release()
    {
    }
}
