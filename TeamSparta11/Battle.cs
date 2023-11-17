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

        public void BeginBattleScene()
        {
            Console.WriteLine("Battle!!");

            Console.WriteLine();
            Console.WriteLine("[몬스터 정보]");

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

            Console.WriteLine("===============================================================");

            // 플레이어나 몬스터가 죽기 전까지 반복
            while (player.HP > 0 && monster.HP > 0)
            {
                // 플레이어와 몬스터의 스피드에 따라서 선턴 결정
                if (player.Speed > monster.Speed)
                {
                    PlayerAttackScene(); 
                    MonsterAttackScene(); 
                }

                else if (monster.Speed > player.Speed)
                {
                    MonsterAttackScene();
                    PlayerAttackScene();
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
        private void PlayerAttackScene()
        {
            Console.WriteLine();
            Console.WriteLine("플레이어의 턴입니다.");
            Console.WriteLine();
            Console.WriteLine("1, 공격\t2. 스킬\n3.아이템 사용\t4. 내 상태 보기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력히세요.");
            Console.Write(">>");

            int userSelect = Date.userSelect();
            switch (userSelect)
            {
                case 1:
                    //공격 함수
                    break;
                case 2:
                    //스킬 함수
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

        // 몬스터 턴일때 실행할 메소드
        private void MonsterAttackScene()
        {
            Console.WriteLine();
            Console.WriteLine("몬스터의 턴입니다.");
            Console.WriteLine();
            // 몬스터의 공격 함수 입력
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