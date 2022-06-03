using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Player : Unit
{
	public override int Attack()
	{
		return base.Attack();
	}

	public override void Heal(int healAmount)
	{
		base.Heal(healAmount);
	}

	public override void Hit(int dmg)
	{
		base.Hit(dmg);
	}

	public int GainExp(int exp, int gold)
	{
		unitStatus.curExp += exp;
		unitStatus.gold += gold;

		if (unitStatus.curExp >= unitStatus.fullExp)
		{
			return LevelUp();
		}

		return 0;
	}

	public override int LevelUp()
	{
		base.LevelUp();

		unitStatus.dmg += 5;

		unitStatus.curExp = 0;
		unitStatus.fullExp = LV * 5 + 10;

		unitStatus.fullHp += LV * 5;
		unitStatus.curHp = unitStatus.fullHp;

		return LV;
	}

	public override void Initailize()
	{
		base.Initailize();
	}

	public override void Update()
	{
		base.Update();

		
	}

	public override void ReadyRender()
	{
		base.ReadyRender();
	}

	public override void Release()
	{
		base.Release();
	}

	
}
