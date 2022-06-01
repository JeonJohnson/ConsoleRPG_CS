using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerStatus
{
	class WarriorStatus : StatusSetting
	{
		public WarriorStatus()
		{
			Init();
		}

		public void Init()
		{
			status.name = "Warrior";
			status.kind = Enums.eUnit.Player;
			status.job = Enums.eClass.Warrior;

			status.Lv = 1;

			status.fullHp = 150;
			status.curHp = status.fullHp;

			status.fullExp = 10;

			status.dmg = 10;
		}

	}

	class MagicianStatus : StatusSetting
	{
		public MagicianStatus()
		{
			Init();
		}

		public void Init()
		{
			status.name = "Magician";
			status.kind = Enums.eUnit.Player;
			status.job = Enums.eClass.Magician;

			status.Lv = 1;

			status.fullHp = 100;
			status.curHp = status.fullHp;

			status.fullExp = 10;

			status.dmg = 20;
		}

	}


	class RogueStatus : StatusSetting
	{
		public RogueStatus()
		{
			Init();
		}

		public void Init()
		{
			status.name = "Rogue";
			status.kind = Enums.eUnit.Player;
			status.job = Enums.eClass.Rogue;


			status.Lv = 1;

			status.fullHp = 125;
			status.curHp = status.fullHp;

			status.fullExp = 10;

			status.dmg = 15;
		}

	}

}
