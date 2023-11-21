using System.Numerics;
using System.Threading;
using System.Xml.Linq;
using Teamproject;


namespace TeamSparta11
{
    internal class Battle
    {
        private PlayerStatus player;
        private MonsterStatus monster;
        private BossMonsterStatus boss;
        private List<IItem> rewards;
        static string attacker;

        public delegate void GameEvent(ICharacter character);
        public event GameEvent CharacterDie;


        public Battle(PlayerStatus player, MonsterStatus monster)
        {
            this.player =  player;
            this.monster = monster;
        }
        public Battle(PlayerStatus player, BossMonsterStatus boss, List<IItem> rewards)
        {
            this.player = player;
            this.boss = boss;
            this.rewards = rewards;
        }


        // 플레이어와 몬스터와 관련된 메소드들은 플레이어와 보스몬스터



        public void BeginBattleScene(PlayerStatus player, MonsterStatus monster)
        {
            Console.WriteLine("Battle!!");
            Console.WriteLine();
            Console.WriteLine("[몬스터 정보]");
            Console.WriteLine($"LV.{monster.Level}\t{monster.Name}\tHP{monster.HP}");
            Console.WriteLine();
            Console.WriteLine("[내정보]");
            Console.WriteLine($"LV.{player.Level}\t{player.Name}");
            Console.WriteLine($"HP {player.HP}/{player.MaxHP}");
            Console.WriteLine($"MP {player.MP}/{player.MaxMP}");
            Console.WriteLine("===============================================================");

            // 플레이어나 몬스터가 죽기 전까지 반복
            while (player.HP > 0 && monster.HP > 0)
            {
                // 플레이어와 몬스터의 스피드에 따라서 선턴 결정
                if (player.Speed > monster.Speed)
                {
                    PlayerAttackScene( player,  monster); 
                    MonsterAttackScene(player, monster); 
                }

                else if (monster.Speed > player.Speed)
                {
                    MonsterAttackScene(player, monster);
                    PlayerAttackScene( player,  monster);
                }
                else
                {
                    // 랜덤으로 공격턴 정하기
                }
            }
            // 플레이어 몬스터 둘중 하나가 죽었을때 호출
            EndBattleScene(player, monster);
        }

        public void BeginBattleScene(PlayerStatus player, BossMonsterStatus boss)
        {
            Console.WriteLine("Battle!!");
            Console.WriteLine();
            Console.WriteLine("[보스몬스터 정보]");
            Console.WriteLine($"LV.{boss.Level}\t{boss.Name}\tHP{boss.HP}");
            Console.WriteLine();
            Console.WriteLine("[내정보]");
            Console.WriteLine($"LV.{player.Level}\t{player.Name}");
            Console.WriteLine($"HP {player.HP}/{player.MaxHP}");
            Console.WriteLine($"MP {player.MP}/{player.MaxMP}");
            Console.WriteLine("===============================================================");

            // 플레이어나 몬스터가 죽기 전까지 반복
            while (player.HP > 0 && boss.HP > 0)
            {
                // 플레이어와 몬스터의 스피드에 따라서 선턴 결정
                if (player.Speed > boss.Speed)
                {
                    PlayerAttackScene(player, boss);
                    MonsterAttackScene(player, boss);
                }

                else if (monster.Speed > player.Speed)
                {
                    MonsterAttackScene(player, boss);
                    PlayerAttackScene(player, boss);
                }
                else
                {
                    // 랜덤으로 공격턴 정하기
                }
            }
            // 플레이어 몬스터 둘중 하나가 죽었을때 호출
            EndBattleScene(player, monster);
        }





        // 플레이어 턴일때 실행할 메소드
        private void PlayerAttackScene(PlayerStatus player, MonsterStatus monster)
        {
            Console.WriteLine();
            Console.WriteLine("플레이어의 턴입니다.");
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
                        attacker = "player";
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
                Thread.Sleep(1000);
            }

        }


