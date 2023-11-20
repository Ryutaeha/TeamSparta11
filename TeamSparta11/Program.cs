namespace TeamSparta11
{
    internal class Program
    {
        //새로 만들거나 로드해올 때 끌어다 쓸 객체
        public static Test.Player player = new ();
        //저장 슬롯
        public static int saveSlot;
        static void Main(string[] args)
        {
           
            //Static이 아닌 메서드 구현 후 각자의 작업물은 해당 아래서 인스턴스 생성후 호출해서 테스트 하시면 됩니다
            // EX) 
            //GameStart 인스턴스화
            //GameStart gameStart = new GameStart();
            //인스턴스화 된 gameStart의 Game 메서드 호출
            //gameStart.Game();
        }
    }
}