using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StatusViewer : Component
{
	Renderer statusRenderer;
	Player playerScript;

	string tempStr;
	public Player SetPlayerSript
	{
		set { playerScript = value; }
	}

	public override void Initailize()
	{
		base.Initailize();

		statusRenderer = gameObject.AddRenderer<Renderer>();
		//playerScript = GameObjectManager.Instance.FindGameObjectByName("Player");
	}

	public override void Update()
	{
		if (playerScript!= null)
		{
			tempStr = $"* {playerScript.Name} " +
				$" LV:{playerScript.LV} " +
				$"({playerScript.CurEXP}/" +
				$"{playerScript.FullEXP}) " +
				$" HP:{playerScript.CurHp}/{playerScript.FullHp} " +
				$" Dmg:{playerScript.DMG}";

			statusRenderer.RenderStr = tempStr;
		}

	}

	public override void ReadyRender()
	{
		base.ReadyRender();
	}

	public override void Release()
	{
		base.Release();
	}

	public override void SceneLoad(eScene sceneNum)
	{
		base.SceneLoad(sceneNum);
	}
}
