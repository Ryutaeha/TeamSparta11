using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teamproject;

namespace TeamSparta11
{
    internal class BattleNew
    {
        List<MonsterStatusNew> monster = new List<MonsterStatusNew>();
        List<BossMonsterStatusNew> bossMonster = new List<BossMonsterStatusNew>();
        int[] speedCompare;
        int[] attackSequence;
        //획득 아이템 저장
        int getGold = 0;
        int getExp = 0;



        internal bool Battle()
        {
            bossMonster.Clear();
            monster.Clear();
            MonsterSetting();
            bool battleEnd;
            if (PlayerInfo.Player.Stage % 5 != 0)
            {
                
                Console.WriteLine();
                Date.Line();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"◆현재 스테이지: {PlayerInfo.Player.Stage} 층◆");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine();
                for (int i = 0; i < monster.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"{monster[i].Name}");
                    Console.ResetColor();
                    Console.WriteLine("(이)가 출현했다.\n");

                }
                Console.WriteLine();
                battleEnd = BattleStart();
                
            }
            else
            {
                battleEnd = BossBattleStart();
            }

            BattleEnd(battleEnd);

            if (battleEnd)
            {
                PlayerInfo.Player.Stage++;
                return true;
            }
            else
            {
                return false;
            }
        }

        

        private void BattleEnd(bool battleEnd)
        {
            Date.Line();
            Console.WriteLine();
            if (battleEnd)
            {
                Console.ForegroundColor= ConsoleColor.Magenta;
                Console.WriteLine("♬사냥 성공♬");
                Console.ResetColor();
                Console.WriteLine($"획득한 골드 : {getGold}");
                Console.WriteLine($"획득한 경험치 : {getExp}");
                PlayerInfo.Player.HP += 20;
                if(PlayerInfo.Player.HP> PlayerInfo.Player.MaxHP) PlayerInfo.Player.HP = PlayerInfo.Player.MaxHP;
                PlayerInfo.Player.MP = PlayerInfo.Player.MaxMP;
                Console.WriteLine($"{PlayerInfo.Player.Name}의 체력이 20과 마나가 전부 회복되었습니다");
                PlayerInfo.Player.Gold += getGold;
                PlayerInfo.Player.EXP += getExp;
                if (PlayerInfo.Player.Stage == 5)
                {
                    PlayerInfo.Inventory.GetItem(2);
                }
                if (PlayerInfo.Player.Stage == 10)
                {
                    PlayerInfo.Inventory.GetItem(3);
                }
                if (PlayerInfo.Player.Stage % 5 == 0 && PlayerInfo.Player.Stage / 5 > 2)
                {
                    PlayerInfo.Inventory.GetItem(4);
                }
                if(PlayerInfo.Player.Stage % 5 == 0)
                {
                    Console.WriteLine("무언가 반짝이는 것이 보이는거 같다!");
                }
            }
            else
            {
                
                Console.WriteLine("사망하였습니다 아무키나 입력 시 메인화면으로 돌아갑니다");                
                int UserSelect = Date.UserSelect();
                switch (UserSelect)
                {
                    default:

                    break;
                }               
            }

        }

            private void MonsterSetting()
        {
            string[] monsters = null;
            if(PlayerInfo.Player.Stage % 5 != 0)
            {
                int monsterAmount = new Random().Next(1,4);
                MonsterStatusNew monsterSelect = null;
                for (int i = 0; i < monsterAmount; i++)
                {
                    int randomMonster = new Random().Next(0,3);
                
                    if(PlayerInfo.Player.Stage < 6) monsters = Date.goblin[randomMonster];
                    else if(PlayerInfo.Player.Stage < 11) monsters = Date.golem[randomMonster];
                    else monsters = Date.dragon[randomMonster];
                    monsterSelect = new MonsterStatusNew
                        (
                            monsters[0],
                            int.Parse(monsters[1]),
                            int.Parse(monsters[2]),
                            int.Parse(monsters[3]),
                            int.Parse(monsters[4]),
                            int.Parse(monsters[5]),
                            int.Parse(monsters[6]),
                            int.Parse(monsters[7]),
                            int.Parse(monsters[8])
                        );
                    monster.Add(monsterSelect);
                }
            }
            else
            {
                int bossSelect = PlayerInfo.Player.Stage / 5;
                if (bossSelect > 3) bossSelect = 2;
                monsters = Date.boss[bossSelect-1];
                BossMonsterStatusNew bossMonsterSelect = new BossMonsterStatusNew
                    (
                         monsters[0],
                         int.Parse(monsters[1]),
                         int.Parse(monsters[2]),
                         int.Parse(monsters[3]),
                         int.Parse(monsters[4]),
                         int.Parse(monsters[5]),
                         int.Parse(monsters[6]),
                         int.Parse(monsters[7]),
                         int.Parse(monsters[8]),
                         int.Parse(monsters[8])
                    );
                bossMonster.Add(bossMonsterSelect);
            }
        }
        private bool BattleStart()
        {
            BattleAttackSequence();
            
            //전투 
            while (!PlayerInfo.Player.IsDead && monster.Count != 0)
            {
                Date.Line();
                Console.Write($"{PlayerInfo.Player.Name} ");   
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"HP : {PlayerInfo.Player.HP} / {PlayerInfo.Player.MaxHP}  ");
                Console.ResetColor();
                Console.ForegroundColor= ConsoleColor.Blue;
                Console.WriteLine($"MP : {PlayerInfo.Player.MP} / { PlayerInfo.Player.MaxMP}");
                Console.ResetColor();


                
                (int, int) playerSelete = PlayerSelete();

                for(int i = 0; i < attackSequence.Length; i++)
                {
                    int fatalDamage = new Random().Next(0,100);
                    if (attackSequence[i]==0)
                    {
                        Console.WriteLine($"{PlayerInfo.Player.Name}의 턴");
                        if(fatalDamage < 3)
                        {
                            monster[playerSelete.Item1-1].FatalDamage(playerSelete.Item2);
                        }
                        else if(fatalDamage < 97) monster[playerSelete.Item1-1].Damage(playerSelete.Item2);
                        else Console.WriteLine($"\n{monster[playerSelete.Item1 - 1].Name}가 공격을 피했습니다!");

                        if (monster[playerSelete.Item1 - 1].IsDead) Console.WriteLine($"\n{monster[playerSelete.Item1 - 1].Name} (은)는 죽었습니다.");
                    }
                    else
                    {

                        if (!monster[attackSequence[i] - 1].IsDead)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"{monster[attackSequence[i] - 1].Name}");
                            Console.ResetColor();
                            Console.WriteLine("의 턴");
                            if (fatalDamage < 3)
                            {
                                PlayerInfo.Player.BeFatalDamaged(monster[attackSequence[i] - 1].AD);
                            }
                            else if (fatalDamage < 97) PlayerInfo.Player.BeDamaged(monster[attackSequence[i] - 1].AD);
                            else Console.WriteLine($"\n{PlayerInfo.Player.Name}가 공격을 피했습니다!");
                        }
                        
                        if(PlayerInfo.Player.IsDead)
                        {
                            return false;
                        }
                    }

                    Console.WriteLine();

                    Thread.Sleep(1000);

                }
                if (monster[playerSelete.Item1 - 1].IsDead)
                {
                    getGold += monster[playerSelete.Item1 - 1].Gold;
                    getExp += monster[playerSelete.Item1 - 1].EXP;
                    monster.RemoveAt(playerSelete.Item1 - 1);
                    BattleAttackSequence();
                }
            }
            return true;
        }

        private void BattleAttackSequence()
        {
            speedCompare = new int[monster.Count + 1];
            attackSequence = new int[monster.Count + 1];
            for (int i = 0; i <= monster.Count; i++)
            {
                if (i == 0)
                {
                    speedCompare[i] = PlayerInfo.Player.Speed;
                }
                else
                {
                    speedCompare[i] = monster[i - 1].Speed;
                }
                attackSequence[i] = i;
            }
            for (int i = 0; i < speedCompare.Length - 1; i++)
            {
                for (int j = 0; j < speedCompare.Length - i - 1; j++)
                {
                    // 현재 원소와 다음 원소를 비교하여 순서가 바뀌어 있으면 교환
                    if (speedCompare[j] < speedCompare[j + 1])
                    {
                        // Swap arr[j] and arr[j+1]
                        int temp = speedCompare[j];
                        speedCompare[j] = speedCompare[j + 1];
                        speedCompare[j + 1] = temp;
                        int temp1 = attackSequence[j];
                        attackSequence[j] = attackSequence[j + 1];
                        attackSequence[j + 1] = temp1;
                    }
                }
            }
        }

        private (int, int) PlayerSelete()
        {
            (int, int) attack;
            while (true)
            {
                Date.Line() ;
                Console.WriteLine("행동을 선택하세요\n");
                Console.WriteLine("1. 일반 공격");
                Console.WriteLine("2. 스킬 공격");
                Console.WriteLine("3. 몬스터 정보");
                switch (Date.UserSelect())
                {
                    case 1:
                        attack = Attack(1);
                        if(attack.Item1 != 0) return attack;
                        break;
                    case 2:
                        attack = Attack(2);
                        if (attack.Item1 != 0) return attack;
                        break;
                    case 3:
                        MosterInfo();
                        break;
                    default: 
                        break;
                }

                
            }
        }

        private void MosterInfo()
        {
            if(PlayerInfo.Player.Stage % 5 != 0)
            {
                for (int i = 0; i< monster.Count; i++)
                {
                    Console.WriteLine($"몬스터 이름 : {monster[i].Name}  체력 : {monster[i].HP} / {monster[i].MaxHP}   공격력 : {monster[i].AD}   방어력 : {monster[i].DF}");
                }
            }
            else
            {
                Console.WriteLine($"몬스터 이름 : {bossMonster[0].Name}  체력 : {bossMonster[0].HP} / {bossMonster[0].MaxHP}   공격력 : {bossMonster[0].AD}   방어력 : {bossMonster[0].DF}");
            }
        }

        private (int, int) Attack(int selectNum)
        {
            while(true)
            {
                Date.Line() ;
                Console.WriteLine("공격할 몬스터를 선택하세요");

                for (int i = 0 ;i < monster.Count ; i++)
                {
                    Console.Write($"{i + 1}. ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{monster[i].Name}");
                    Console.ResetColor();
                }
                Console.WriteLine("0. 돌아가기");
                int select = Date.UserSelect();
                if(select > 0 && select <= monster.Count )
                {
                    if (selectNum==1) return (select, PlayerInfo.Player.AD + (PlayerInfo.Inventory.EquippedItem[0]== null? 0: PlayerInfo.Inventory.EquippedItem[0].AD));
                    int skillselect = SkillAttack();
                    if (selectNum == 2 && skillselect != 0) return (select , skillselect);
                }
                if (select == 0) return (select, 0);
            }
        }

        private int SkillAttack()
        {
            while (true)
            {
                Date.Line();
                Console.WriteLine("사용할 스킬을 선택하세요!");
                for(int i = 0 ; i < PlayerInfo.SkillList.Count ; i++)
                {
                    Console.WriteLine($"{i + 1}. {PlayerInfo.SkillList[i].Name} 공격력 : {PlayerInfo.SkillList[i].Ability}    소모마나 : {PlayerInfo.SkillList[i].Cost}");
                }
                Console.WriteLine("0. 뒤로가기");
                int select = Date.UserSelect();
                if (select > 0 && select <= PlayerInfo.SkillList.Count)
                {
                    if ((PlayerInfo.Player.MP - PlayerInfo.SkillList[select - 1].Cost) >= 0)
                    {
                        PlayerInfo.Player.MP -= PlayerInfo.SkillList[select - 1].Cost;
                        return (PlayerInfo.SkillList[select - 1].AbilityPower + PlayerInfo.Player.AD + (PlayerInfo.Inventory.EquippedItem[0] == null ? 0 : PlayerInfo.Inventory.EquippedItem[0].AD));
                    }
                    else Console.WriteLine("MP가 모자랍니다.");
                }if (select == 0) return (select);
            }
        }
        private bool BossBattleStart()
        {
            Date.Line ();
            Console.WriteLine($"\n강력한 적인 {bossMonster[0].Name}이 나타났다.");
            while (!PlayerInfo.Player.IsDead && bossMonster.Count != 0)
            {
                Date.Line();
                Console.Write($"{PlayerInfo.Player.Name} ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"HP : {PlayerInfo.Player.HP} / {PlayerInfo.Player.MaxHP}  ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"MP : {PlayerInfo.Player.MP} / {PlayerInfo.Player.MaxMP}");
                Console.ResetColor();
                int damege = PlayerSeleteBoss();

                Console.WriteLine();

                int fatalDamage = new Random().Next(0, 100);

                Console.WriteLine($"{bossMonster[0].Name}의 턴");
                if (fatalDamage < 3)
                {
                    PlayerInfo.Player.BeFatalDamaged(bossMonster[0].AD);
                }
                else PlayerInfo.Player.BeDamaged(bossMonster[0].AD);

                if (PlayerInfo.Player.IsDead) return false;
                Console.WriteLine();
                Thread.Sleep(1000);
                        
                Console.WriteLine($"{PlayerInfo.Player.Name}의 턴");
                if (fatalDamage < 3)
                {
                    bossMonster[0].FatalDamage(damege);
                }
                else bossMonster[0].Damage(damege);

                if (bossMonster[0].IsDead)
                {
                    getGold += bossMonster[0].Gold;
                    getExp += bossMonster[0].EXP;
                    return true;
                }
                Console.WriteLine();
                Thread.Sleep(1000);
            }
            return false;
        }

        private int PlayerSeleteBoss()
        {
            int attack;
            while (true)
            {
                Date.Line();
                Console.WriteLine("행동을 선택하세요\n");
                Console.WriteLine("1. 일반 공격");
                Console.WriteLine("2. 스킬 공격");
                Console.WriteLine("3. 몬스터 정보");
                switch (Date.UserSelect())
                {
                    case 1:
                        attack = BossAttack(1);
                        if (attack != 0) return attack;
                        break;
                    case 2:
                        attack = BossAttack(2);
                        if (attack != 0) return attack;
                        break;
                    case 3:
                        MosterInfo();
                        break;
                    default:
                        break;
                }


            }
        }

        private int BossAttack(int select)
        {
            if (select == 1) return PlayerInfo.Player.AD + (PlayerInfo.Inventory.EquippedItem[0] == null ? 0 : PlayerInfo.Inventory.EquippedItem[0].AD);
            else return SkillAttack();
        }

    }
}
