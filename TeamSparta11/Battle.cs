namespace TeamSparta11
{
    public class Battle
    {
        public void BeginBattleScene()
        {
            Console.WriteLine("Battle!!");
            Console.WriteLine();


            //캐릭터나 몬스터 클레스 다 만들면 아래 주석들 주석 풀고 확인해주세요
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
            int userSelect = Date.userSelect();
            switch (userSelect)
            {
                case 1:
                    //공격함수
                    break;
                case 2:
                    //스킬사용
                    break;
                case 3:
                    //아이템 사용
                    break;
                case 4:
                    //내 상태보기 함수
                    break; 
                default:
                    Console.WriteLine("번호를 다시 입력해주세요");
                    break;
            }

        }
    }
}