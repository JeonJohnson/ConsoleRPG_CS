using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MainMenu_Scene : Scene
{
	GameObject	InGameWindow;
	GameObject	Title;
	GameObject	InputWindow;

	public override void Initailize()
	{
		InGameWindow = GameObject.Instantiate();
		InGameWindow.AddRenderer<Renderer>().RenderStr = "MainMenu Scene";


	}

}
