using Teamproject;

namespace TeamSparta11
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // 아이템 데이터 세팅 함수
            Date.ItemDateTableSetting();

            //Static이 아닌 메서드 구현 후 각자의 작업물은 해당 아래서 인스턴스 생성후 호출해서 테스트 하시면 됩니다
            // EX) 
            //GameStart 인스턴스화
            //GameStart gameStart = new GameStart();
            //인스턴스화 된 gameStart의 Game 메서드 호출

            //gameStart.Game();

            // Battle 클래스의 생성자를 이용하여 Battle 객체를 생성

            SaveDate player = Json.JsonLoad(0);
            PlayerInfo.Player = player.Player;
            PlayerInfo.SkillList = player.SkillList;
            MonsterStatus monster = new MonsterStatus("몬스터", 1, 100, 100, 5, 5, 1, 10, 100); // 적절한 생성자로 초기화 필요
            Battle battle = new Battle(PlayerInfo.Player, monster);
            battle.BeginBattleScene(new List<MonsterStatus> { monster });


        }
    }
}