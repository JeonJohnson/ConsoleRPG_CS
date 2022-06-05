using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums;
using Structs;
public abstract class Item
{
	public ItemStatus status; 
	
}

namespace Weapon
{
	public class WoodStick : Item
	{
		public WoodStick()
		{
			status.name = "WoodStick";
			status.kind = eItemKind.Weapon;
			status.price = 50;
			status.requiredLv = 1;

			status.hp = 0;
			status.dmg = 5;

			status.isEquipped = false;
		}
	}

	public class Sword : Item 
	{
		public Sword()
		{
			status.name = "Sword";
			status.kind = eItemKind.Weapon;
			status.price = 100;
			status.requiredLv = 3;

			status.hp = 0;
			status.dmg = 10;

			status.isEquipped = false;
		}
	}
	public class Ak47 : Item
	{
		public Ak47()
		{
			status.name = "Ak47";
			status.kind = eItemKind.Weapon;
			status.price = 200;
			status.requiredLv = 5;

			status.hp = 0;
			status.dmg = 20;

			status.isEquipped = false;
		}
	}

}

namespace Armor
{
	public class RagsSet : Item
	{
		public RagsSet()
		{
			status.name = "Rags";
			status.kind = eItemKind.Armor;
			status.price = 50;
			status.requiredLv = 1;

			status.hp = 10;
			status.dmg = 0;

			status.isEquipped = false;
		}
	}

	public class LeatherSet : Item
	{
		public LeatherSet()
		{
			status.name = "Leather";
			status.kind = eItemKind.Armor;
			status.price = 100;
			status.requiredLv = 3;

			status.hp = 50;
			status.dmg = 0;

			status.isEquipped = false;
		}
	}

	public class GucciSet : Item
	{
		public GucciSet()
		{
			status.name = "Gucci";
			status.kind = eItemKind.Armor;
			status.price = 200;
			status.requiredLv = 5;

			status.hp = 100;
			status.dmg = 0;

			status.isEquipped = false;
		}
	}


}

