using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MainMenu_Scene : Scene
{
	GameObject	sceneNameObj = null;
	GameObject	notice = null;


	public override void Initailize()
	{
		{
			sceneNameObj = GameObjectManager.Instance.FindGameObjectByName("SceneName");
			sceneNameObj.GetRenderer<Renderer>().RenderStr = "Main Menu Scene";
		}

		{
			notice = GameObjectManager.Instance.FindGameObjectByName("Notice");
			notice.GetRenderer<Renderer>().RenderStr = "Plz Select Next Map";

			GameObject temp = GameObject.Instantiate();
			temp.AddRenderer<LineRenderer>();
			temp.transform.position.x = 3;
		}

		{
			GameObject statusViewer = GameObject.Instantiate("PlayerStatusViewer");
			statusViewer.transform.position.x = 4;
			Player tempScript = GameObjectManager.Instance.FindGameObjectByName("Player").GetComponent<Player>();
			statusViewer.AddComponent<StatusViewer>().SetUnit = tempScript;
			statusViewer.DontDestroy();

			GameObject temp = GameObject.Instantiate();
			temp.AddRenderer<LineRenderer>();
			temp.transform.position.x = 5;
		}


		{
			GameObject menuButton = GameObject.Instantiate();
			menuButton.transform.position.x = 6;
			menuButton.AddRenderer<Renderer>().RenderStr = "1. Dungeon\n2. Shop\n3. Inventory";



		}

	}

}
