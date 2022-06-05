using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Inventory_Scene : Scene
{

    public override void Initailize()
    {
		{
			GameObject sceneNameObj = GameObjectManager.Instance.FindGameObjectByName("SceneName");
			sceneNameObj.GetRenderer<Renderer>().RenderStr = "Inventory";
		}

		{
			GameObject notice = GameObjectManager.Instance.FindGameObjectByName("Notice");
			notice.GetRenderer<Renderer>().RenderStr = "if u were Input item number that equipped, that unequip.";

			GameObject temp = GameObject.Instantiate();
			temp.AddRenderer<LineRenderer>();
			temp.transform.position.x = 3;

			GameObject temp2 = GameObject.Instantiate();
			temp2.AddRenderer<LineRenderer>();
			temp2.transform.position.x = 5;
		}

		{
			GameObject inventoryObj = GameObjectManager.Instance.FindGameObjectByName("Inventory");

			if (inventoryObj == null)
			{
				inventoryObj = GameObject.Instantiate("Inventory");
				inventoryObj.transform.position.x = 6;
				inventoryObj.AddComponent<Inventory>();
				
				inventoryObj.DontDestroy();

				//Renderer inventoryRenderer = inventoryObj.AddRenderer<Renderer>();
			}
			inventoryObj.SetActive(true);

			//GameObject temp2 = GameObject.Instantiate();
			//temp2.AddRenderer<LineRenderer>();
			//temp2.transform.position.x = 8;
		}
		
		{
			GameObject returnMainMenu = GameObject.Instantiate();
			returnMainMenu.transform.position.x = 27;
			returnMainMenu.AddRenderer<Renderer>().RenderStr = "8. Return MainMenu";

			GameObject temp2 = GameObject.Instantiate();
			temp2.AddRenderer<LineRenderer>();
			temp2.transform.position.x = 26;

		}
	}

}
