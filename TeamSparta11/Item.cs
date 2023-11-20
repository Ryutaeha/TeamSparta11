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
        int EquipmentType { get; }
        bool IsEquip { get; set; }
        int MaxHP { get; }
        int Speed { get; }
        int AD { get; }
        int DF { get; }

        public override Equipment? ItemAdd(int Index)
        {
            DataRow? itemdata = Date.ItemDataTable.Rows.Find(Index);

            ItemIndex = Convert.ToInt32(itemdata["ItemIndex"]);
            Name = itemdata["Name"].ToString();
            Explain = itemdata["Explain"].ToString();
            ItemType = Convert.ToInt32(itemdata["ItemType"]);
            ItemPrice = Convert.ToInt32(itemdata["ItemPrice"]);

            if (ItemType == 0)
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
        int EquipmentType { get; }
        bool IsEquip { get; set; }
        int MaxHP { get; }
        int Speed { get; }
        int AD { get; }
        int DF { get; }

        public override Supplies? ItemAdd(int Index)
        {
            DataRow? itemdata = Date.ItemDataTable.Rows.Find(Index);

            ItemIndex = Convert.ToInt32(itemdata["ItemIndex"]);
            Name = itemdata["Name"].ToString();
            Explain = itemdata["Explain"].ToString();
            ItemType = Convert.ToInt32(itemdata["ItemType"]);
            ItemPrice = Convert.ToInt32(itemdata["ItemPrice"]);

            if (ItemType == 1)
            {
                return this;
            }
            return null;
        }

        public override void ItemUse()
        {

        }
    }
    /* - 인벤토리 추가되면 사용할 함수
    public void GetItem(int Index)
    {
        DataRow? itemdata = Date.ItemDataTable.Rows.Find(Index);
        int itemType = Convert.ToInt32(itemdata["ItemType"]);
        switch (itemType)
        {
            case 0:
                Equipment newEquipment = new Equipment();
                Equipment addEquipment = newEquipment.ItemAdd(Index);
                if (addEquipment != null) { inventory.Add(addEquipment); }
                break;
            case 1:
                Supplies newSupplies = new Supplies();
                Supplies addSupplies = newSupplies.ItemAdd(Index);
                if (addSupplies != null) { inventory.Add(addSupplies); }
                break;
            default:
                break;
        }
    }
    */
}
