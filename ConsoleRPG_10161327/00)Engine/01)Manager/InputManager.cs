using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class InputManager : Manager<InputManager>
{
	//Console. Read / ReadLine / ConsoleKey 등은 동기적으로 작동해서
	//입력 받기 전까지는 wait 상태임.
	//근데 그럴꺼면 지금 같은 cycle 구조 자체가 필요가 없음.
	//=> 그래서 비동기적으로 입력을 받아야함.
	//=> 모든 키 입력의 기준은 Enter키로. (즉각 움직이는게 아니라 어차피 숫자 선택지로만 이루어져야 하니까)
	//=> 뭘 입력하던 Enter키가 눌러져야함.

	//계속 실행하면서 입력하는 값들을 저장해두고
	//엔터키를 누르면 그 값들을 int형으로 받아 올 수 있게?

	private List<ConsoleKeyInfo> inputKeyCodes = new List<ConsoleKeyInfo>();

	ConsoleKeyInfo inputKeyCode;

	private int inputVal = -1;

	private void InputAction()
	{
		ConsoleKeyInfo tempKeyInfo = Console.ReadKey();

		if (tempKeyInfo.Key == ConsoleKey.Enter || tempKeyInfo.Key == ConsoleKey.Spacebar)
		{
			//int temp = int.Parse(tempKeyInfo.KeyChar.ToString());
			//Console.WriteLine(temp);
			//int count = inputKeyCodes.Count;

			//for (int i = inputKeyCodes.Count - 1; i > 0; --i)
			//{
			//	inputVal += int.Parse(inputKeyCodes[i].KeyChar.ToString()) * (Math.Pow(10,i-count));
			//}

			inputVal = int.Parse(inputKeyCode.KeyChar.ToString());
		}
		else if (char.IsDigit(tempKeyInfo.KeyChar))
		{
			//inputKeyCodes.Add(tempKeyInfo);
			inputKeyCode = tempKeyInfo;
		}

		Task.Factory.StartNew(InputAction);
	}

	public int GetInputValue()
	{
		int tempVal = inputVal;
		inputVal = -1;
		return tempVal;
	}


	public void Initialize()
	{
		Task.Factory.StartNew(InputAction);

	}

	public void Release()
	{

	}

}

