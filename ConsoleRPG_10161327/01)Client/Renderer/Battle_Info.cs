using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Battle_Info : Component
{

	Renderer battleInfoRenderer = null;
	Renderer battleInfoEraser = null;

	Queue<string> infoStrQueue;
	//FIFO
	//Dequeue() (pop)
	//Enqueue() (add)

	public string BattleInfoStr
	{
		set
		{
			char[] tempArray = Enumerable.Repeat<char>(' ',Defines.BufferX).ToArray<char>();

			if (value != "\n")
			{
				for (int i = 0; i < value.Length; ++i)
				{
					tempArray[i] = value[i];
				}
			}
			tempArray[Defines.BufferX - 1] = '\n';
			string tempStr = new string(tempArray);
			infoStrQueue.Enqueue(tempStr);
		}
	}

	public override void Initailize()
	{
		base.Initailize();

		if (battleInfoRenderer ==null)
		{
			battleInfoRenderer = this.gameObject.AddRenderer<Renderer>();
			battleInfoRenderer.RenderStr = "";
		}

		if (battleInfoRenderer == null)
		{ 
			
		}

		infoStrQueue = new Queue<string>();

	}
	public override void Update()
	{
		//배틀 순서
		//"한줄 띄우기"
		//몬스터 히트
		// '몬스터 이름' takes '플레이어 공격력' dmg from '플레이어 직업'
		//몬스터 죽은지 파악
		//몬스터 죽으면 'Player Win!'
		//플레이어 히트
		// '플레이어 직업' takes '몬스터 공격력' dmg from '몬스터 이름'
		//플레이어 죽은지 파악
		//'Player Death' return MainMenu

		for (int i = infoStrQueue.Count; i > 16; --i)
		{
			infoStrQueue.Dequeue();
		}

		battleInfoRenderer.RenderStr = "";
		foreach (string str in infoStrQueue)
		{
			battleInfoRenderer.RenderStr += (str);
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
