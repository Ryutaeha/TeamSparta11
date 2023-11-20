using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Teamproject;
using static System.Net.Mime.MediaTypeNames;

internal class Skill : ISkill
{
    public string Name { get; }

    public int Ability {get; set;}
    public int AbilityPower => new Random().Next(0, 10) + Ability;

    public int Cost { get; }

    public string SkillInfo { get; }



    public Skill(string name, int ability, int cost, string skillInfo)
    {
        Name = name;
        Ability = ability;
        Cost = cost;
        SkillInfo = skillInfo;
    }

    //몬스터 공격
    public void Use(MonsterStatus monster)
    {
        PlayerInfo.player.MP -= Cost;
        int damage = AbilityPower + PlayerInfo.player.AD - monster.DF;
        monster.HP -= damage;
        Console.WriteLine($"{monster.Name}에게 {Name}(으)로 {damage}의 피해를 입혔습니다.");
    }
    public void Use(BossMonsterStatus bossMonster)
    {
        PlayerInfo.player.MP -= Cost;
        int damage = AbilityPower + PlayerInfo.player.AD - bossMonster.DF;
        bossMonster.HP -= damage;
        Console.WriteLine($"{bossMonster.Name}에게 {Name}(으)로 {damage}의 피해를 입혔습니다.");
    }
}

