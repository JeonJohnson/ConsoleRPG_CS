using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DungeonBattle_Scene : Scene
{

	GameObject sceneNameObj = null;
	GameObject notice = null;

	public override void Initailize()
	{
		{
			sceneNameObj = GameObjectManager.Instance.FindGameObjectByName("SceneName");
			sceneNameObj.GetRenderer<Renderer>().RenderStr = "Dungeon Battle Scene";
		}

		{
			GameObject statusViewer = GameObject.Instantiate("MonsterStatusViewer");
			statusViewer.transform.position.x = 6;
			Monster tempScript = GameObjectManager.Instance.FindGameObjectByName("Monster").GetComponent<Monster>();
			statusViewer.AddComponent<StatusViewer>().SetUnit = tempScript;
		}


		for (int i = 3; i < 8; i += 2)
		{
			GameObject temp = GameObject.Instantiate();
			temp.AddRenderer<LineRenderer>();
			temp.transform.position.x = i;
		}

		{
			GameObject dungeonButton = GameObject.Instantiate();
			dungeonButton.transform.position.x = 8;
			dungeonButton.AddRenderer<Renderer>().RenderStr = "1. Attack\n2. Run\n3. Return MainMenu";
			
			GameObject temp = GameObject.Instantiate();
			temp.AddRenderer<LineRenderer>();
			temp.transform.position.x = 11;

		}

		{
			InputChecker inputCheckerComp = GameObjectManager.Instance.FindGameObjectByName("InputChecker").GetComponent<InputChecker>();
			inputCheckerComp.CurBattleState = Enums.eBattleProgress.End;
			inputCheckerComp.CurBattleResult = Enums.eBattleResult.End;

			GameObject battleInfoObj = GameObject.Instantiate("BattleInfo");
			inputCheckerComp.setBattelInfoComponent = battleInfoObj.AddComponent<Battle_Info>();
			battleInfoObj.transform.position.x = 12;
		}

	}

}
