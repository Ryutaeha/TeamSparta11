using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace TeamSparta11
{
    internal abstract class Item : IItem
    {
        public int ItemIndex { get; protected set; }
        public string Name { get; protected set; }
        public string Explain { get; protected set; }
        public int ItemType { get; protected set; }
        public int ItemPrice { get; protected set; }

        public abstract Item ItemAdd(int Index);

        public abstract void ItemUse();
    }

    internal class Equipment : Item
    {
        public int EquipmentType { get; }
        public bool IsEquip { get; set; }
        public int MaxHP { get; }
        public int MaxMp { get; }
        public int Speed { get; }
        public int AD { get; }
        public int DF { get; }

        public override Equipment? ItemAdd(int Index)
        {
            DataRow? itemdata = Date.ItemDataTable.Rows.Find(Index);

            ItemIndex = Convert.ToInt32(itemdata["ItemIndex"]);
            Name = itemdata["Name"].ToString();
            Explain = itemdata["Explain"].ToString();
            ItemType = Convert.ToInt32(itemdata["ItemType"]);
            ItemPrice = Convert.ToInt32(itemdata["ItemPrice"]);

            if (ItemType == (int)Date.ItemType.equipment)
            {
                return this;
            }
            return null;
        }

        public override void ItemUse()
        {

        }
    }
    
    internal class Supplies : Item
    {
        public int SuppliesType { get; }
        public bool IsEquip { get; set; }
        public int Amount { get; private set; }
        public int MaxAmount { get; }
        public int Effect { get; }
        public int Modifier { get; }
        public int Value { get; }

        public override Supplies? ItemAdd(int Index)
        {
            DataRow? itemdata = Date.ItemDataTable.Rows.Find(Index);

            ItemIndex = Convert.ToInt32(itemdata["ItemIndex"]);
            Name = itemdata["Name"].ToString();
            Explain = itemdata["Explain"].ToString();
            ItemType = Convert.ToInt32(itemdata["ItemType"]);
            ItemPrice = Convert.ToInt32(itemdata["ItemPrice"]);

            if (ItemType == (int)Date.ItemType.supplies)
            {
                return this;
            }
            return null;
        }

        public void ItemAmountModify(int Index)
        {
            Amount += Index;
        }

        public override void ItemUse()
        {

        }
    }
}
