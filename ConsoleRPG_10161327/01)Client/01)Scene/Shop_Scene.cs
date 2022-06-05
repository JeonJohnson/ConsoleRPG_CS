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
            GameObject notice = GameObjectManager.Instance.FindGameObjectByName("Notice");
            notice.GetRenderer<Renderer>().RenderStr = "Select Menu";

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
            GameObject shopObj = GameObjectManager.Instance.FindGameObjectByName("Shop");

            if (shopObj == null)
            {
                shopObj = GameObject.Instantiate("Shop");
                shopObj.AddComponent<Shop>();
                shopObj.transform.position.x = 6;
                shopObj.DontDestroy();
            }
            
        }

        {
            GameObject returnMainMenu = GameObject.Instantiate("Return");
            returnMainMenu.transform.position.x = 27;
            returnMainMenu.AddRenderer<Renderer>().RenderStr = "8. Return MainMenu";

            GameObject temp2 = GameObject.Instantiate();
            temp2.AddRenderer<LineRenderer>();
            temp2.transform.position.x = 26;
        }
    }

}
