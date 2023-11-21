using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using System.Threading;
using System.Xml.Linq;
using Teamproject;


namespace TeamSparta11
{
    internal class Battle
    {
        private PlayerStatus Player;
        private MonsterStatus monster;
        private BossMonsterStatus boss;
        private MonsterStatus currentTarget;
        private List<IItem> rewards;

        public Battle(PlayerStatus player, MonsterStatus monster)
        {
            this.Player = player;
            this.monster = monster;
        }
        public Battle(PlayerStatus player, BossMonsterStatus boss, List<IItem> rewards)
        {
            this.Player = player;
            this.boss = boss;
            this.rewards = rewards;
        }


        // 플레이어와 몬스터와 관련된 메소드들은 플레이어와 보스몬스터



        public void BeginBattleScene(List<MonsterStatus> monsters)
        {
            while (true) 
            {
                Console.WriteLine("Battle!!");
                Console.WriteLine();
                Console.WriteLine("[내정보]");
                Console.WriteLine($"LV.{PlayerInfo.Player.Level}\t{PlayerInfo.Player.Name}");
                Console.WriteLine($"HP {PlayerInfo.Player.HP}/{PlayerInfo.Player.MaxHP}");
                Console.WriteLine($"MP {PlayerInfo.Player.MP}/{PlayerInfo.Player.MaxMP}");
                Console.WriteLine();

                Console.WriteLine("[몬스터 정보]");

                currentTarget = ChooseTarget(monsters);
                for (int i = 0; i < monsters.Count; i++)
                {
                    Console.WriteLine($"LV.{monsters[i].Level}\t{monsters[i].Name}\tHP{monsters[i].HP}");
                }
                Console.WriteLine("===============================================================");


                /*if (PlayerInfo.Player.Speed > currentTarget.Speed)

                {*/

                    PlayerBasicAttack(currentTarget);
                    MonsterBasicAttack(monster);

                /*}

                else if (currentTarget.Speed > PlayerInfo.Player.Speed)
                {
                    MonsterBasicAttack(monster);
                    MonsterBasicAttack(currentTarget);

                }*/

                // 플레이어 몬스터 둘중 하나가 죽었을때 호출
                if (PlayerInfo.Player.HP == 0 || monsters[0].HP == 0)
                {
                    EndBattleScene(currentTarget);
                    break;
                }
            }
            
        }

        private MonsterStatus ChooseTarget(List<MonsterStatus> monsters)
        {
            Console.WriteLine("대상을 선택하세요:");

            for (int i = 0; i < monsters.Count; i++)
            {
                Console.WriteLine($"{i + 1}. LV.{monsters[i].Level}\t{monsters[i].Name}\tHP{monsters[i].HP}");
            }

            int UserSelect = Date.UserSelect();
            if (UserSelect >= 1 && UserSelect <= monsters.Count)
            {
                PlayerBasicAttack(monsters[UserSelect - 1]);
                return monsters[UserSelect - 1];
            }
            Console.WriteLine("첫 번째 몬스터를 선택합니다.");
            return monsters.FirstOrDefault();
        }



        public void BeginBattleScene(BossMonsterStatus boss)
        {
            Console.WriteLine("Battle!!");
            Console.WriteLine();
            Console.WriteLine($"플레이어 {PlayerInfo.Player.Name}은(는) 스테이지[{stage}]에 도착했습니다!");
            Console.WriteLine();
            Console.WriteLine("[보스몬스터 정보]");
            Console.WriteLine($"LV.{boss.Level}\t{boss.Name}\tHP{boss.HP}");
            Console.WriteLine();
            Console.WriteLine("[내정보]");
            Console.WriteLine($"LV.{PlayerInfo.Player.Level}\t{PlayerInfo.Player.Name}");
            Console.WriteLine($"HP {PlayerInfo.Player.HP}/{PlayerInfo.Player.MaxHP}");
            Console.WriteLine($"MP {PlayerInfo.Player.MP}/{PlayerInfo.Player.MaxMP}");
            Console.WriteLine("===============================================================");

            // 플레이어나 몬스터가 죽기 전까지 반복
            while (PlayerInfo.Player.HP > 0 && boss.HP > 0)
            {
                // 플레이어와 몬스터의 스피드에 따라서 선턴 결정
                if (PlayerInfo.Player.Speed > boss.Speed)
                {
                    PlayerAttackScene(boss);
                    MonsterAttackScene(monster);
                }
                else if (monster.Speed > PlayerInfo.Player.Speed)
                {
                    MonsterAttackScene(boss);
                    PlayerAttackScene(boss);
                }
            }
            // 플레이어 몬스터 둘중 하나가 죽었을때 호출
            EndBattleScene(monster);
        }

        // 플레이어 턴일때 실행할 메소드
        /*private void PlayerAttackScene(MonsterStatus monster)
        {
            PlayerTurnText();

        }*/

