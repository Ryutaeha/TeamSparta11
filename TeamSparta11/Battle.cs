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
            while (true)
            {
                int userSelect = Date.userSelect();
                switch (userSelect)
                {
                    case 1:
                        BasicAttack();
                        break;
                    case 2:
                        //스킬 목록 보여주고 그 안에서 또 선택 => SkillNum
                        break;
                    case 3:
                        //아이템 사용 함수
                        break;
                    case 4:
                        //내 상태보기 함수
                        return;
                    default:
                        Console.WriteLine("번호를 다시 입력해주세요");
                        break;
                }
            }

        }

        public void BasicAttack(/*Player player, Monster monster*/)
        {
            if (/*player.Hp != 0 && monster.Hp != 0*/)
            {
                if (/*공격자가 몬스터이면*/)
                {
                    /*damage == monster.AD - player.def;*/ //데미지는 몬스터 공격력 - 플레이어 방어력
                    //player.Hp -= damage;
                    if (/*damage >= player.Hp*/)
                    {
                        //player.Hp = 0;
                        //IsDead == true;
                    }

                }
                else if (/*공격자가 플레이어면*/)
                {
                    /*damage == player.AD - monster.def;*/ //데미지는 플레이어 공격력 - 몬스터의 방어력
                                                           //monster.Hp -= damage;
                    if (/*damage >= monster.Hp*/)
                    {
                        //monster.Hp = 0;
                        //IsDead == true;
                    }
                }
            }
        }
        public void SkillAttack(/*Player player, Monster monster, Skills skills*/)
        {

            string skillName = Console.ReadLine();
            if (skillName == /*스킬배열이름*/[skillName])
            {
                if (/*skill.Mp <= player.Mp*/)
                {

                    if (/*공격자가 몬스터이면 */)
                    {
                        /*damage == monster.AD - player.def;*/ //데미지는 몬스터 공격력 - 플레이어 방어력
                                                               //player.Hp -= damage;
                        if (/*damage >= player.Hp*/)
                        {
                            //player.Hp = 0;
                            //IsDead == true;
                        }

                    }
                    else if (/*공격자가 플레이어면*/)
                    {
                        /*damage == player.AD - monster.def;*/ //데미지는 플레이어 공격력 - 몬스터의 방어력
                                                               //monster.Hp -= damage;
                                                               //player.Mp -= skill.mp;                        
                        if (/*damage >= monster.Hp*/)
                        {
                            //monster.Hp = 0;
                            //IsDead == true;
                        }
                    }

                }
                else
                {
                    Console.WriteLine("MP가 부족합니다");
                }
            }
        }
    }
}