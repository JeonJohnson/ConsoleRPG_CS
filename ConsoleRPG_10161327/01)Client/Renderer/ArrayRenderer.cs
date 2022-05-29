//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//public class ArrayRenderer : Renderer
//{

//    protected char[,] renderArray = new char[Defines.BufferX, Defines.BufferY];

//    public void SetLine(string line, int row = 0, int startPos = 0)
//    {
//        for (int i = startPos; i < line.Length; ++i)
//        {
//            renderArray[row, 0] = line[i];
//        }
//    }



//    public override void Initailize()
//    {
//        base.Initailize();
//    }

//    public override void ReadyRender()
//    {
//        base.ReadyRender();
//    }

//    public override void Release()
//    {
//        base.Release();
//    }

//    public override void Render()
//    {
//        Console.SetCursorPosition(gameObject.transform.position.x, gameObject.transform.position.y);

//      //for(int x = gameObject.transform.position.x; x <)
//    }

//    public override void Update()
//    {
//        base.Update();
//    }
//}
