﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace TeamSparta11
{
    internal abstract class Item
    {
        public int ItemIndex { get; set; }
        public string Name { get; set; }
        public string Explain { get; set; }
        public int ItemType { get; set; }
        public int ItemPrice { get; set; }

        public abstract Item ItemAdd(int index);
    }

    internal class Equipment : Item, IItem
    {
        public int EquipmentIndex { get; set; }
        public int EquipmentType { get; set; }
        public int MaxHP { get; set; }
        public int MaxMp { get; set; }
        public int Speed { get; set; }
        public int AD { get; set; }
        public int DF { get; set; }

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


            if (ItemType == (int)Date.ItemType.Equipment)
            {
                return this;
            }
            return null;
        }

        public void ItemEvent()
        {
            if (PlayerInfo.Inventory.EquippedItem[EquipmentType] != null)
            {
                PlayerInfo.Inventory.Unequipped(EquipmentType);
            }
            Equipment newEquipment = new Equipment();
            Equipment addEquipment = newEquipment.ItemAdd(ItemIndex);
            PlayerInfo.Inventory.EquippedItem[EquipmentType] = addEquipment;
            PlayerInfo.Inventory.EquipmentInventory.Remove(this);
            PlayerInfo.Inventory.ItemCount[(int)Date.ItemType.Equipment]--;
            Console.WriteLine($"{Name}(을/를) 착용했습니다.");
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

            if (ItemType == (int)Date.ItemType.Supplies)
            {
                return this;
            }
            return null;
        }

        public void ItemAmountModify(int index)
        {
            Amount += index;
        }

        public void ItemEvent()
        {

        }
    }
}
