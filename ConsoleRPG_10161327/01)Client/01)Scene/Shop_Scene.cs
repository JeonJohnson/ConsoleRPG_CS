using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Shop_Scene : Scene
{
    public override void Initailize()
    {
        {
            GameObject sceneName = GameObjectManager.Instance.FindGameObjectByName("SceneName");
            sceneName.GetRenderer<Renderer>().RenderStr = "Shop";
        }

        {
            GameObject notice = GameObject.Instantiate("Notice");
            notice.transform.position.x = 2;
            notice.AddRenderer<Renderer>().RenderStr = "Select Item Kind";
            notice.DontDestroy();

            GameObject temp = GameObject.Instantiate();
            temp.AddRenderer<LineRenderer>();
            temp.transform.position.x = 3;
        }

        {
            GameObject temp2 = GameObject.Instantiate();
            temp2.AddRenderer<LineRenderer>();
            temp2.transform.position.x = 5;
        }

        { 
            
        
        }
    }

}
