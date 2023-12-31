﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TeamSparta11
{
    internal class Inventory
    {
        public int[] ItemCount { get; set; }
        public int[] MaxItemCount { get; set; }
        public List<Equipment> EquipmentInventory { get; set; }
        public List<Supplies> SuppliesInventory { get; set; }
        public Equipment[]? EquippedItem { get; set; }

        public Inventory(int volume) 
        {
            int itemTypeCount = Enum.GetNames(typeof(Date.ItemType)).Length;
            ItemCount = new int[itemTypeCount];
            MaxItemCount = new int[itemTypeCount];
            for (int i = 0; i < itemTypeCount; i++)
            {
                MaxItemCount[i] = volume;
            }
            EquipmentInventory = new List<Equipment>();
            SuppliesInventory = new List<Supplies>();
            EquippedItem = new Equipment[5];
        }

        public void GetItem(int index, int piece = 1)
        {
            DataRow? itemdata = Date.ItemDateTable.Rows.Find(index);
            int itemType = Convert.ToInt32(itemdata["ItemType"]);

            switch (itemType)
            {
                case (int)Date.ItemType.Equipment:
                    Equipment newEquipment = new Equipment();
                    Equipment addEquipment = newEquipment.ItemAdd(index);
                    if (addEquipment != null) 
                    {
                        EquipmentInventory.Add(addEquipment);
                        PlayerInfo.Inventory.ItemCount[(int)Date.ItemType.Equipment]++;
                    }
                    break;
                // 소모품일 경우 최대 갯수에 도달했는지 확인하여 기존 슬롯의 갯수를 늘려준다.
                case (int)Date.ItemType.Supplies:
                    Supplies newSupplies = new Supplies();
                    Supplies addSupplies = newSupplies.ItemAdd(index);
                    if (addSupplies != null)
                    {
                        if (SuppliesInventory[ItemCount[(int)Date.ItemType.Supplies] - 1] != null)
                        {
                            Supplies amountFixedItem = SuppliesInventory[ItemCount[(int)Date.ItemType.Supplies] - 1] as Supplies;
                            if (amountFixedItem.Amount < amountFixedItem.MaxAmount)
                            {
                                amountFixedItem.ItemAmountModify(piece);
                                break;
                            }
                        }
                        else
                        {
                            SuppliesInventory[ItemCount[(int)Date.ItemType.Supplies]] = addSupplies;
                            ItemCount[(int)Date.ItemType.Supplies]++;
                        }
                        
                    }
                    break;
                default:
                    break;
            }
        }

        public void ItemUse(int index)
        {
            int itemCountSum = ItemCount.Sum();
            if (index > itemCountSum) return;
            Equipment item = EquipmentInventory[index];
            
            if (item is IItem iItem) iItem.ItemEvent();
        }

        public void Unequipped(int index)
        {
            if (EquippedItem[index] != null)
            {
                Equipment equipItem = EquippedItem[index];
                GetItem(equipItem.ItemIndex);
                EquippedItem[index] = null;
                Console.WriteLine($"{equipItem.Name}(을/를) 장비 해제했습니다.");
            }
        }

        public void ItemSell(int index)
        {
            int itemCountSum = ItemCount.Sum();
            if (index > itemCountSum) return;
            Equipment item = EquipmentInventory[index];

            PlayerInfo.Player.Gold += item.ItemPrice;
            EquipmentInventory.Remove(item);
            ItemCount[(int)Date.ItemType.Equipment]--;
            Console.WriteLine($"{item.Name}(을/를) 판매했습니다. 현재 소지금 : {PlayerInfo.Player.Gold} Gold");
        }
    }
}
