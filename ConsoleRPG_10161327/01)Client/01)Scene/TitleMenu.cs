using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TitleMenu : Scene
{
    public override void Initailize()
    {
        GameObject titleName = GameObject.Instantiate();
        titleName.AddComponent<UI_Title>();

        Renderer    titleRender = Renderer.Instantiate();
        titleRender.RenderStr = "Title Menu";
        titleName.AddRenderer(titleRender);


        GameObject titleLine = GameObject.Instantiate();
        titleLine.transform.position = new JohnsonMath.Vector2(0, 1);
        titleLine.AddRenderer<LineRenderer>();
                



        

    }
}
