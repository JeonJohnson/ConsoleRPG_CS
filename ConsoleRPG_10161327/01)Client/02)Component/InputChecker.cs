using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Enums;
using JohnsonMath;

public class InputChecker : Component
{
    Renderer inputRenderer = null;

    //eScene curScene = eScene.End;

    void TitleSceneSelect(int selectNum)
    {
        switch (selectNum)
        {
            case 1:
                {

                    SceneManager.Instance.NextSceneChange();
                }
                break;

            case 2:
                {
                    GameManager.Instance.IsQuit = true;
                }
                break;

            case 3:
                { }
                break;
        }
    
    }

    void CharacterSelectScene(int selectNum)
    {
        StatusSetting tempStatus = null;

        switch (selectNum)
        {
            case 1:
                {
                    tempStatus = new WarriorStatus();
                    Player playerScript = GameObjectManager.Instance.FindGameObjectByName("Player").GetComponent<Player>();
                    playerScript.SetStatus = tempStatus.status;

                    SceneManager.Instance.NextSceneChange();
                }
                break;

            case 2:
                {
                    tempStatus = new MagicianStatus();
                    Player playerScript = GameObjectManager.Instance.FindGameObjectByName("Player").GetComponent<Player>();
                    playerScript.SetStatus = tempStatus.status;

                    SceneManager.Instance.NextSceneChange();
                }
                break;

            case 3:
                {
                    tempStatus = new RogueStatus();
                    Player playerScript = GameObjectManager.Instance.FindGameObjectByName("Player").GetComponent<Player>();
                    playerScript.SetStatus = tempStatus.status;

                    SceneManager.Instance.NextSceneChange();
                }
                break;

            case 9:
                {
                    GameManager.Instance.IsQuit = true;
                }
                break;
        }
    }

    void MainMenuScene(int selectNum)
    {

        switch (selectNum)
        {

            case 1:
                {
                    SceneManager.Instance.SceneChange(eScene.Dungeon);
                }
               break;

            case 2:
                {
                    SceneManager.Instance.SceneChange(eScene.Shop);
                }
                break;

            case 3:
                {
                    SceneManager.Instance.SceneChange(eScene.Inventory);
                }
                break;


            case 9:
                {
                    GameManager.Instance.IsQuit = true;
                }
                break;

        }
    }

    void DungeonScene(int selectNum)
    {
        switch (selectNum)
        {

            case 1:
                {

                }
                break;

            case 2:
                {

                }
                break;

            case 3:
                {

                }
                break;

            case 4:
                {
                    SceneManager.Instance.SceneChange(eScene.MainMenu);
                }
                break;

            case 9:
                {
                    GameManager.Instance.IsQuit = true;
                }
                break;

        }
    }



    public override void Initailize()
    {

        base.Initailize();


        inputRenderer = this.gameObject.AddRenderer<Renderer>();
        //for (int i = 0; i < Defines.BufferX-1; ++i)
        //{
        //    inputRenderer.RenderStr += '*';
        //}
        //inputRenderer.RenderStr += '\n';
        inputRenderer.RenderStr += " Input : ";
    }
    public override void Update()
    {
        //GameManager.Instance.CursorPos = GameManager.Instance.CursorPos;
        //string inputStr = Console.ReadLine();
        ////ReadLine을 쓰면 그냥 대기 상태가 됨.
        ////ReadLine이 아니라 InputManager 역할을 하는 애를 만들어서
        ////따로 처리를 해줘야할듯.
        //inputVal = int.Parse(inputStr);
        //ConsoleKeyInfo temp = Console.ReadKey();


        //인풋매니저를 만들어서
        //=> 여러 키 만들 필요는 없고
        //그냥 일차원 배열 하나만들어서 엔터키 나오기 전 까지 입력받기
        //엔터키 입력됐으면 입력받았던 배열 int값으로 변환해주고 체크 컴포넌트에서 확인하기?

        //매 프레임마다 멀티쓰레드로 키 입력 받아야함..?

        Vector2 cursorPos = new Vector2(gameObject.transform.position.y, gameObject.transform.position.x);
        cursorPos.x = inputRenderer.RenderStr.Length;
        GameManager.Instance.CursorPos = cursorPos;


        switch (SceneManager.Instance.CurScene.SceneNum)
        {
            case eScene.TitleMenu:
                {
                    TitleSceneSelect(InputManager.Instance.GetInputValue());
                }
                break;

            case eScene.CharacterSelect:
                {
                    CharacterSelectScene(InputManager.Instance.GetInputValue());
                }
                break;

            case eScene.MainMenu:
                {
                    MainMenuScene(InputManager.Instance.GetInputValue());
                }
                break;

            case eScene.Dungeon:
                { 
                
                }
                break;
        }


    }

    public override void ReadyRender()
    {
        base.ReadyRender();
    }

    public override void Release()
    {
        base.Release();
    }

	public override void SceneLoad(eScene sceneNum)
	{
		base.SceneLoad(sceneNum);
        
        

        


        //int a = 0;
	}

}
