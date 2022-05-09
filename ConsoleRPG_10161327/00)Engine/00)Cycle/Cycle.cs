using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface Cycle
{
	//interface ->1) 메소드, 2) 속성, 3) 인덱서, 4) 이벤트 만 선언 가능.
	//abstract Class 보다 더 정말 형태만 가춘 친구인듯

	void Awake(); //이니셜라이저의 역할
	void Start();
	void Update();
	//void LateUpdate();
	void Render();
	void Release(); //소멸자의 역할?



}
