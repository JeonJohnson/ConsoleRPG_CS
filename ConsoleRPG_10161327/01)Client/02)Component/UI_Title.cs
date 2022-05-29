using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class UI_Title : Component
{

    public override void Initailize()
    {
        gameObject.transform.position = new JohnsonMath.Vector2();
        
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
