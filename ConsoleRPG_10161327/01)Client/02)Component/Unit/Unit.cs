using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Structs;

public class Unit : Component
{

	protected UnitStatus unitStatus;

	public UnitStatus SetStatus
	{
		set { unitStatus = value; }
	}
	public int CurHp
	{
		get { return unitStatus.curHp; }
	}

	public int FullHp
	{
		get { return unitStatus.fullHp; }
	}

	public virtual void Hit(int dmg)
	{
		unitStatus.curHp -= dmg;
	}

	public virtual int Attack()
	{
		return unitStatus.dmg;
	}

	public virtual int LevelUp()
	{
		++unitStatus.Lv;

		return unitStatus.Lv;
	}

	public virtual void Heal(int healAmount)
	{ 
	
	}

	public override void Initailize()
	{
		
	}
	public override void Update()
	{
		
	}

	public override void ReadyRender()
	{
		base.ReadyRender();
	}

	public override void Release()
	{
		
	}

}
