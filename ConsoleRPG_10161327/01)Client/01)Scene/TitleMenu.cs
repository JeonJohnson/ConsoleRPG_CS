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



        GameObject titleName2 = GameObject.Instantiate();
        titleName2.AddComponent<UI_Title>();
        titleName2.GetComponent<Transform>().position.x = 1;


        Renderer titleRender2 = Renderer.Instantiate();
        titleRender2.RenderStr = "************************";
        titleName2.AddRenderer(titleRender2);

        //GameObject titleLine = GameObject.Instantiate();
        //titleLine.transform.position = new JohnsonMath.Vector2(0, 1);
        //titleLine.AddRenderer<LineRenderer>();






    }
}
