# ConsoleRPG_CS
 22_1_Semester
------------------- 계획 ------------------- 
2022-05-24	기본 창 그리기
		창크기 64*32




15:55 2022-05-30	키입력 받기 + 렌더러에서 줄 넘김 문자열 확인하기



------------------- 작업 내역 ------------------- 
00:32 2022-05-31		InputManager / 씬 체인지 확인 됨.
			Struct들 만듦.
	내일 할거	 	Unit 클래스 만들기
			Character select Scene 에서 직업정하기
		
00:12 2022-06-01		TitleScene, CharacterScene 만듦.
			Status 완성.
	내일 할거		-씬 바뀌는 델리게이트 만들기
			-player 만들기
			-던전 만들기
			-모든 씬 흐름은 완성하기
14:30 2022-06-01		씬 체인지 event(델리게이트)로 만듦.




------------------- 기획 ------------------- 



가로 64 세로 32 의 크기 (버퍼)

1. reayRender 시점에서 각 렌더러는 렌더매니저로 자신을 보냄.
2. 보내진 렌더러들은 자신의 렌더큐에 맞는 곳으로 들어감.
3. Render시점 랜더매니저는 저번 프레임의 렌더 버퍼를 저장함.
4. 렌더매니저는 각 렌더큐의 렌더러들의 정보, transform위치를 받아와 버퍼에 쭉 저장.
5. 완성된 현재 렌더 버퍼와 그전 렌더 버퍼를 비교해서 다른부분만 다시 출력해주기.

렌더러 -> transform.position 위치에다가 커서 놔두고 라인 혹은 배열 출력.


렌더러 두 종류
	인게임 출력창에서 출력할 애 / 입력 출력창에 출력할 애인지?
	라인을 출력할 애 / char 배열 출력할 애인지
				=> char 배열도 2차원 배열로 할것인지 다중배열로 처리할 것인지.

무적권 있어야 하는 오브젝트


세로 22 까지 인게임 출력창 UI오브젝트. 
	=> 0,0 ~ 64,22

현재 씬 이름 알려줄 UI 오브젝트
	=> 1,1 ~ 1,63

세로 23~32까지는 안내문구 + 입력 창 UI오브젝트
	=> 0,23 ~ 64,32

씬이 바뀌더라도 player gameObject는 죽으면 안됨.
player같은 경우 GameObject내에 Component로 player status, inventory 있어야하고
					render은 status 쭉 렌더 해줄꺼

씬
00)타이틀메뉴, 01)캐릭터 설정창, 02)메인메뉴(마을), 03)인벤토리, 04)상점, 05)던전(3개)

메인메뉴 -> 테두리 오브젝트 한개



