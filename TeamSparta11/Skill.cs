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

}

