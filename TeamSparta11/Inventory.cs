using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSparta11
{
    internal class Inventory
    {
        public int ItemCount { get; private set; }
        public int MaxItemIndex { get; private set; }
        public List<Item> inventory { get; private set; }

        public Inventory(int volume) 
        {
            MaxItemIndex = volume;
            inventory = new List<Item>();
        }

        public void GetItem(int Index, int piece = 1)
        {
            DataRow? itemdata = Date.ItemDataTable.Rows.Find(Index);
            int itemType = Convert.ToInt32(itemdata["ItemType"]);

            switch (itemType)
            {
                case (int)Date.ItemType.equipment:
                    Equipment newEquipment = new Equipment();
                    Equipment addEquipment = newEquipment.ItemAdd(Index);
                    if (addEquipment != null) 
                    { 
                        inventory.Add(addEquipment);
                        ItemCount++;
                    }
                    break;
                // 소모품일 경우 최대 갯수에 도달했는지 확인하여 기존 슬롯의 갯수를 늘려준다.
                case (int)Date.ItemType.supplies:
                    Supplies newSupplies = new Supplies();
                    Supplies addSupplies = newSupplies.ItemAdd(Index);
                    if (addSupplies != null)
                    {
                        if (inventory[ItemCount - 1] != null)
                        {
                            Supplies amountFixedItem = inventory[ItemCount - 1] as Supplies;
                            if (amountFixedItem.Amount < amountFixedItem.MaxAmount)
                            {
                                amountFixedItem.ItemAmountModify(piece);
                                break;
                            }
                        }
                        else
                        {
                            inventory[ItemCount] = addSupplies;
                            ItemCount++;
                        }
                        
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
