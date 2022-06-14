using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using JohnsonMath;
public class GameManager : Manager<GameManager>
{
	public GameManager()
	{
		Initialize();
	}

	private bool isQuit = false;
	public bool IsQuit
	{
		get { return isQuit; }
		set { isQuit = value; }
	}
	public void GameExit()
	{
		isQuit = true;
	}

	Vector2 cursorPos;
	public Vector2 CursorPos
	{
		get 
		{
			return cursorPos;
		}
		set 
		{
			Console.SetCursorPosition(value.x, value.y);
			cursorPos = value;
		}
	}

	public void SceneSetting()
	{
		Scene titleMenu = Scene.Instantiate<TitleMenu_Scene>(Enums.eScene.TitleMenu);
		Scene charSelect = Scene.Instantiate<CharacterSelect_Scene>(Enums.eScene.CharacterSelect);
		Scene mainMenu = Scene.Instantiate<MainMenu_Scene>(Enums.eScene.MainMenu);
		Scene shop = Scene.Instantiate<Shop_Scene>(Enums.eScene.Shop);
		Scene inventory = Scene.Instantiate<Inventory_Scene>(Enums.eScene.Inventory);
		Scene dungeonSelect = Scene.Instantiate<DungeonSelect_Scene>(Enums.eScene.DungeonSelect);
		Scene dungeonBattle = Scene.Instantiate<DungeonBattle_Scene>(Enums.eScene.DungeonBattle);

		SceneManager.Instance.InsertScene(titleMenu, charSelect, mainMenu, shop, inventory, dungeonSelect, dungeonBattle);
	}

	public void Initialize()
	{
		RenderManager.Instance.Initailize();
		SceneManager.Instance.Initailize();
		GameObjectManager.Instance.Initailize();

		//scene Setting//
		SceneSetting();
		SceneManager.Instance.SetFirstScene<TitleMenu_Scene>();

		InputManager.Instance.Initialize();
	}

	
	public void Process()
	{
		SceneManager.Instance.SceneChangeCheck();
		SceneManager.Instance.Update();//여기 안에서 GameObjMgr update 돌림
		SceneManager.Instance.ReadyRender();
		SceneManager.Instance.Render();//여기 안에서 RenderMgr Render 돌림
	}

	public void Release()
	{
		SceneManager.Instance.Release();
	}



}
