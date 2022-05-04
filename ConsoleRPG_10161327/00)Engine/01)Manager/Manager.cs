using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Manager<T> where T : new()
{
	//제네뤽 클래스
	//C++의 템플릿 클래스 비슷한거임
	
	private static T instance = default(T);
	// 근데 T값이 value가 올지 reference가 올지 모르니 default(t) 저렇게 하는거

	public static T Instance
	{
		get 
		{
			if (instance == null)
			{
				instance = new T();
				//where T : new()로 T는 기본생성자가 있을놈만 넣어라고 명시해두면
				//new 키워드로 생성가능. 
				//class, struct 등등 여러 키워드로 T값을 명시할 수 있음.
			}
			return instance;
		}
	}

}

