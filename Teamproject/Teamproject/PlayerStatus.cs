using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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
        public int AD { get; set;  }
        public int DF { get; set; }
        public int EXP { get; set; }

        public string Job { get; }
        public int MaxMP {  get; set; }
        public int MP {  get; set; }
        public PlayerStatus(string name, string job, int level, int maxhp, int hp, int maxmp,int mp, int ad, int df, int speed, int exp, int gold) 
        {
            Name = name;
            Level = level;
            MaxHP = maxhp;
            HP = hp;
            Speed = speed;
            Gold = gold;
            AD = ad;
            DF = df;
            EXP = exp;
            Job = job;
            MaxMP = maxmp;
            MP = mp;

        }
    }
}
