﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Inventory_Scene : Scene
{

    public override void Initailize()
    {
        GameObject sceneName = GameObject.Instantiate();
        sceneName.AddRenderer<Renderer>().RenderStr = "Inventory Scene";
    }

}
