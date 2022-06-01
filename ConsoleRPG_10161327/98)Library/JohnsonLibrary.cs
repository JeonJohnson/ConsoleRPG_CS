using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Structs
{
	public struct GameObjectDesc
	{
		public string name;
		public Enums.Tags tag;
		public Enums.Layer layer;
	}

	public struct UnitStatus
	{
		public string name;

		public Enums.eUnit kind;
		public Enums.eClass job;

		public int gold;

		public int Lv;
		public int curExp;
		public int fullExp;

		public bool isDeath;
		public int fullHp;
		public int curHp;

		public int dmg;
	}

	public struct ItemStatus
	{
		public string name;
		public Enums.eItemKind kind;

		public int price;
		public int requiredLv;

		public int hp;

		public int dmg;
	}

}

namespace Enums
{
	public enum Tags
	{ 
		End
	}

	public enum Layer
	{ 
		End
	}

	public enum eScene
	{ 
		TitleMenu,
		CharacterSelect,
		MainMenu,
		Inventory,
		Shop,
		DungeonSelect,
		DungeonBattle,
		End,

		Exit = 9
	}

	//public enum eRenderQueue
	//{
	//	Boundary,
	//	Objects,
	//	End
	//}

	public enum eUnit
	{ 
		Player,
		Monster,
		End
	}

	public enum eItemKind
	{
		Weapon,
		Armor,
		Acc,
		End
	}

	public enum eClass
	{ 
		Warrior,
		Magician,
		Rogue,
		End
	}

}

public static class Fucns
{
	public static bool I2B(int i)
	{
		return Convert.ToBoolean(i);
	}

	public static int B2I(bool b)
	{
		return Convert.ToInt32(b);
	}
}
public static class Defines
{
	public const int TestConstant = 1;

	public const int BufferX = 64;
	public const int BufferY = 32;

	public const int WinCX = 65;
	public const int WinCY = 33;

	public const int InputLine = 30;
	public const int InputCheckerLine = 31;
}
