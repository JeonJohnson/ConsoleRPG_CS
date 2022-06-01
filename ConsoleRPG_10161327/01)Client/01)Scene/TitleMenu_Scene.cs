using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TitleMenu_Scene : Scene
{
    public override void Initailize()
    {
        GameObject sceneName = GameObject.Instantiate("SceneName");
        Renderer    sceneNameRender = Renderer.Instantiate();
        sceneNameRender.RenderStr = "Title Scene";
        sceneName.AddRenderer(sceneNameRender);
        GameObject.DontDestroy(sceneName);

        GameObject sceneNameBorder = GameObject.Instantiate("SceneNameBorder");
        sceneNameBorder.GetComponent<Transform>().position.x = 1;
        sceneNameBorder.AddRenderer<LineRenderer>();
        GameObject.DontDestroy(sceneNameBorder);



        GameObject title = GameObject.Instantiate();
        title.transform.position.x = 2;
        Renderer titleRenderer = Renderer.Instantiate();
        titleRenderer.RenderStr = "TextRPG";
        title.AddRenderer(titleRenderer);

        GameObject sceneNameBoader2 = GameObject.Instantiate();
        //sceneNameBoader2.AddComponent<UI_Title>();
        sceneNameBoader2.GetComponent<Transform>().position.x = 3;
        sceneNameBoader2.AddRenderer<LineRenderer>();

        GameObject startButton = GameObject.Instantiate();
        startButton.transform.position.x = 4;
        startButton.AddRenderer<Renderer>().RenderStr =  "1. Game Start";

        GameObject exitButton = GameObject.Instantiate();
        exitButton.transform.position.x = 5;
        exitButton.AddRenderer<Renderer>().RenderStr = "2. Game Exit";



        GameObject inputLine = GameObject.Instantiate("InputLine");
        inputLine.transform.position.x = Defines.InputLine;
        inputLine.AddRenderer<LineRenderer>();
        GameObject.DontDestroy(inputLine);


		GameObject selectNum = GameObject.Instantiate("InputChecker");
		selectNum.transform.position.x = Defines.InputCheckerLine;
		selectNum.AddComponent<InputChecker>();
        GameObject.DontDestroy(selectNum);
        //selectNum.AddRenderer<Renderer>().RenderStr = "Input : ";
        

    }
}