        private void PlayerAttackScene(PlayerStatus player, BossMonsterStatus boss)
        {
            Console.WriteLine();
            Console.WriteLine("플레이어의 턴입니다.");
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
                Thread.Sleep(1000);
            }

        }






        static void BasicAttack(PlayerStatus player, MonsterStatus monster)
        {

            if (/*공격자가 몬스터이면*/)
            {
                int damage = monster.AD - player.DF; //데미지는 몬스터 공격력 - 플레이어 방어력
                player.HP -= damage;
                if (damage >= player.HP)
                {
                    player.HP = 0;
                }

            }
            else if (/*공격자가 플레이어면*/)
            {
                int damage = player.AD - monster.DF; //데미지는 플레이어 공격력 - 몬스터의 방어력
                monster.HP -= damage;
                if (damage >= monster.HP)
                {

                    monster.HP = 0;
                }
            }
        }

        static void BasicAttack(PlayerStatus player, BossMonsterStatus boss)
        {

            if (/*공격자가 보스몬스터이면*/)
            {
                int damage = boss.AD - player.DF; //데미지는 몬스터 공격력 - 플레이어 방어력
                player.HP -= damage;
                if (damage >= player.HP)
                {
                    player.HP = 0;
                }

            }
            else if (/*공격자가 플레이어면*/)
            {
                int damage = player.AD - boss.DF; //데미지는 플레이어 공격력 - 몬스터의 방어력
                boss.HP -= damage;
                if (damage >= boss.HP)
                {
                    boss.HP = 0;
                }
            }
        }







        // 스킬 공격 메소드
        public void SkillAttack(PlayerStatus player, MonsterStatus monster/*, Skills skills*/)
        {
            string skillName = Console.ReadLine();
            int damage;
            if (skillName == /*스킬배열이름*/[skillName])
            {
                int damage = monsterStatus.AD - playerStatus.DF; //데미지는 몬스터 공격력 - 플레이어 방어력
                playerStatus.HP -= damage;
                if (damage >= playerStatus.HP)
                {
                    playerStatus.HP = 0;
                    Console.WriteLine($"{playerStatus.Name}이 쓰러졌습니다");

                }

            }
             
        }
        public void SkillAttack(PlayerStatus playerStatus, MonsterStatus monsterStatus, Skill skill, Date data)
        {
            int skillNum = int.Parse(Console.ReadLine());
            int damage;
            if (skillNum == PlayerInfo.SkillList[skillNum])
            {
                if (skill.Cost <= playerStatus.MP)
                {

                    if (attacker == "monster")
                    {
                        damage = monster.AD - player.DF; //데미지는 몬스터 공격력 - 플레이어 방어력
                        player.HP -= damage;
                        if (damage >= player.HP)
                        {

                            player.HP = 0;

                        }

                    }
                    else if (attacker == "player")
                    {

                        damage = player.AD - monster.DF; //데미지는 플레이어 공격력 - 몬스터의 방어력
                        monster.HP -= damage;
                        player.MP -= skills.MP;                        
                        if (damage >= monster.HP)
                        {
                            monster.HP = 0;

                        }
                    }
                }
                else
                {
                    Console.WriteLine("MP가 부족합니다");
                }
            }
        }


        public void SkillAttack(PlayerStatus player, BossMonsterStatus boss/*, Skills skills*/)
        {
            string skillName = Console.ReadLine();
            int damage;
            if (skillName == /*스킬배열이름*/[skillName])
            {
                if (/*skills.MP <= playerStatus.MP*/)
                {

                    if (/*공격자가 보스몬스터이면 */)
                    {
                        damage = boss.AD - player.DF; //데미지는 몬스터 공격력 - 플레이어 방어력
                        player.HP -= damage;
                        if (damage >= player.HP)
                        {
                            player.HP = 0;
                        }

                    }
                    else if (/*공격자가 플레이어면*/)
                    {
                        damage = player.AD - boss.DF; //데미지는 플레이어 공격력 - 몬스터의 방어력
                        boss.HP -= damage;
                        player.MP -= skills.MP;
                        if (damage >= boss.HP)
                        {
                            boss.HP = 0;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("MP가 부족합니다");
                }
            }
        }





        // 몬스터의 턴 메소드
        // 일반몹
        private void MonsterAttackScene(PlayerStatus player, MonsterStatus monster)
        {
            Console.WriteLine();
            Console.WriteLine("몬스터의 턴입니다.");
            Console.WriteLine();
            BasicAttack(player, monster);
            Thread.Sleep(1000);
        }
        // 보스몹
        private void MonsterAttackScene(PlayerStatus player, BossMonsterStatus boss)
        {
            Console.WriteLine();
            Console.WriteLine("보스몬스터의 턴입니다.");
            Console.WriteLine();
            BasicAttack(player, boss);
            Thread.Sleep(1000);
        }



        // 몬스터와의 배틀이 종료된 후에 실행할 메소드
        private void EndBattleScene(PlayerStatus player, MonsterStatus monster) //
        {
            if (player.HP > 0)
            {
                Console.WriteLine($"{player.Name}의 승리, {monster.Name}의 패배입니다.");
                // 경험치를 주는 내용
            }
            else
            {
                Console.WriteLine($"{monster.Name}의 승리, {player.Name}의 패배입니다.");
            }
        }

        // 보스 몬스터와의 배틀이 종료된 후에 실행할 메소드
        private void EndBattleScene(PlayerStatus player, BossMonsterStatus boss) //
        {
            if (player.HP > 0)
            {
                Console.WriteLine($"{player.Name}의 승리, {boss.Name}의 패배입니다.");
                // 보상을 주는 내용, 경험치를 주는 내용
            }
            else
            {
                Console.WriteLine($"{boss.Name}의 승리, {player.Name}의 패배입니다.");
            }
        }

    }
}