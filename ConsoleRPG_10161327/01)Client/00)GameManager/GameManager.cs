using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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


	public void SceneSetting()
	{
		Scene titleMenu = Scene.Instantiate<TitleMenu>(Enums.eScene.TitleMenu);
		Scene charSelect = Scene.Instantiate<CharacterSelect>(Enums.eScene.CharacterSelect);
		Scene mainMenu = Scene.Instantiate<MainMenu>(Enums.eScene.MainMenu);
		Scene shop = Scene.Instantiate<Shop>(Enums.eScene.Shop);
		Scene inventory = Scene.Instantiate<Inventory>(Enums.eScene.Inventory);
		Scene dungeon = Scene.Instantiate<Dungeon>(Enums.eScene.Dungeon);

		SceneManager.Instance.InsertScene(titleMenu, charSelect, mainMenu, shop, inventory, dungeon);
	}

	public void Initialize()
	{
		RenderManager.Instance.Initailize();
		SceneManager.Instance.Initailize();
		GameObjectManager.Instance.Initailize();

		//scene Setting//
		SceneSetting();
		SceneManager.Instance.SetFirstScene<TitleMenu>();	
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
