using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Teamproject;

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
    //플레이어에게 사용 힐만 구현
    public void Use(PlayerStatus player)
    {
        player.MP -= Cost;
        player.HP += AbilityPower;
        if(player.HP > player.MaxHP) player.HP = player.MaxHP;
    }

    //몬스터 공격
    public void Use(MonsterStatus monster)
    {
        PlayerInfo.player.MP -= Cost;
        monster.HP -= AbilityPower;
    }
    public void Use(BossMonsterStatus bossMonster)
    {
        PlayerInfo.player.MP -= Cost;
        bossMonster.HP -= AbilityPower;
    }
}

