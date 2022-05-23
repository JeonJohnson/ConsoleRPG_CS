using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class RenderManager : Manager<RenderManager>
{
	Dictionary<int, List<Renderer>> renderQueue;


	char[,] preRenderBuffer = new char[Defines.BufferX, Defines.BufferY];
	char[,] curRenderBuffer = new char[Defines.BufferX, Defines.BufferY];

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

	public void InsertRenderList(Renderer renderer, int renderIndex)
	{
		renderQueue[renderIndex].Add(renderer);
	}

	public void ClearRenderList()
	{
		for (int i = 0; i < (int)Enums.eRenderQueue.End; ++i)
		{
			//List<Renderer> temp = new List<Renderer>();
			renderQueue[i].Clear();
		}
	}


	public void Initailize()
	{
		WindowSetting();

		renderQueue = new Dictionary<int, List<Renderer>>();

		for (int i = 0; i < (int)Enums.eRenderQueue.End; ++i)
		{
			List<Renderer> temp = new List<Renderer>();
			renderQueue.Add(i,temp);
		}
	}


	
	public void Render()
	{
		//Console.SetWindowSize(Defines.WinCX, Defines.WinCY); //윈도우는 ㄹㅇ 띄울 창의 크기고 => 


		//Console.Clear();
		//깜빡임 심함
		//+각 렌더 큐 옵젝들마다 화면크기 만큼 가지고 있어야 겠지

		//한 렌더 큐 옵젝들을 모아서 하나의 64*32 배열 만들기
		//각 렌더 큐의 배열을 만들어서 순서대로 덮어쓰기
		//그 전에 렌더한 배열과 비교하여 다른부분만 바꾼다음에 출력해주기.


		//0523 렌더큐의 개념을 없애기???



		//테두리 렌더링
		//UI(객체들) 렌더링

		//for (int i = 0; i < (int)Enums.eRenderQueue.End; ++i)
		//{
		//	for (int k = 0; k < renderQueue[i].Count; ++k)
		//	{
		//		renderQueue[i][k].Render();
		//	}
		//}

		ClearRenderList();

	}
	

}
