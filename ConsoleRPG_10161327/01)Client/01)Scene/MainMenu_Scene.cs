using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MainMenu_Scene : Scene
{
	public override void Initailize()
	{
		{
			GameObject sceneNameObj  = GameObjectManager.Instance.FindGameObjectByName("SceneName");
			sceneNameObj.GetRenderer<Renderer>().RenderStr = "Town Scene";
		}

		{
			GameObject notice = GameObjectManager.Instance.FindGameObjectByName("Notice");
			//notice.GetRenderer<Renderer>().RenderStr = "Plz Select Next Map";
			notice.GetRenderer<Renderer>().RenderStr = "Plz Select Next Map";

			GameObject temp = GameObject.Instantiate();
			temp.AddRenderer<LineRenderer>();
			temp.transform.position.x = 3;
		} 

		{
			if (GameObjectManager.Instance.FindGameObjectByName("PlayerStatusViewer") == null)
			{
				GameObject statusViewer = GameObject.Instantiate("PlayerStatusViewer");
				statusViewer.transform.position.x = 4;
				Player tempScript = GameObjectManager.Instance.FindGameObjectByName("Player").GetComponent<Player>();
				statusViewer.AddComponent<StatusViewer>().SetUnit = tempScript;
				statusViewer.DontDestroy();
			}
			else 
			{
				GameObjectManager.Instance.FindGameObjectByName("PlayerStatusViewer").SetActive(true);
			}

			GameObject temp = GameObject.Instantiate();
			temp.AddRenderer<LineRenderer>();
			temp.transform.position.x = 5;

		}


		{
			GameObject menuButton = GameObject.Instantiate();
			menuButton.transform.position.x = 6;
			menuButton.AddRenderer<Renderer>().RenderStr = "1. Dungeon\n2. Shop\n3. Inventory";
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
			//inventoryObj.SetActive(true);

			//GameObject temp2 = GameObject.Instantiate();
			//temp2.AddRenderer<LineRenderer>();
			//temp2.transform.position.x = 8;
		}


	}

}
