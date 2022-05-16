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


	public void Initialize()
	{
		RenderManager.Instance.Initailize();
		SceneManager.Instance.Initailize();
		GameObjectManager.Instance.Initailize();
	}

	
	public void Process()
	{
		SceneManager.Instance.SceneChangeCheck();
		SceneManager.Instance.Update();//여기 안에서 GameObjMgr update 돌림
		SceneManager.Instance.Render();//여기 안에서 RenderMgr Render 돌림
	}

	public void Release()
	{
		SceneManager.Instance.Release();
	}



}
