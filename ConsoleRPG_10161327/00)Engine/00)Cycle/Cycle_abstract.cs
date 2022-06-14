using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract	class Cycle_abstract
	{
	//c#에서는 다중상속을 못함...
		public abstract void Initailize();
		public abstract void Update();
		public abstract void Render();
		public abstract void Release();

	}
