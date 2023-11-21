using System.Collections.Generic;
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



        public void BeginBattleScene(MonsterStatus monster)
        {
            Console.WriteLine("Battle!!");
            Console.WriteLine();
            Console.WriteLine("[몬스터 정보]");
            Console.WriteLine($"LV.{monster.Level}\t{monster.Name}\tHP{monster.HP}");
            Console.WriteLine();
            Console.WriteLine("[내정보]");
            Console.WriteLine($"LV.{PlayerInfo.Player.Level}\t{PlayerInfo.Player.Name}");
            Console.WriteLine($"HP {PlayerInfo.Player.HP}/{PlayerInfo.Player.MaxHP}");
            Console.WriteLine($"MP {PlayerInfo.Player.MP}/{PlayerInfo.Player.MaxMP}");
            Console.WriteLine("===============================================================");

            // 플레이어나 몬스터가 죽기 전까지 반복
            while (player.HP > 0 && monster.HP > 0)
            {
                // 플레이어와 몬스터의 스피드에 따라서 선턴 결정
                if (player.Speed >= monster.Speed)
                {
                    PlayerAttackScene(monster); 
                    //MonsterAttackScene(skill, monster); 
                }

                else if (monster.Speed > player.Speed)
                {
                    //MonsterAttackScene(player, monster);
                    PlayerAttackScene(monster);
                }
            }
            // 플레이어 몬스터 둘중 하나가 죽었을때 호출
            EndBattleScene(monster);
        }

        public void BeginBattleScene(BossMonsterStatus boss)
        {
            Console.WriteLine("Battle!!");
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
            while (player.HP > 0 && boss.HP > 0)
            {
                // 플레이어와 몬스터의 스피드에 따라서 선턴 결정
                if (player.Speed >= boss.Speed)
                {
                    PlayerAttackScene(boss);
                    //MonsterAttackScene(player, boss);
                }

                else if (monster.Speed > player.Speed)
                {
                    //MonsterAttackScene(player, boss);
                    PlayerAttackScene(boss);
                }
            }
            // 플레이어 몬스터 둘중 하나가 죽었을때 호출
            EndBattleScene(monster);
        }





        // 플레이어 턴일때 실행할 메소드
        private void PlayerAttackScene(MonsterStatus monster)
        {
            PlayerTurnText();
        }

        private void PlayerAttackScene(BossMonsterStatus boss)
        {
            PlayerTurnText();
        }






        static void BasicAttack(MonsterStatus monster)
        {

            if (attacker == "monster")
            {
                int damage = monster.AD - PlayerInfo.Player.DF; //데미지는 몬스터 공격력 - 플레이어 방어력
                PlayerInfo.Player.HP -= damage;
                if (damage >= PlayerInfo.Player.HP)
                {
                    PlayerInfo.Player.HP = 0;
                }

            }
            else if (attacker == "player")
            {
                int damage = PlayerInfo.Player.AD - monster.DF; //데미지는 플레이어 공격력 - 몬스터의 방어력
                monster.HP -= damage;
                if (damage >= monster.HP)
                {

                    monster.HP = 0;
                }
            }
        }

        static void BasicAttack(BossMonsterStatus boss)
        {

            if (attacker == "boss")
            {
                int damage = boss.AD - PlayerInfo.Player.DF; //데미지는 몬스터 공격력 - 플레이어 방어력
                PlayerInfo.Player.HP -= damage;
                if (damage >= PlayerInfo.Player.HP)
                {
                    PlayerInfo.Player.HP = 0;
                }

            }
            else if (attacker == "player")
            {
                int damage = PlayerInfo.Player.AD - boss.DF; //데미지는 플레이어 공격력 - 몬스터의 방어력
                boss.HP -= damage;
                if (damage >= boss.HP)
                {
                    boss.HP = 0;
                }
            }
        }
        // 스킬 공격 메소드
        public void SkillAttack(MonsterStatus monster, Skill skill)
        {
            skill.Use(monster);
             
        }
        public void SkillAttack(BossMonsterStatus bossMonster, Skill skill)
        {
            skill.Use(bossMonster);
        }


        // 몬스터의 턴 메소드
        // 일반몹
        private void MonsterAttackScene(MonsterStatus monster, Skill skill)
        {
            Console.WriteLine();
            Console.WriteLine("몬스터의 턴입니다.");
            Console.WriteLine();
            SkillAttack(monster, skill);
            Thread.Sleep(1000);
        }
        // 보스몹
        private void MonsterAttackScene(BossMonsterStatus bossMonster, Skill skill)
        {
            Console.WriteLine();
            Console.WriteLine("보스몬스터의 턴입니다.");
            Console.WriteLine();
            SkillAttack(bossMonster, skill);
            Thread.Sleep(1000);
        }

        // 몬스터와의 배틀이 종료된 후에 실행할 메소드
        private void EndBattleScene(MonsterStatus monster) //
        {
            if (PlayerInfo.Player.HP > 0)
            {
                Console.WriteLine($"{PlayerInfo.Player.Name}의 승리, {monster.Name}의 패배입니다.");
                PlayerInfo.Player.EXP += monster.EXP;
            }
            else
            {
                Console.WriteLine($"{monster.Name}의 승리, {PlayerInfo.Player.Name}의 패배입니다.");
            }
        }

        // 보스 몬스터와의 배틀이 종료된 후에 실행할 메소드
        private void EndBattleScene(BossMonsterStatus boss)
        {
            if (player.HP > 0)
            {
                Console.WriteLine($"{PlayerInfo.Player.Name}의 승리, {boss.Name}의 패배입니다.");
                // 보상을 주는 내용, 경험치를 주는 내용
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
                        attacker = "player";
                        BasicAttack(monster);
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


    }
}