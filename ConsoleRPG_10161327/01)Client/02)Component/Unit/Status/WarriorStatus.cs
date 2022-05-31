using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		status.fullHp = 150;
		status.curHp = status.fullHp;

		status.dmg = 10;
	}

}
