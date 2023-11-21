using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace TeamSparta11
{
    internal abstract class Item
    {
        public int ItemIndex { get; protected set; }
        public string Name { get; protected set; }
        public string Explain { get; protected set; }
        public int ItemType { get; protected set; }
        public int ItemPrice { get; protected set; }

        public abstract Item ItemAdd(int index);
    }

    internal class Equipment : Item, IItem
    {
        public int EquipmentIndex { get; private set; }
        public int EquipmentType { get; private set; }
        public bool IsEquip { get; set; }
        public int MaxHP { get; private set; }
        public int MaxMp { get; private set; }
        public int Speed { get; private set; }
        public int AD { get; private set; }
        public int DF { get; private set; }

        public override Equipment? ItemAdd(int index)
        {
            DataRow? itemData = Date.ItemDateTable.Rows.Find(index);

            ItemIndex = Convert.ToInt32(itemData["ItemIndex"]);
            Name = itemData["Name"].ToString();
            Explain = itemData["Explain"].ToString();
            ItemType = Convert.ToInt32(itemData["ItemType"]);
            ItemPrice = Convert.ToInt32(itemData["ItemPrice"]);

            DataRow? equipmentData = Date.EquipmentDateTable.Rows.Find(index);

            EquipmentIndex = Convert.ToInt32(equipmentData["EquipmentIndex"]);
            EquipmentType = Convert.ToInt32(equipmentData["EquipmentType"]);
            MaxHP = Convert.ToInt32(equipmentData["MaxHP"]);
            MaxMp = Convert.ToInt32(equipmentData["MaxMp"]);
            Speed = Convert.ToInt32(equipmentData["Speed"]);
            AD = Convert.ToInt32(equipmentData["AD"]);
            DF = Convert.ToInt32(equipmentData["DF"]);


            if (ItemType == (int)Date.ItemType.equipment)
            {
                return this;
            }
            return null;
        }

        public void ItemUse()
        {

        }
    }
    
    internal class Supplies : Item, IItem
    {
        public int SuppliesType { get; }
        public bool IsEquip { get; set; }
        public int Amount { get; private set; }
        public int MaxAmount { get; }
        public int Effect { get; }
        public int Modifier { get; }
        public int Value { get; }

        public override Supplies? ItemAdd(int index)
        {
            DataRow? itemData = Date.ItemDateTable.Rows.Find(index);

            ItemIndex = Convert.ToInt32(itemData["ItemIndex"]);
            Name = itemData["Name"].ToString();
            Explain = itemData["Explain"].ToString();
            ItemType = Convert.ToInt32(itemData["ItemType"]);
            ItemPrice = Convert.ToInt32(itemData["ItemPrice"]);

            if (ItemType == (int)Date.ItemType.supplies)
            {
                return this;
            }
            return null;
        }

        public void ItemAmountModify(int index)
        {
            Amount += index;
        }

        public void ItemUse()
        {

        }
    }
}
