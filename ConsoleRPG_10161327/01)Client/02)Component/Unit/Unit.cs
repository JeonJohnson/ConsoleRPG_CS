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
	public Enums.eUnit UnitKind
	{
		get { return unitStatus.kind; }
	}

	public string Name
	{
		get { return unitStatus.name; }
	}

	public int LV
	{
		get { return unitStatus.Lv; }
	}

	public int FullEXP
	{
		get { return unitStatus.fullExp; }
	}

	public int CurEXP
	{
		get { return unitStatus.curExp; }
	}

	public int CurHp
	{
		get { return unitStatus.curHp; }
	}

	public int FullHp
	{
		//set { FullHp = value; }
		get { return unitStatus.fullHp; }
	}
	public void AddFullHp(int _val)
	{
		unitStatus.fullHp += _val;
	}

	public int testdmg = 0;
	public int testDmg
	{
		set {
			//unitStatus.dmg += ++testdmg; 
		}
	}
	public int DMG
	{
		get { return unitStatus.dmg; }
	}

	public void AddDmg(int _val)
	{
		unitStatus.dmg += _val;
	}


	public int Gold
	{
		get { return unitStatus.gold; }
	}
	public void AddGold(int _val)
	{ unitStatus.gold += _val; }

	public virtual void Hit(int dmg)
	{
		unitStatus.curHp -= dmg;

		if (unitStatus.curHp <= 0)
		{
			unitStatus.curHp = 0;
			unitStatus.isDeath = true;
		}
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

	public void EquippedItem(ItemStatus status, int _val = 1)
	{
		unitStatus.dmg += status.dmg * _val;

		unitStatus.fullHp += status.hp * _val;

		if (unitStatus.curHp > unitStatus.fullHp)
		{
			unitStatus.curHp = unitStatus.fullHp;
		}
	}

	public virtual void Heal(int healAmount)
	{ 
	
	}

	public virtual bool Death()
	{
		return unitStatus.isDeath;
	}

	public override void Initailize()
	{
		base.Initailize();
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
		base.Release();
	}

}
