﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SceneManager : Manager<SceneManager>, Cycle
{

	Scene curScene;
	Scene nextScene;

	Dictionary<string, Scene> sceneDictionary;

	

	/// <summary>
	/// 현재씬의 Cycle을 돌려줌.
	/// 각 씬은 그 씬의 GameObject들의 Cycle을 돌려줄꺼임.
	/// =>GameObjectManager이 필요할까? 아니면 SceneManager에서 관리할ㄲㅏ?
	/// =>GameObjectManager ㄱㄱㄱㄱ 
	/// </summary>
	public void Awake()
	{
	}

	public void Start()
	{ 
	

	}

	public void Update()
	{

	}
	public void Release()
	{
	}
	public void Render()
	{
	}

}
