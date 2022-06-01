using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Monster : Unit
{
	public override int Attack()
	{
		return base.Attack();
	}


	public override void Hit(int dmg)
	{
		base.Hit(dmg);
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
