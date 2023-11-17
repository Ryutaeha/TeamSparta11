using System.Numerics;
using System.Threading;
using Teamproject;
using static Test;

namespace TeamSparta11
{
    internal class Battle
    {
        private ICharacter player;
        private ICharacter monster;
        private List<IItem> rewards;

        public delegate void GameEvent(ICharacter character);
        public event GameEvent CharacterDie;

        public Battle(ICharacter player, ICharacter monster, List<IItem> rewards)
        {
            this.player =  player;
            this.monster = monster;
            this.rewards = rewards;
            CharacterDie += EndBattleScene;
        }
        public void BeginBattleScene(PlayerStatus playerStatus, MonsterStatus monsterStatus)
        {
            Console.WriteLine("Battle!!");

            Console.WriteLine();
            Console.WriteLine("[몬스터 정보]");
            Console.WriteLine($"LV.{monsterStatus.Level}\t{monsterStatus.Name}\tHP{monsterStatus.HP}");
            Console.WriteLine();
            Console.WriteLine("[내정보]");
            Console.WriteLine($"LV.{playerStatus.Level}\t{playerStatus.Name}");
            Console.WriteLine($"HP {playerStatus.HP}/{playerStatus.MaxHP}");
            Console.WriteLine($"MP {playerStatus.MP}/{playerStatus.MaxMP}");
            Console.WriteLine("===============================================================");

            // 플레이어나 몬스터가 죽기 전까지 반복
            while (player.HP > 0 && monster.HP > 0)
            {
                // 플레이어와 몬스터의 스피드에 따라서 선턴 결정
                if (player.Speed > monster.Speed)
                {
                    PlayerAttackScene( playerStatus,  monsterStatus); 
                    MonsterAttackScene(playerStatus, monsterStatus); 
                }

                else if (monster.Speed > player.Speed)
                {
                    MonsterAttackScene(playerStatus, monsterStatus);
                    PlayerAttackScene( playerStatus,  monsterStatus);
                }
                else
                {
                    // 랜덤으로 공격턴 정하기
                }

            }

            // 플레이어 몬스터 둘중 하나가 죽었을때 호출
            if (player.HP < 0)
            {
                CharacterDie?.Invoke(player);
            }
            else if(monster.HP < 0)
            {
                CharacterDie?.Invoke(monster);
            }

        }

        // 플레이어 턴일때 실행할 메소드
        private void PlayerAttackScene(PlayerStatus playerStatus, MonsterStatus monsterStatus)
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
        public void SkillAttack(PlayerStatus playerStatus, MonsterStatus monsterStatus, Skills skills)
        {
            string skillName = Console.ReadLine();
            int damage;
            if (skillName == /*스킬배열이름*/[skillName])
            {
                if (/*skills.MP <= playerStatus.MP*/)
                {

                    if (/*공격자가 몬스터이면 */)
                    {
                        damage = monsterStatus.AD - playerStatus.DF; //데미지는 몬스터 공격력 - 플레이어 방어력
                        playerStatus.HP -= damage;
                        if (damage >= playerStatus.HP)
                        {
                            playerStatus.HP = 0;
                            playerStatus.IsDead = true;
                        }

                    }
                    else if (/*공격자가 플레이어면*/)
                    {
                        damage = playerStatus.AD - monsterStatus.DF; //데미지는 플레이어 공격력 - 몬스터의 방어력
                        monsterStatus.HP -= damage;
                        playerStatus.MP -= skills.mp;                        
                        if (damage >= monsterStatus.HP)
                        {
                            monsterStatus.HP = 0;
                            monsterStatus.IsDead = true;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("MP가 부족합니다");
                }
            }
        }
        private void MonsterAttackScene(PlayerStatus playerStatus, MonsterStatus monsterStatus)
        {
            Console.WriteLine();
            Console.WriteLine("몬스터의 턴입니다.");
            Console.WriteLine();
            BasicAttack(playerStatus, monsterStatus);
            Thread.Sleep(1000);
        }
        // 배틀이 종료된 후에 실행할 메소드
        private void EndBattleScene(ICharacter character) // 플레이어가 승리하면 리워드(보상)을 랜덤으로 주기.
        {
            if (character is Player)
            {
                Console.WriteLine($"{character}이(가) 승리하였습니다!!");
                // 보상을 주는 내용
            }
            else
            {
                Console.WriteLine($"{character}이(가) 패배하였습니다..");
            }
        }
    }
}