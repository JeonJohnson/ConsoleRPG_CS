using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PlayerStatus;
using Enums;
using JohnsonMath;

public class InputChecker : Component
{
    Renderer inputRenderer = null;

    //eScene curScene = eScene.End;

    Player player = null;
    Monster monster = null;
    
    Battle_Info battleInfo = null;
    public Battle_Info setBattelInfoComponent
    {
        set { battleInfo = value; }
    }

    eBattleProgress curBattleState = eBattleProgress.End;
    public eBattleProgress CurBattleState
    { 
        set { curBattleState = value; }
    }

    eBattleResult curBattleResult = eBattleResult.End;
    public eBattleResult CurBattleResult
    {
        set { curBattleResult = value; }
    }

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

            case 7:
                {
                    tempStatus = new RogueStatus();
                    tempStatus.status.name = "Tester";
                    tempStatus.status.fullHp = 1000;
                    tempStatus.status.curHp = tempStatus.status.fullHp;
                    tempStatus.status.Lv = 10;
                    tempStatus.status.dmg = 1;
                    tempStatus.status.gold = 10000;
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
                    SceneManager.Instance.SceneChange(eScene.DungeonSelect);
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

    void DungeonSelectScene(int selectNum)
    {
        StatusSetting monsterStatus = null;

        switch (selectNum)
        {

            case 1:
                {
                    monsterStatus = new MonsterStaus.Slime();
                    Monster monsterScript = GameObjectManager.Instance.FindGameObjectByName("Monster").GetComponent<Monster>();
                    monsterScript.SetStatus = monsterStatus.status;

                    SceneManager.Instance.SceneChange(eScene.DungeonBattle);
                }
                break;

            case 2:
                {
                    monsterStatus = new MonsterStaus.Orc();
                    Monster monsterScript = GameObjectManager.Instance.FindGameObjectByName("Monster").GetComponent<Monster>();
                    monsterScript.SetStatus = monsterStatus.status;

                    SceneManager.Instance.SceneChange(eScene.DungeonBattle);
                }
                break;

            case 3:
                {
                    monsterStatus = new MonsterStaus.Golem();
                    Monster monsterScript = GameObjectManager.Instance.FindGameObjectByName("Monster").GetComponent<Monster>();
                    monsterScript.SetStatus = monsterStatus.status;

                    SceneManager.Instance.SceneChange(eScene.DungeonBattle);
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

    eBattleResult DungeonBattleScene(int selectNum)
    {
        switch (selectNum)
        {
            case 1: //Attack
            case 7:
                {
                    if (curBattleState == eBattleProgress.End)
                    {
                        curBattleState = eBattleProgress.Ing;
                        //return eBattleResult.End;
                    }

                    if (curBattleState == eBattleProgress.Ing)
                    {
                        
                        Enums.eBattleResult temp = Battle(selectNum);

                        if (temp == eBattleResult.Win)
                        {
                            
                            curBattleState = eBattleProgress.Fin;

                            battleInfo.BattleInfoStr = "\n";
                            battleInfo.BattleInfoStr = string.Format("{0} Win!!!", player.Name);

                            battleInfo.BattleInfoStr = "\n";
                            battleInfo.BattleInfoStr = string.Format("{0} takes {1} Gold, {2} EXP", player.Name, monster.Gold, monster.FullEXP);

                            if (player.GainExp(monster.FullEXP, monster.Gold) > 0)
                            {
                                battleInfo.BattleInfoStr = "\n";
                                battleInfo.BattleInfoStr = "Player Lv Up!";
                            }
                            //SceneManager.Instance.SceneChange(eScene.DungeonSelect);

                            return eBattleResult.Win;
                        }
                        else if (temp == eBattleResult.Defeated)
                        {
                            //SceneManager.Instance.SceneChange(eScene.MainMenu);
                            curBattleState = eBattleProgress.Fin;

                            return eBattleResult.Defeated;
                        }
                        else
                        {
                            return eBattleResult.End;
                        }
                    }
                }
                return eBattleResult.End;


            case 2: //Run
                {
                    SceneManager.Instance.SceneChange(eScene.DungeonSelect);

                }
                return eBattleResult.End;


            case 3: //return MainMenu
                {
                    SceneManager.Instance.SceneChange(eScene.MainMenu);
                }
                return eBattleResult.End;

            case 4:
                {
                    monster.testDmg = 1;               
                }
                return eBattleResult.End;

            case 9:
                {
                    GameManager.Instance.IsQuit = true;
                }
                return eBattleResult.End;


            default:
                return eBattleResult.End;
        }
    }


    eBattleResult Battle(int cheat = 1)
    {
        int playerDmg = player.Attack();

        playerDmg = 500;

        //battleInfo.BattleInfoStr = "\n";
        monster.Hit(playerDmg);
        battleInfo.BattleInfoStr = "\n";
        battleInfo.BattleInfoStr = string.Format("{0} takes {1} dmg from {2}", monster.Name, playerDmg, player.Name);
        //battleInfo.BattleInfoStr = 1.ToString();

        if (!monster.Death())
        {
            player.Hit(monster.Attack());
            battleInfo.BattleInfoStr = string.Format("{0} takes {1} dmg from {2}", player.Name, monster.Attack(), monster.Name);
            //battleInfo.BattleInfoStr = 2.ToString();

            if (player.Death())
            {
                battleInfo.BattleInfoStr = "\n";
                battleInfo.BattleInfoStr = string.Format("YOU DIED, Return to Character Select Scene", player.Name);
                return eBattleResult.Defeated;
            }
        }
        else 
        {
            return eBattleResult.Win;
        }

        return eBattleResult.End;
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

            case eScene.DungeonSelect:
                {
                    DungeonSelectScene(InputManager.Instance.GetInputValue());
                }
                break;

            case eScene.DungeonBattle:
                {
                    if (curBattleState != eBattleProgress.Fin)
                    {
                        curBattleResult = DungeonBattleScene(InputManager.Instance.GetInputValue());
                    }
                    else if (curBattleState == eBattleProgress.Fin)
                    {
                        if (InputManager.Instance.GetInputValue() != -1)
                        {
                            if (curBattleResult == eBattleResult.Defeated)
                            { 

                                SceneManager.Instance.SceneChange(eScene.CharacterSelect); 
                            }
                            else if (curBattleResult == eBattleResult.Win)
                            { SceneManager.Instance.SceneChange(eScene.DungeonSelect); }
                        
                        }
                    }
                }
                break;

            case eScene.Shop:
                { }
                break;

            case eScene.Inventory:
                {
                    ////구매 자체는 인벤토리에서 함.
                    //if (InputManager.Instance.GetInputValue() == 8)
                    //{
                    //    SceneManager.Instance.SceneChange(eScene.MainMenu);
                    //}

                    //if (InputManager.Instance.GetInputValue() == 9)
                    //{
                    //    GameManager.Instance.IsQuit = true;
                    //}

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

        inputRenderer = null;
        player = null;
        monster = null;
        battleInfo = null;
    }

	public override void SceneLoad(eScene sceneNum)
	{
		base.SceneLoad(sceneNum);

        if (sceneNum > eScene.CharacterSelect)
        {

            if (player == null)
            {
                GameObject playerObj = GameObjectManager.Instance.FindGameObjectByName("Player");
                if (playerObj!=null)
                { 
                    player= playerObj.GetComponent<Player>();
                }
			}

            if (monster == null)
            {
                GameObject monsterObj = GameObjectManager.Instance.FindGameObjectByName("Monster");
                if (monsterObj != null)
                {
                   monster = monsterObj.GetComponent<Monster>();
                }
            }

        }



        //int a = 0;
    }

}
