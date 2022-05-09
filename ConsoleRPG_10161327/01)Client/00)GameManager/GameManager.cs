using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GameManager : Manager<GameManager>
{

	private bool isQuit = false;

	public bool IsQuit
	{
        get { return isQuit; }
		set { isQuit = value; }
	}
	

	public void Initialize()
	{
		//여기에서 씬 다 생성해서 추가해주기.
		
	}

	
	public void Process()
	{
		SceneManager.Instance.Update();
		SceneManager.Instance.Render();
	}

	public void Release()
	{
		SceneManager.Instance.Release();
	}



}
