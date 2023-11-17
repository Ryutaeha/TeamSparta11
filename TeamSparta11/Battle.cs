using System.Numerics;
using System.Threading;
using Teamproject;

namespace TeamSparta11
{
    public class Battle
    {
        public void BeginBattleScene(PlayerStatus playerStatus, MonsterStatus monsterStatus)
        {
            Console.WriteLine("Battle!!");
            Console.WriteLine();



            Console.WriteLine($"LV.{monsterStatus.Level}\t{monsterStatus.Name}\tHP{monsterStatus.HP}");

            Console.WriteLine();
            Console.WriteLine("[내정보]");

            Console.WriteLine($"LV.{playerStatus.Level}\t{playerStatus.Name}");

            Console.WriteLine($"HP {playerStatus.HP}/{playerStatus.MaxHP}");

            Console.WriteLine($"MP {playerStatus.MP}/{playerStatus.MaxMP}");

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
                        BasicAttack(playerStatus, monsterStatus);
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

        static void BasicAttack(PlayerStatus playerStatus, MonsterStatus monsterStatus)
        {

            if (/*공격자가 몬스터이면*/)
            {
                int damage = monsterStatus.AD - playerStatus.DF; //데미지는 몬스터 공격력 - 플레이어 방어력
                playerStatus.HP -= damage;
                if (damage >= playerStatus.HP)
                {
                    playerStatus.HP = 0;
                    playerStatus.IsDead = true;
                }

            }
            else if (/*공격자가 플레이어면*/)
            {
                int damage = playerStatus.AD - monsterStatus.DF; //데미지는 플레이어 공격력 - 몬스터의 방어력
                monsterStatus.HP -= damage;
                if (damage >= monsterStatus.HP)
                {
                    monsterStatus.HP = 0;
                    playerStatus.IsDead = true;
                }
            }
        }
        public void SkillAttack(PlayerStatus player, MonsterStatus monster/*Skills skills*/)
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