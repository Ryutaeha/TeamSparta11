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

        public string Job { get; }
        public int MaxMP { get; set; }
        public int MP { get; set; }

        public PlayerStatus(string name, string job, int ad, int df, int exp)
        {
            Name = name;
            Job = job;
            Level = 1;
            MaxHP = 100;
            HP = 100;
            MaxMP = 50;
            MP = 50;
            Speed = 1;
            Gold = 100;
            AD = ad;
            DF = df;
            EXP = exp;
            

        }
    }
}