using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LineRenderer : Renderer
{

	public override void Initailize()
	{
		base.Initailize();
		for (int i = 0; i < 31; ++i)
		{
			RenderStr += '*';
		}
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
