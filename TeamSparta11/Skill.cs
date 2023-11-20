using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teamproject;

internal class Skill : ISkill
{
    public string Name { get; }

    public int Ability {get; set;}
    public int AbilityPower => new Random().Next(0, 10) + Ability;

    public int Cost { get; }

    public string SkillInfo { get; }

    public bool AttackSkill { get; }


    public Skill(string name, int ability, int cost, string skillInfo, bool attackSkill)
    {
        Name = name;
        Ability = ability;
        Cost = cost;
        SkillInfo = skillInfo;
        AttackSkill = attackSkill;
    }

    public void Use(PlayerStatus player) { }
    public void Use(MonsterStatus monster) { }
    public void Use(BossMonsterStatus bossMonster) { }
    


}

