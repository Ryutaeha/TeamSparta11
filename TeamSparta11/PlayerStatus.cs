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
        public int Level { get; }
        public int AD { get; set; }
        public int DF { get; set; }
        public int EXP { get; set; }
        public bool IsDead => HP <= 0;


        public int NextEXP = 3;
        public string Job { get; }
        public int MaxMP { get; set; }
        public int MP { get; set; }

    
        
    

        
        public PlayerStatus(string name, string job, int level, int maxhp, int hp, int maxmp, int mp,int ad, int df, int speed, int gold, int exp)
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
            

        }
    }
}