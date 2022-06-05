using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Enums;

public class Shop : Component
{

	Renderer shopRenderer;

	SortedDictionary<eItemKind, List<Item>> shopItemList;

	public override void Initailize()
	{
		base.Initailize();

		shopItemList = new SortedDictionary<eItemKind, List<Item>>();

		shopRenderer = this.gameObject.AddRenderer<Renderer>();
	}
	public override void Update()
	{

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
	}

	
}
