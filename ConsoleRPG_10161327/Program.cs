using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG_10161327
{
	class Program
	{
		static void Main(string[] args)
		{

    //        for (int i = 0; i < 32; ++i)
    //        {
    //            for (int k = 0; k < 63; ++k)
    //            {
    //                Console.Write("5");
    //            }
				//Console.Write("\n");
    //        }

			while (!(GameManager.Instance.IsQuit))
			{
				//게임메니저의 Process 돌리기
				//게임매니저는 SceneManager에셔 현재씬의 Update,LateUpdate,Render돌리기
				//현재씬에 있는 GameObject들의 cycle 돌려주고
				//GameObject는 Component들의 Cycle 돌려주기. => Cycle은 interface 

				//만약 while문 탈출하면 GameMAnager의 Release 돌려주기 
				GameManager.Instance.Process();
                //Console.SetWindowSize(100, 50); //윈도우는 ㄹㅇ 띄울 창이고

                //Console.SetCursorPosition(5, 5);

                //char[,] temp = new char[Defines.BufferX, Defines.BufferY];
                


            }

			GameManager.Instance.Release();

		}
	}
}
