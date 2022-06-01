using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class DungeonSelect_Scene : Scene
{
	GameObject sceneNameObj = null;
	GameObject notice = null;

	public override void Initailize()
    {
		{
			sceneNameObj = GameObjectManager.Instance.FindGameObjectByName("SceneName");
			sceneNameObj.GetRenderer<Renderer>().RenderStr = "Dungeon Select Scene";
		}

		{
			notice = GameObjectManager.Instance.FindGameObjectByName("Notice");
			notice.GetRenderer<Renderer>().RenderStr = "Plz Select Monster";

			GameObject temp = GameObject.Instantiate();
			temp.AddRenderer<LineRenderer>();
			temp.transform.position.x = 3;

			GameObject temp2 = GameObject.Instantiate();
			temp2.AddRenderer<LineRenderer>();
			temp2.transform.position.x = 5;
		}

		{
			GameObject dungeonButton = GameObject.Instantiate();
			dungeonButton.transform.position.x = 6;
			dungeonButton.AddRenderer<Renderer>().RenderStr = "1. Slime\n2. Orc\n3. Golem\n4. Return MainMenu";
		}

		{
			GameObject monster = GameObjectManager.Instance.FindGameObjectByName("Monster");

			if (monster == null)
			{
				monster = GameObject.Instantiate("Monster");
				monster.AddComponent<Monster>();
				monster.DontDestroy();
			}


			
		
		}

	}

}