        private void PlayerAttackScene(BossMonsterStatus boss)
        {
            PlayerTurnText();
        }

        private bool IsPlayerTurn(MonsterStatus monster)
        {
            return PlayerInfo.Player.Speed >= monster.Speed;
        }
        private bool IsPlayerTurn(BossMonsterStatus boss)
        {
            return PlayerInfo.Player.Speed >= boss.Speed;
        }





        private int PlayerBasicAttack(MonsterStatus target)
        {
            int damage = PlayerInfo.Player.AD - target.DF; // 데미지는 플레이어 공격력 - 몬스터의 방어력           
            monster.HP -= damage;
            Console.WriteLine($"{PlayerInfo.Player.Name}의 공격! {target.Name}은 {damage}의 피해를 입었습니다");
            if (target.HP <= 0)
            {
                target.HP = 0;
            }
            return damage;         
        }

        private int MonsterBasicAttack(MonsterStatus monster)
        {
            int damage = monster.AD - PlayerInfo.Player.DF; // 데미지는 몬스터 공격력 - 플레이어 방어력
            PlayerInfo.Player.HP -= damage;

            Console.WriteLine($"{monster.Name}의 공격! {PlayerInfo.Player.Name}은 {damage}의 피해를 입었습니다");
            if(PlayerInfo.Player.HP <= 0)
            {
                PlayerInfo.Player.HP = 0;
            }
            return damage;
        }

        private void BossBasicAttack(BossMonsterStatus boss)
        {
            int damage = boss.AD - PlayerInfo.Player.DF; //데미지는 몬스터 공격력 - 플레이어 방어력
            PlayerInfo.Player.HP -= damage;
            if (damage >= PlayerInfo.Player.HP)
            {
                PlayerInfo.Player.HP = 0;
            }
        }



        // 몬스터의 턴 메소드
        // 일반몹
        private void MonsterAttackScene(MonsterStatus monster)
        {
            Console.WriteLine();
            Console.WriteLine("몬스터의 턴입니다.");
            Console.WriteLine();
            MonsterBasicAttack(monster);

            //Thread.Sleep(1000);
        }
        // 보스몹
        private void MonsterAttackScene(BossMonsterStatus boss)
        {
            Console.WriteLine();
            Console.WriteLine("보스몬스터의 턴입니다.");
            Console.WriteLine();
            BossBasicAttack(boss);
            Thread.Sleep(1000);
        }

        // 몬스터와의 배틀이 종료된 후에 실행할 메소드
        private void EndBattleScene(MonsterStatus target)
        {
            if (PlayerInfo.Player.HP > 0)
            {
                Console.WriteLine($"{PlayerInfo.Player.Name}의 승리, {target.Name}의 패배입니다.");
                PlayerInfo.Player.NextEXP += target.EXP;
            }
            else
            {
                Console.WriteLine($"{monster.Name}의 승리, {PlayerInfo.Player.Name}의 패배입니다.");
            }
        }

        // 보스 몬스터와의 배틀이 종료된 후에 실행할 메소드
        private void EndBattleScene(BossMonsterStatus boss)
        {
            if (PlayerInfo.Player.HP > 0)
            {
                Console.WriteLine($"{PlayerInfo.Player.Name}의 승리, {boss.Name}의 패배입니다.");
                PlayerInfo.Player.NextEXP += boss.EXP;
            }
            else
            {
                Console.WriteLine($"{boss.Name}의 승리, {PlayerInfo.Player.Name}의 패배입니다.");
            }
        }


