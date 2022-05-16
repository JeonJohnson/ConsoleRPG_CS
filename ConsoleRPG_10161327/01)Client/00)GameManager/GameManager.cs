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
		RenderManager.Instance.Awake();


		SceneManager.Instance.Awake();
		GameObjectManager.Instance.Awake();
	}

	
	public void Process()
	{
		SceneManager.Instance.Update();

		RenderManager.Instance.Render();
		GameObjectManager.Instance.Render();
	}

	public void Release()
	{
		SceneManager.Instance.Release();
	}



}
