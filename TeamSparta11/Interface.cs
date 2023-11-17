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
    }

    internal interface ISkill
    {
        string Name { get; }
        int Ability {  get; }
        int Cost {  get; }
        int SkillID { get; }
    }
    
    internal interface IItem
    {
        string Name { get; }
        int ItemType { get; }
        int ItemPrice { get; }

        public void ItemUse();
    }

    internal interface IEquipmentItem
    {
        int EquipmentType { get; }
        int MaxHP { get; }
        int Speed { get; }
        int AD { get; }
        int DF { get; }

        public void ItemUse();
    }