        private void PlayerTurnText()
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
                int UserSelect = Date.UserSelect();
                switch (UserSelect)
                {
                    case 1:
                        PlayerBasicAttack(monster);
                        break;
                    case 2:
                        //스킬 목록 보여주고 그 안에서 또 선택 => SkillNum
                        break;
                    case 3:
                        //아이템 사용 함수
                        break;
                    case 4:
                        //내 상태보기 함수
                        break;
                    default:
                        Console.WriteLine("번호를 다시 입력해주세요");
                        break;
                }
                Thread.Sleep(1000);
            }
        }


        //몬스터 생성과 스폰 메소드
        public List<MonsterStatus> SpawnMonster(int stage)
        {
            List<MonsterStatus> monsters = new List<MonsterStatus>();
            Random random = new Random();
            int randomCount = random.Next(1, 4);

            // 스테이지가 1 ~ 5일 동안은 랜덤한 고블린을 1마리에서 3마리까지 랜덤으로 생성.
            if (stage > 0 && stage <= 5)
            {
                for (int i = 0; i < randomCount; i++)
                {
                    monsters.Add(GetRandomGoblin());
                }
                
            }
            // 스테이지가 6 ~ 10일 동안은 랜덤한 골렘을 1마리에서 3마리까지 랜덤으로 생성.
            else if (stage > 5 && stage <= 10)
            {
                for (int i = 0; i < randomCount; i++)
                {
                    monsters.Add(GetRandomGolem());
                }
               
            }
            // 스테이지가 10 ~ 15일 동안은 랜덤한 드래곤을 1마리에서 3마리까지 랜덤으로 생성.
            else if (stage > 10 && stage <= 15)
            {
                for (int i = 0; i < randomCount; i++)
                {
                    monsters.Add(GetRandomDragon());
                }
                
            }

            return monsters;
        }

        public BossMonsterStatus SpawnBoss(int stage)
        {
            BossMonsterStatus boss = null;

            if (stage == 5)
            {
                boss = GetGoblinBoss();
            }
            else if (stage == 10)
            {
                boss = GetGolemBoss();
            }
            else if (stage == 15)
            {
                boss = GetDragonBoss();
            }

            return boss;

        }

        /// <summary>
        /// 몬스터 랜덤 리턴 메소드
        /// </summary>
        /// <returns></returns>
        // 고블린 세종류 중 한마리를 랜덤으로 리턴
        public static MonsterStatus GetRandomGoblin()
        {
            Random random = new Random();
            int randomKey = random.Next(0, Date.goblin.Count);
            string[] goblin = Date.goblin[randomKey];
            MonsterStatus monster = new MonsterStatus(goblin[0], int.Parse(goblin[1]), int.Parse(goblin[2]), int.Parse(goblin[3]), int.Parse(goblin[4]),
                                                      int.Parse(goblin[5]), int.Parse(goblin[6]), int.Parse(goblin[7]), int.Parse(goblin[8]));
            return monster;
        }

        // 골렘 세종류 중 한마리를 랜덤으로 리턴
        public static MonsterStatus GetRandomGolem()
        {
            Random random = new Random();
            int randomKey = random.Next(0, Date.golem.Count);
            string[] golem = Date.goblin[randomKey];
            MonsterStatus monster = new MonsterStatus(golem[0], int.Parse(golem[1]), int.Parse(golem[2]), int.Parse(golem[3]), int.Parse(golem[4]),
                                                      int.Parse(golem[5]), int.Parse(golem[6]), int.Parse(golem[7]), int.Parse(golem[8]));
            return monster;
        }

        // 드래곤 세종류 중 한마리를 랜덤으로 리턴
        public static MonsterStatus GetRandomDragon()
        {
            Random random = new Random();
            int randomKey = random.Next(0, Date.dragon.Count);
            string[] dragon = Date.dragon[randomKey];
            MonsterStatus monster = new MonsterStatus(dragon[0], int.Parse(dragon[1]), int.Parse(dragon[2]), int.Parse(dragon[3]), int.Parse(dragon[4]),
                                                      int.Parse(dragon[5]), int.Parse(dragon[6]), int.Parse(dragon[7]), int.Parse(dragon[8]));
            return monster;
        }




        /// <summary>
        /// 보스 몬스터 리턴 메소드
        /// </summary>
        /// <returns></returns>

        // 보스 고블린을 리턴해줌
        public static BossMonsterStatus GetGoblinBoss()
        {
            string[] boss1 = Date.boss[0];
            BossMonsterStatus boss = new BossMonsterStatus(boss1[0], int.Parse(boss1[1]), int.Parse(boss1[2]), int.Parse(boss1[3]), int.Parse(boss1[4]),
                                                          int.Parse(boss1[5]), int.Parse(boss1[6]), int.Parse(boss1[7]), int.Parse(boss1[8]), int.Parse(boss1[9]), boss1[10]);

            return boss;
        }

        // 보스 골렘을 리턴해줌
        public static BossMonsterStatus GetGolemBoss()
        {
            string[] boss2 = Date.boss[1];
            BossMonsterStatus boss = new BossMonsterStatus(boss2[0], int.Parse(boss2[1]), int.Parse(boss2[2]), int.Parse(boss2[3]), int.Parse(boss2[4]),
                                                          int.Parse(boss2[5]), int.Parse(boss2[6]), int.Parse(boss2[7]), int.Parse(boss2[8]), int.Parse(boss2[9]), boss2[10]);

            return boss;
        }

        // 보스 드래곤을 리턴해줌
        public static BossMonsterStatus GetDragonBoss()
        {
            string[] boss3 = Date.boss[2];
            BossMonsterStatus boss = new BossMonsterStatus(boss3[0], int.Parse(boss3[1]), int.Parse(boss3[2]), int.Parse(boss3[3]), int.Parse(boss3[4]),
                                                          int.Parse(boss3[5]), int.Parse(boss3[6]), int.Parse(boss3[7]), int.Parse(boss3[8]), int.Parse(boss3[9]), boss3[10]);

            return boss;
        }
        

    }
}