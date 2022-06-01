using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Component : Cycle
{
    ~Component()
    {
        Release();
    }

    public GameObject gameObject = null;

    public virtual void Initailize()
    {
        if (SceneManager.Instance.sceneLoadEvent == null)
        {
            SceneManager.Instance.sceneLoadEvent = new SceneManager.SceneLoadEvent(SceneLoad);
        }
        else 
        {
            SceneManager.Instance.sceneLoadEvent += SceneLoad;
        }
    }

	public abstract void Update();

    public virtual void ReadyRender()
    {

    }
    //public virtual void Render()
    //{
    //    //원래는 렌더러 컴포넌트를 가진 애만 출력 가능한디 
    //    //어차피 콘솔알피지는 딱히 그럴 필요 업을듯.
    //    //맵 렌더러 하나 만들어야하나?
    //}
    public virtual void Release()
    {
        SceneManager.Instance.sceneLoadEvent -= SceneLoad;
    }


    public virtual void SceneLoad(Enums.eScene sceneNum)
    { 
    


    }




}
