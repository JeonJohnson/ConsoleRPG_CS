using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Structs;

public class StatusViewer : Component
{
	Renderer statusRenderer;
	//Player playerScript;

	Unit unit;

	string tempStr;

	//public Player SetPlayerSript
	//{
	//	set { playerScript = value; }
	//}

	public Unit SetUnit
	{
		set { unit = value; }
	}


	public override void Initailize()
	{
		base.Initailize();

		statusRenderer = gameObject.AddRenderer<Renderer>();
		//playerScript = GameObjectManager.Instance.FindGameObjectByName("Player");
	}

	public override void Update()
	{
		//if (playerScript!= null)
		//{
		//	tempStr = $"* {playerScript.Name}" +
		//		$" LV:{playerScript.LV} " +
		//		$"({playerScript.CurEXP}/" +
		//		$"{playerScript.FullEXP}) " +
		//		$" HP:{playerScript.CurHp}/{playerScript.FullHp} " +
		//		$" Dmg:{playerScript.DMG}";

		//	statusRenderer.RenderStr = tempStr;
		//}


		if (unit.UnitKind == Enums.eUnit.Player)
		{
			tempStr = $"* {unit.Name}" +
				$" LV:{unit.LV} " +
				$"({unit.CurEXP}/" +
				$"{unit.FullEXP}) " +
				$" HP:{unit.CurHp}/{unit.FullHp} " +
				$" Dmg:{unit.DMG} "+
				$"{unit.Gold,3}\\ ";
		}
		else
		{
			tempStr = $"* {unit.Name}" +
				$" LV:{unit.LV} " +
				$" EXP:{unit.FullEXP} " +
				$" HP:{unit.CurHp}/{unit.FullHp} " +
				$" Dmg:{unit.DMG} "+
				$" Gold:{unit.Gold} ";
		}



		statusRenderer.RenderStr = tempStr;

	}

	public override void ReadyRender()
	{
		base.ReadyRender();
	}

	public override void Release()
	{
		base.Release();
		statusRenderer = null;
		unit = null;
	}

	public override void SceneLoad(eScene sceneNum)
	{
		base.SceneLoad(sceneNum);
	}
}
