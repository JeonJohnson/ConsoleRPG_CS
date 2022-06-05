using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PlayerStatus;

class CharacterSelect_Scene : Scene
{
    
    public override void Initailize()
    {
        //GameObject sceneName = GameObject.Instantiate();
        //sceneName.AddRenderer<Renderer>().RenderStr = "Character Select Scene";
        GameObject sceneName = GameObjectManager.Instance.FindGameObjectByName("SceneName");
        sceneName.GetRenderer<Renderer>().RenderStr = "Character Select Scene";

        GameObject notice = GameObject.Instantiate("Notice");
        notice.transform.position.x = 2;
        notice.AddRenderer<Renderer>().RenderStr = "Plz Select ur Class";
        notice.DontDestroy();

        GameObject temp = GameObject.Instantiate();
        temp.AddRenderer<LineRenderer>();
        temp.transform.position.x = 3;

        GameObject statusMenu = GameObject.Instantiate();
        statusMenu.transform.position.x = 4;
		statusMenu.AddRenderer<Renderer>().RenderStr
			= "Num. Class  |  Hp  | dmg";

        GameObject temp2 = GameObject.Instantiate();
        temp2.AddRenderer<LineRenderer>();
        temp2.transform.position.x = 5;



        GameObject statusViewer = GameObjectManager.Instance.FindGameObjectByName("PlayerStatusViewer");
        if (statusViewer != null)
        { 
            statusViewer.SetActive(false); 
        }
        




        StatusSetting warriorStatus = new WarriorStatus();
        StatusSetting magicianStatus = new MagicianStatus();
        StatusSetting rogueStatus = new RogueStatus();

        string tempStr = "|";
        GameObject WarriorSelect = GameObject.Instantiate();
        WarriorSelect.transform.position.x = 6;
        //WarriorSelect.AddRenderer<Renderer>().RenderStr = "1. ";
        //WarriorSelect.GetRenderer<Renderer>().RenderStr += warriorStatus.status.name + " | ";
        //WarriorSelect.GetRenderer<Renderer>().RenderStr += warriorStatus.status.fullHp.ToString() + " | ";
        //WarriorSelect.GetRenderer<Renderer>().RenderStr += warriorStatus.status.dmg.ToString();
        WarriorSelect.AddRenderer<Renderer>().RenderStr = $"1. {warriorStatus.status.name}  {tempStr} {warriorStatus.status.fullHp } {tempStr} {warriorStatus.status.dmg}";


        GameObject MagicianSelect = GameObject.Instantiate();
        MagicianSelect.transform.position.x = 7;
        MagicianSelect.AddRenderer<Renderer>().RenderStr = "2. ";
        MagicianSelect.GetRenderer<Renderer>().RenderStr += magicianStatus.status.name + " | ";
        MagicianSelect.GetRenderer<Renderer>().RenderStr += magicianStatus.status.fullHp.ToString() + " | ";
        MagicianSelect.GetRenderer<Renderer>().RenderStr += magicianStatus.status.dmg.ToString();

        GameObject RogueSelect = GameObject.Instantiate();
        RogueSelect.transform.position.x = 8;
        RogueSelect.AddRenderer<Renderer>().RenderStr = $"3. {rogueStatus.status.name}  {tempStr,3} {rogueStatus.status.fullHp } {tempStr} {rogueStatus.status.dmg}";


        GameObject exitLine = GameObject.Instantiate("Exit Line");
        exitLine.transform.position.x = Defines.InputLine - 2;
        exitLine.AddRenderer<LineRenderer>();
        exitLine.DontDestroy();

        GameObject exitObj = GameObject.Instantiate("Exit Obj");
        exitObj.transform.position.x = Defines.InputLine -1;
        exitObj.AddRenderer<Renderer>().RenderStr = "9. Game Exit";
        exitObj.DontDestroy();

        GameObject player = GameObject.Instantiate("Player");
        player.AddComponent<Player>();
        player.DontDestroy();

    }

}
