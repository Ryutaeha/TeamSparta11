namespace TeamSparta11
{
    public class Battle
    {
        public void BeginBattleScene()
        {
            Console.WriteLine("Battle!!");
            Console.WriteLine();

            //Console.WriteLine($"LV.{monsterStatus.level}\t{monsterStatus.name}\tHP{monsterStatus,hp}");
            Console.WriteLine("LV. 2  미니언  HP 15");

            Console.WriteLine();
            Console.WriteLine("[내정보]");

            //Console.WriteLine($"LV.{playerStatus.level}\t{playerStatus.name}\t{playerStatus.name}");
            Console.WriteLine("LV.1  Chad  (전사)");

            //Console.WriteLine($"HP {playerStatus.hp}/{playerStatus.maxHp}");
            Console.WriteLine("HP 100/100");

            //Console.WriteLine($"MP {playerStatus.mp}/{playerStatus.maxMp}");
            Console.WriteLine("MP 30/30");

            Console.WriteLine();
            Console.WriteLine("1, 공격\t2. 스킬\n3.아이템 사용\t4. 내 상태 보기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력히세요.");
            Console.Write(">>");
            string? select = Console.ReadLine();
            if(select == "1")
            {
                //공격 함수
            }
            else if (select == "2")
            {
                //스킬 사용 함수
            }
            else if(select == "3")
            {
                //아이템 사용 함수
            }
            else if(select == "4")
            {
                //내 상태 보기 함수
            }
            else
            {
                
            }

        }
    }
}