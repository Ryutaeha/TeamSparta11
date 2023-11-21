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
        public bool IsEquip { get; private set; }
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

        public void ItemEvent()
        {
            IsEquip = !IsEquip;

            if (this is Equipment equipmentItem && equipmentItem.IsEquip)
            {
                // 인벤토리에서 동일한 타입에 장착중인 장비 찾기
                Equipment? findEquipment = PlayerInfo.Inventory.inventory
                .OfType<Equipment>()
                .Where(findItem => findItem != this) // 자기 자신 제외
                .FirstOrDefault(findItem => findItem.EquipmentType == equipmentItem.EquipmentType && findItem.IsEquip);

                if (findEquipment != null)
                {
                    findEquipment.IsEquip = false;
                    Console.WriteLine($"착용 중인 {findEquipment.Name}(이/가) 해제되었습니다.");
                }
            }

            if (IsEquip)
            {
                Console.WriteLine($"{Name}(이/가) 장착되었습니다.");
            }
            else
            {
                Console.WriteLine($"{Name}(이/가) 해제되었습니다.");
            }
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

        public void ItemEvent()
        {

        }
    }
}
