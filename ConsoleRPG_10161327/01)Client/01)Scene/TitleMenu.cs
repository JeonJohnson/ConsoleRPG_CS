using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TitleMenu : Scene
{
    public override void Initailize()
    {
        GameObject sceneName = GameObject.Instantiate();
        sceneName.AddComponent<UI_Title>();

        Renderer    sceneNameRender = Renderer.Instantiate();
        sceneNameRender.RenderStr = "Title Menu";
        sceneName.AddRenderer(sceneNameRender);


        GameObject sceneNameBoader = GameObject.Instantiate();
        sceneNameBoader.AddComponent<UI_Title>();
        sceneNameBoader.GetComponent<Transform>().position.x = 1;
        //Renderer sceneNameBoaderRenderer = Renderer.Instantiate();
        //for (int i = 0; i < Defines.BufferX; ++i)
        //{
        //    sceneNameBoaderRenderer.RenderStr += '*';
        //}
        //sceneNameBoader.AddRenderer(sceneNameBoaderRenderer);
        sceneNameBoader.AddRenderer<LineRenderer>();


        GameObject title = GameObject.Instantiate();
        title.transform.position.x = 2;
        Renderer titleRenderer = Renderer.Instantiate();
        titleRenderer.RenderStr = "TextRPG";
        title.AddRenderer(titleRenderer);

        GameObject sceneNameBoader2 = GameObject.Instantiate();
        sceneNameBoader2.AddComponent<UI_Title>();
        sceneNameBoader2.GetComponent<Transform>().position.x = 3;
        sceneNameBoader2.AddRenderer<LineRenderer>();

        GameObject startButton = GameObject.Instantiate();
        startButton.transform.position.x = 4;
        startButton.AddRenderer<Renderer>().RenderStr =  "1. Game Start";

        GameObject exitButton = GameObject.Instantiate();
        exitButton.transform.position.x = 5;
        exitButton.AddRenderer<Renderer>().RenderStr = "2. Game Exit";


        GameObject selectNum = GameObject.Instantiate();
        selectNum.transform.position.x = 20;
        selectNum.AddComponent<InputCheck>();
        //selectNum.AddRenderer<Renderer>().RenderStr = "Input : ";


    }
}
