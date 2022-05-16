using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface Cycle
{
	//interface ->1) 메소드, 2) 속성, 3) 인덱서, 4) 이벤트 만 선언 가능.
	//abstract Class 보다 더 정말 형태만 가춘 친구인듯

	void Initailize(); //이니셜라이저의 역할 (객체 생성시)
	void Update(); //매프레임마다
	//렌더는 렌더매니저에서!
	void Release(); //소멸자의 역할?

}
