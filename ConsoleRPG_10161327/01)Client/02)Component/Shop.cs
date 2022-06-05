using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Enums;

public class Shop : Component
{
	Renderer shopRenderer;
	List<Item>[] shopItemList;

	eShopState curShopState = eShopState.End;

	Inventory inventoryScript = null;
	Player playerScript = null;
	public void WareHousing()
	{
		shopItemList[(int)eItemKind.Weapon] = new List<Item>();
		shopItemList[(int)eItemKind.Weapon].Add(new Weapon.WoodStick());
		shopItemList[(int)eItemKind.Weapon].Add(new Weapon.Sword());
		shopItemList[(int)eItemKind.Weapon].Add(new Weapon.Ak47());

		shopItemList[(int)eItemKind.Armor] = new List<Item>();
		shopItemList[(int)eItemKind.Armor].Add(new Armor.RagsSet());
		shopItemList[(int)eItemKind.Armor].Add(new Armor.LeatherSet());
		shopItemList[(int)eItemKind.Armor].Add(new Armor.GucciSet());
	}

	public void ShopSelectInput()
	{
		//1. 웨픈, 2. 아멀, 3. 셀, 
		int input = InputManager.Instance.GetInputValue();

		switch (input)
		{
			case 1:
				{
					curShopState = eShopState.Weapon_Buy;
					GameObject sceneNameObj = GameObjectManager.Instance.FindGameObjectByName("SceneName");
					sceneNameObj.GetRenderer<Renderer>().RenderStr = "Shop - Weapon";

					GameObject notice = GameObjectManager.Instance.FindGameObjectByName("Notice");
					notice.GetRenderer<Renderer>().RenderStr = "Input desired Weapon Item number";

				}
				break;

			case 2:
				{
					curShopState = eShopState.Armor_Buy;
					GameObject sceneNameObj = GameObjectManager.Instance.FindGameObjectByName("SceneName");
					sceneNameObj.GetRenderer<Renderer>().RenderStr = "Shop - Armor";

					GameObject notice = GameObjectManager.Instance.FindGameObjectByName("Notice");
					notice.GetRenderer<Renderer>().RenderStr = "Input desired Armor Item number";

				}
				break;

			case 3:
				{
					curShopState = eShopState.Sell;
					GameObject sceneNameObj = GameObjectManager.Instance.FindGameObjectByName("SceneName");
					sceneNameObj.GetRenderer<Renderer>().RenderStr = "Shop - Sell";

					GameObject notice = GameObjectManager.Instance.FindGameObjectByName("Notice");
					notice.GetRenderer<Renderer>().RenderStr = "Input Item number that u want to sell";

					inventoryScript.gameObject.SetActive(true);

				}
				break;

			case 8:
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

	public void ShoppingInput()
	{
		int input = InputManager.Instance.GetInputValue();

		if (input == 8)
		{
			SceneManager.Instance.SceneChange(eScene.MainMenu);
		}

		if (input == 9)
		{
			GameManager.Instance.IsQuit = true;
		}

		if (input < 0 || input > shopItemList[(int)curShopState - 1].Count)
		{
			return;
		}
	

		if (shopItemList[(int)curShopState-1][input-1] != null)
		{//구매하기
			Structs.ItemStatus tempStatus = shopItemList[(int)curShopState - 1][input - 1].status;

			if (playerScript.Gold >= tempStatus.price)
			{
				playerScript.Buy(tempStatus.price);
				inventoryScript.AddItem(shopItemList[(int)curShopState - 1][input - 1]);
				shopItemList[(int)curShopState - 1][input - 1] = null;
			}
		}

	}

	public void Resell()
	{
		int input = InputManager.Instance.GetInputValue();

		if (input == 8)
		{
			SceneManager.Instance.SceneChange(eScene.MainMenu);
		}

		if (input == 9)
		{
			GameManager.Instance.IsQuit = true;
		}

		List<Item> inventoryList = inventoryScript.ItemList;

		if (input < 0 || input >= inventoryList.Count)
		{
			return;
		}

		if (inventoryList[input - 1] != null && inventoryList[input - 1].status.isEquipped == false)
		{//판매하기
			Structs.ItemStatus tempStatus = inventoryList[input - 1].status;

			playerScript.Sell(tempStatus.price);
			inventoryList.Remove(inventoryList[input - 1]);
		}

	}

	public override void Initailize()
	{
		base.Initailize();

		shopItemList = new List<Item>[(int)eItemKind.End];
		WareHousing();

		shopRenderer = this.gameObject.AddRenderer<Renderer>();

		inventoryScript = GameObjectManager.Instance.FindGameObjectByName("Inventory").GetComponent<Inventory>();
		playerScript = GameObjectManager.Instance.FindGameObjectByName("Player").GetComponent<Player>();

	}
	public override void Update()
	{
		switch (curShopState)
		{
			case eShopState.Select:
				{ 
					shopRenderer.RenderStr = "1. Weapon\n2. Armor\n3. Sell";
					ShopSelectInput();
				}
				break;

			case eShopState.Weapon_Buy:
				{

					ShoppingInput();


					shopRenderer.RenderStr = "";

					for (int i = 0; i < shopItemList[(int)eItemKind.Weapon].Count; ++i)
					{
						if (shopItemList[(int)eItemKind.Weapon][i] == null)
						{
							continue;
						}
						Structs.ItemStatus k = shopItemList[(int)eItemKind.Weapon][i].status;

						shopRenderer.RenderStr += $"No.{i + 1} | Lv.{k.requiredLv} | {k.kind} | {k.name} | Dmg:{k.dmg} | Hp:{k.hp} | {k.price} \\ |\n";
					}
				
				}
				break;

			case eShopState.Armor_Buy:
				{

					ShoppingInput();

					shopRenderer.RenderStr = "";

					for (int i = 0; i < shopItemList[(int)eItemKind.Armor].Count; ++i)
					{
						if (shopItemList[(int)eItemKind.Armor][i] == null)
						{
							continue;
						}
						Structs.ItemStatus k = shopItemList[(int)eItemKind.Armor][i].status;

						shopRenderer.RenderStr += $"No.{i + 1} | Lv.{k.requiredLv} | {k.kind} | {k.name} | Dmg:{k.dmg} | Hp:{k.hp} | {k.price} \\ |\n";
					}
				}
				break;

			case eShopState.Sell:
				{
					shopRenderer.RenderStr = "";

					Resell();
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

		shopRenderer = null;

		for (int i = 0; i < (int)eItemKind.End; ++i)
		{
			shopItemList[i].Clear();
			shopItemList[i] = null;
		}

		//eShopState curShopState = eShopState.End;

		inventoryScript = null;
		playerScript = null;
	}

	public override void SceneLoad(eScene sceneNum)
	{
		base.SceneLoad(sceneNum);

		if (sceneNum != eScene.Shop)
		{
			gameObject.SetActive(false);
			shopRenderer.Enabled = false;

		}
		else 
		{
			gameObject.SetActive(true);
			shopRenderer.Enabled = true;
			curShopState = eShopState.Select;
		}

	}

	
}
