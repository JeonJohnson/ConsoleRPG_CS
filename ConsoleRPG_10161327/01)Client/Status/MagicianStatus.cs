using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		status.fullHp = 100;
		status.curHp = status.fullHp;

		status.dmg = 20;
	}

}
