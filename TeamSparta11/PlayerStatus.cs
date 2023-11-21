using System;

namespace Teamproject
{
    internal class PlayerStatus : ICharacter
    {
        public string Name { get; }
        public int MaxHP { get; set; }
        public int HP { get; set; }
        public int Speed { get; set; }
        public int Gold { get; set; }
        public int Level { get; set; }
        public int AD { get; set; }
        public int DF { get; set; }
        public int EXP { get; set; }
        public bool IsDead => HP <= 0;


        public int NextEXP = 5;
        public string Job { get; }
        public int MaxMP { get; set; }
        public int MP { get; set; }
        public int Stage { get; set; }


        public int LevelUp() 
        {
            int up = 0;
            while (EXP >= NextEXP)
            {
                NextEXP += (++Level * 1);
                MaxHP += Job == "전사" ? 10 : 5;
                HP += 20;
                if(HP > MaxHP)
                {
                    HP = MaxHP;
                }

                MaxMP += Job == "마법사" ? 10 : 5;
                MP += 10;
                if(MP > MaxMP)
                {
                    MP = MaxMP;
                }

                AD += Job == "도적" ? 2 : 1;
                DF += Job == "전사" ? 2 : 1;

                if(Level / 10 == 0)
                {
                    ++Speed;
                }

                ++up;
            }
            return up;
        }

        public PlayerStatus(string name, string job, int level, int maxhp, int hp, int maxmp, int mp,int ad, int df, int speed, int exp, int gold, int stage)
        {
            Name = name;
            Job = job;
            Level = level;
            MaxHP = maxhp;
            HP = hp;
            MaxMP = maxmp;
            MP = mp;
            Speed = speed;
            Gold = gold;
            AD = ad;
            DF = df;
            EXP = exp;
            Stage = stage;

        }
        public void BeDamaged(int damage)
        {
            int dameges = damage - DF;
            if (dameges < 0) damage = 1;
            HP -= damage;
            Console.WriteLine($"{Name}(은)는 {damage}의 피해를 입었습니다. 남은 체력 : {HP}");
        }
        public void BeFatalDamaged(int damage)
        {
            int dameges = damage - DF;
            if (dameges < 0) damage = 1;
            HP -= damage;
            Console.WriteLine($"{Name}(은)는 {damage}의 치명적 피해를 입었습니다. 남은 체력 : {HP}");
        }
    }
}