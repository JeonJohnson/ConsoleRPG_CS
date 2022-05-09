using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Scene : Cycle
{
	public Scene()
	{

	}

    public void Awake()
    {
    }
    public void Start()
    {
        GameObjectManager.Instance.Start();
    }
    public void Update()
    {
        GameObjectManager.Instance.Update();
    }

    public void Render()
    {
    }

    public void Release()
    {
    }
}

