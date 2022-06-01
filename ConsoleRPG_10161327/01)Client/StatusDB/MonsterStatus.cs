using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterStaus
{
	class Slime : StatusSetting
	{
		public Slime()
		{
			Init();
		}

		

		public void Init()
		{
			status.name = "Slime";

			status.kind = Enums.eUnit.Monster;


			status.gold = 100;

			status.Lv = 1;
			status.fullExp = 5;

			status.fullHp = 30;
			status.curHp = status.fullHp;

			status.dmg = 5 ;
		}


	}
	class Orc : StatusSetting
	{
		public Orc()
		{
			Init();
		}

		

		public void Init()
		{
			status.name = "Orc";

			status.kind = Enums.eUnit.Monster;


			status.gold = 500;

			status.Lv = 5;
			status.fullExp = 10;

			status.fullHp = 100;
			status.curHp = status.fullHp;

			status.dmg = 10;

		}
	}
	class Golem : StatusSetting
	{

		public Golem()
		{
			Init();
		}

		

		public void Init()
		{
			status.name = "Golem";

			status.kind = Enums.eUnit.Monster;


			status.gold = 1000;

			status.Lv = 10;
			status.fullExp = 100;

			status.fullHp = 250;
			status.curHp = status.fullHp;

			status.dmg = 20;

		}
	}

}
