using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Renderer 
{

    public Renderer(GameObject _gameObject)
    {
        gameObject = _gameObject;
    }

    ~Renderer()
    { }
    //Console RPG니까 string형 하나 가지고 있고
    //그거 Console Write 해주기

    //천천히 적거나 한글자씩 적는 효과는 Component로 만들어서 거기서 렌더러 참조해서 ㄱㄱ?  
    //아니면 Renderer자체의 함수나 효과로?

    private GameObject gameObject = null;

    private Transform transform = null;

    private int renderNum = 0; //실제 화면에 출력 될 숫자


    public void Awake()
    {
        if (gameObject != null)
        {
            transform = gameObject.GetComponent<Transform>();
        }
    }

    public void Render()
    { 
            
    
    
    }


    public void Release()
    { 
    
    }
    

}