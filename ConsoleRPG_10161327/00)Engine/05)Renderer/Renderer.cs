using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Renderer : Component
{
    //public Renderer(GameObject _gameObject)
    //{
    //    gameObject = _gameObject;
    //}

    public Renderer()
    { }


    ~Renderer()
    { }
    //Console RPG니까 string형 하나 가지고 있고
    //그거 Console Write 해주기

    //천천히 적거나 한글자씩 적는 효과는 Component로 만들어서 거기서 렌더러 참조해서 ㄱㄱ?  
    //아니면 Renderer자체의 함수나 효과로?

    //public GameObject gameObject = null;
    
    public Transform transform = null;

    //protected int renderNum = 0; //실제 화면에 출력 될 숫자

    //private char[] t


    public int renderQueueIndex;

    private string renderStr;
    public string RenderStr
    { 
        get
		{
            return renderStr;
		}
        set { renderStr = value; }
    }

    public static Renderer Instantiate()
    {
        Renderer newRenderer = new Renderer();
        //GameObjectManager.Instance.AddGameObject(newObj);
        
        return newRenderer;
    }

    public override void Initailize()
    {
        if (gameObject != null)
        {
            transform = gameObject.GetComponent<Transform>();
        }
    }

	public override void Update()
	{
	}
	public override void ReadyRender()
	{
       
        RenderManager.Instance.InsertRenderList(this,renderQueueIndex);
	}

    public void Render()
    {
        //Console.SetCursorPosition(transform.position.x, transform.position.y);
        //Console.Write(renderStr);
    }


    public override void Release()
    { }

}