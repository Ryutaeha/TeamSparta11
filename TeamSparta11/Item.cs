using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSparta11
{
    public abstract class Item
    {
        string Name { get; }
        int ItemType { get; }
        int ItemPrice { get; }

        public abstract void ItemAdd();
    }

    public class Equipment : Item, IItem
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

    public class Supplies : Item, IItem
    {
        int Amount { get; set; }
        int MaxAmount;

        public override void ItemAdd()
        {

        }

        public void ItemUse()
        {
            
        }

    }
}
