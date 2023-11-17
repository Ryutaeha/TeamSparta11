using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSparta11
{
    internal abstract class Item
    {
        int ItemIndex { get; }
        string Name { get; }
        string Explain { get; }
        int ItemType { get; }
        int ItemPrice { get; }

        public abstract void ItemAdd();
    }

    internal class Equipment : Item, IItem
    {
        int EquipmentType { get; }
        bool IsEquip { get; set; }
        int MaxHP { get; }
        int Speed { get; }
        int AD { get; }
        int DF { get; }

        public override void ItemAdd()
        {

        }

        public void ItemUse()
        {

        }
    }

    internal class Supplies : Item, IItem
    {
        int Amount { get; set; }
        int MaxAmount;

        int EffectStatus;
        int Modifier;
        int Value;


        public override void ItemAdd()
        {

        }
        public void ItemUse()
        {

        }

    }
}
