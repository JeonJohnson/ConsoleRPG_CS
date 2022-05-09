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
}