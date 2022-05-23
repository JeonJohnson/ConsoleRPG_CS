using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums;

public abstract class Scene : Cycle
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
        scene.sceneNum = (int)sceneNum;

        return scene;
    }


    protected string sceneName;

    public string SceneName
    {
        get { return sceneName; }
        set { sceneName = value; }
    }

    protected int sceneNum;
    public int SceneNum
    {
        get { return sceneNum; }
        set { sceneNum = value; }
    }

    public abstract void Initailize();


    public void Update()
    {
        GameObjectManager.Instance.Update();
    }

    public void Release()
    {
    }
}
