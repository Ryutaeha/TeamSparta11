using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    internal interface ICharacter
    {
        string Name { get; }
        int MaxHP {  get; }
        int HP { get; }
        int Speed { get; }
        int Gold { get; }
        int Level {  get; }
        int AD {  get; }
        int DF {  get; }
        int EXP {  get; }
        bool IsDead {  get; }
}

    internal interface ISkill
    {
        //스킬 이름
        string Name { get; }
        //툴팁 표기량
        int Ability {  get; }
        //실제 회복or데미지
        int AbilityPower { get; }
        // 마나 소모량
        int Cost {  get; }
        //스킬 설명
        string SkillInfo { get; }
        //아군버프인지 공격스킬인지
        bool AttackSkill { get; }
        
}
    
    internal interface IItem
    {
        
    }

