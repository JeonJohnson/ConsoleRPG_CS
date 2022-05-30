using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Shop_Scene : Scene
{

    public override void Initailize()
    {
        GameObject sceneName = GameObject.Instantiate();
        sceneName.AddRenderer<Renderer>().RenderStr = "Shop Scene";
    }

}
