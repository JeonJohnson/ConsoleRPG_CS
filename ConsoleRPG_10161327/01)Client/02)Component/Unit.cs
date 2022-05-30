using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Structs;

public class Unit : Component
{

	protected UnitStatus unitStatus;
		

	public virtual void Hit(int dmg)
	{ 
	
	}

	public virtual int Attack()
	{
		return 0;
	}
	

	public override void Initailize()
	{
		throw new NotImplementedException();
	}
	public override void Update()
	{
		throw new NotImplementedException();
	}

	public override void ReadyRender()
	{
		base.ReadyRender();
	}

	public override void Release()
	{
		throw new NotImplementedException();
	}

}
