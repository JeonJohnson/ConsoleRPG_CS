using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class RenderManager : Manager<RenderManager>
{
	public RenderManager()
	{ 
	}

	

	public void WindowSetting()
	{
		//Test
		int saveBufferWidth = Console.BufferWidth; //120
		int saveBufferHeight = Console.BufferHeight; //9001
		int saveWindowHeight = Console.WindowHeight; //30
		int saveWindowWidth = Console.WindowWidth; //120

		//해상도의 개념이 아니라
		//한 글자의 크기에 따라서 그런거임 
		Console.SetWindowSize(1, 1);
		Console.SetBufferSize(Defines.BufferX, Defines.BufferY); //버퍼는 ㄹㅇ 글자에 사용 할 수 있는 공간인듯
		Console.SetWindowSize(Defines.WinCX, Defines.WinCY); //윈도우는 ㄹㅇ 띄울 창의 크기고 => 

		//for (int k = 0; k < 50; ++k)
		//{
		//	for (int i = 0; i < 100; ++i)
		//	{
		//		Console.Write(0);
		//	}
		//	Console.WriteLine();
		//}
	}

	public void Awake()
	{
		WindowSetting();
	}


	public void Render()
	{
		Console.SetWindowSize(Defines.WinCX, Defines.WinCY); //윈도우는 ㄹㅇ 띄울 창의 크기고 => 

		Console.Clear();

		//테두리 렌더링
		//UI(글자들) 렌더링
		//객체들 랜더링
			}
	

}
