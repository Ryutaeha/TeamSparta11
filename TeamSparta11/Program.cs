using Teamproject;

namespace TeamSparta11
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // 아이템 데이터 세팅 함수
            Date.ItemDataTableSetting();
           
            //Static이 아닌 메서드 구현 후 각자의 작업물은 해당 아래서 인스턴스 생성후 호출해서 테스트 하시면 됩니다
            // EX) 
            //GameStart 인스턴스화
            //GameStart gameStart = new GameStart();
            //인스턴스화 된 gameStart의 Game 메서드 호출


            //gameStart.Game();

        }
    }
}