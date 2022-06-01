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

	public override int LevelUp()
	{
		return base.LevelUp();
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
