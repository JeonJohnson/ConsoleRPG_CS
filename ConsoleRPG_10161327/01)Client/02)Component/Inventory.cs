using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Inventory : Component
{

	Player playerScript = null;

	Renderer inventoryRenderer = null;

	Item[] equippedItems;
	
	List<Item> itemList;
	public List<Item> ItemList
	{
		get { return itemList; }
	}

	string line = "";
	public void AddItem(Item item)
	{
		eItemKind itemKind = item.status.kind;

		itemList.Add(item);
	}

	public void InputChecker()
	{


		int i = InputManager.Instance.GetInputValue();

		if (i == 8)
		{
			SceneManager.Instance.SceneChange(eScene.MainMenu);
		}
		if (i == 9)
		{ 
			GameManager.Instance.IsQuit = true; 
		}


		if (i > itemList.Count || i < 0)
		{ return; }

		if (itemList[i-1].status.isEquipped == true)
		{//아이템 장착 해제
			if (itemList[i - 1] == equippedItems[(int)itemList[i - 1].status.kind])
			{
				equippedItems[(int)itemList[i - 1].status.kind].status.isEquipped = false;
				equippedItems[(int)itemList[i - 1].status.kind] = null;


				playerScript.EquippedItem(itemList[i - 1].status, -1);
			}
		}
		else
		{//아이템 장착
			if (itemList[i - 1].status.requiredLv > playerScript.LV)
			{
				return;
			}

			if (equippedItems[(int)itemList[i - 1].status.kind] == null)
			{
				itemList[i-1].status.isEquipped = true;
				equippedItems[(int)itemList[i - 1].status.kind] = itemList[i - 1];


				playerScript.EquippedItem(itemList[i - 1].status);
			}
		}
	}
	public override void Initailize()
	{
		base.Initailize();

		equippedItems = new Item[(int)eItemKind.End];

		for (int i = 0; i < (int)eItemKind.End; ++i)
		{
			equippedItems[i] = null;
		}

		itemList = new List<Item>();

		Item test = new Weapon.Ak47();
		itemList.Add(test);
		Item test3 = new Weapon.Sword();
		itemList.Add(test3);
		Item test2 = new Armor.GucciSet();
		itemList.Add(test2);

		inventoryRenderer = this.gameObject.AddRenderer<Renderer>();

		for (int i = 0; i < Defines.BufferX; ++i)
		{
			line += '*';
		}

		playerScript = GameObjectManager.Instance.FindGameObjectByName("Player").GetComponent<Player>();
	}


	public override void Update()
	{

		if (SceneManager.Instance.CurScene.SceneNum == eScene.Inventory)
		{
			InputChecker();
		}

		string[] equipItemStr = new string[(int)eItemKind.End];
		equipItemStr[(int)eItemKind.Weapon] = "Weapon : ";
		equipItemStr[(int)eItemKind.Armor] =  "Armor  : ";

		for (int i = 0; i < (int)eItemKind.End; ++i)
		{
			if (equippedItems[i] == null)
			{
				equipItemStr[i] += "has no Item ";

				continue;
			}
			
			equipItemStr[i] += string.Format("{0} | +{1} Dmg | +{2} Hp", equippedItems[i].status.name, equippedItems[i].status.dmg, equippedItems[i].status.hp);
		}

		inventoryRenderer.RenderStr = equipItemStr[0] + "\n" + equipItemStr[1];
		inventoryRenderer.RenderStr += "\n";
		inventoryRenderer.RenderStr += line;


		string haveItems = /*"| No. |Lv. |Type |Name |Dmg |Hp |Price |Equip |\n"*/"";
		//haveItems += line;

		if (itemList.Count == 0)
		{ haveItems += "u have no items."; }
		else
		{
			for (int i = 0; i < itemList.Count; ++i)
			{
				Structs.ItemStatus k = itemList[i].status;
				haveItems += $"No.{i+1} | Lv.{k.requiredLv} | {k.kind} | {k.name} | Dmg:{k.dmg} | Hp:{k.hp} | {k.price} \\ |";
				if (k.isEquipped)
				{
					haveItems += " Equip:O";
				}
				else
				{ haveItems += " Equip:X"; }

				if (i != itemList.Count - 1)
				{ haveItems += "\n"; }
			}
		}

		haveItems += "\n";
		haveItems += line;

		//	inventoryRenderer.RenderStr += ";
		inventoryRenderer.RenderStr += haveItems;

	}

	public override void ReadyRender()
	{
		base.ReadyRender();
	}

	public override void Release()
	{
		base.Release();
		playerScript = null;

		inventoryRenderer = null;
		
		for (int i = 0; i < equippedItems.Length; ++i)
		{ equippedItems[i] = null; }

		itemList.Clear();
		itemList = null;
		//아이템 리스트 null 해주기
	}

	public override void SceneLoad(eScene sceneNum)
	{
		base.SceneLoad(sceneNum);

		if (sceneNum != Enums.eScene.Inventory)
		{
			gameObject.SetActive(false);
			//inventoryRenderer.Enabled = false;
		}
		else 
		{
			gameObject.SetActive(true);
			//inventoryRenderer.Enabled = true; 
		}
	}

}
