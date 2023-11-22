using System;

namespace Teamproject
{
    //몬스터
    internal class MonsterStatus : ICharacter
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


        public MonsterStatus(string name, int level, int maxhp, int hp, int ad, int df, int speed, int exp, int gold)
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

        }
    }





    //보스 몬스터
    internal class BossMonsterStatus : ICharacter
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


        public int MaxMP { get; set; }
        public int MP { get; set; }
        public string DropItem { get; set; }        


        public BossMonsterStatus(string name, int level, int maxHP, int hp, int maxMP, int mp, int ad, int df, int exp, int gold, string dropitem)
        {
            Name = name;
            Level = level;
            MaxHP = maxHP;
            HP = hp;
            MaxMP = maxMP;
            MP = mp;
            AD = ad;
            DF = df;
            EXP = exp;
            Gold = gold;
            DropItem = dropitem;

        }


    }
    //몬스터
    internal class MonsterStatusNew : ICharacter
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


        public MonsterStatusNew(string name, int level, int maxhp, int hp, int ad, int df, int speed, int exp, int gold)
        {
            Name = name;
            Level = level;
            MaxHP = maxhp;
            HP = hp;
            Speed = (speed + new Random().Next(0,3));
            Gold = gold + new Random().Next(0, 3);
            AD = ad + new Random().Next(0, 3);
            DF = df + new Random().Next(0, 3);
            EXP = exp + new Random().Next(0, 2);
            
        }
        public void Damage(int damage)
        {
            int dameges = damage - DF;
            if (dameges < 0) damage = 1;
            HP -= damage;
            if (HP < 0) HP = 0;
            Console.WriteLine($"{Name}(은)는 {damage}의 피해를 입었습니다. 남은 체력 : {HP}");
        }
        public void FatalDamage(int damage)
        {
            int dameges = damage - DF;
            if (dameges < 0) damage = 1;
            HP -= damage;
            if (HP < 0) HP = 0;
            Console.WriteLine($"{Name}(은)는 {damage}의 치명적 피해를 입었습니다. 남은 체력 : {HP}");
        }
        
    }





    //보스 몬스터
    internal class BossMonsterStatusNew : ICharacter
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


        public int MaxMP { get; set; }
        public int MP { get; set; }
        public string DropItem { get; set; }


        public BossMonsterStatusNew(string name, int level, int maxHP, int hp, int maxMP, int mp, int ad, int df, int exp, int gold)
        {
            Name = name;
            Level = level;
            MaxHP = maxHP;
            HP = hp;
            MaxMP = maxMP;
            MP = mp;
            AD = ad;
            DF = df;
            EXP = exp;
            Gold = gold;

        }

        public void Damage(int damage)
        {
            int dameges = damage - DF;
            if (dameges < 0) damage = 1;
            HP -= damage;
            if (HP < 0) HP = 0;
            Console.WriteLine($"{Name}(은)는 {damage}의 피해를 입었습니다. 남은 체력 : {HP}");
        }
        public void FatalDamage(int damage)
        {
            int dameges = damage - DF;
            if (dameges < 0) damage = 1;
            HP -= damage;
            if (HP < 0) HP = 0;
            Console.WriteLine($"{Name}(은)는 {damage}의 치명적 피해를 입었습니다. 남은 체력 : {HP}");
        }
    }
}