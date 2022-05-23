using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LineRenderer : Renderer
{


	private string renderLine;

    public string RenderLine
    {
        get 
        {
            return renderLine;
        }
        set 
        {
            renderLine = value;
        }
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

    public override void Render()
	{
	}
    

    public override void Release()
    {
        base.Release();
    }
}
