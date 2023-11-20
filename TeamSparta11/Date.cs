using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

// 몬스터 정보나 기타 등등의 일반적인 데이터를 담는 클래스


internal static class Date
{
    internal enum ItemType { equipment, supplies }

    internal static int userSelect()
    {
        Console.Write("입력 > ");
        if (int.TryParse(Console.ReadLine(), out int userInput)) return userInput;
        else return -1;

    }

    public static DataTable ItemDataTable = new DataTable();
    public static DataTable SuppliesDataTable = new DataTable();

    internal static void ItemDataTableSetting()
    {
        Action<DataTable, string, Type> addColumn = (table, columnName, columnType) =>
        {
            table.Columns.Add(columnName, columnType);
        };

        // 아이템 테이블 컬럼 생성 및 기본키 지정
        addColumn(ItemDataTable, "ItemIndex", typeof(int));
        addColumn(ItemDataTable, "Name", typeof(string));
        addColumn(ItemDataTable, "Explain", typeof(string));
        addColumn(ItemDataTable, "ItemType", typeof(int));
        addColumn(ItemDataTable, "ItemPrice", typeof(int));

        DataColumn[] ItemDataTableKey = new DataColumn[1];
        ItemDataTableKey[0] = ItemDataTable.Columns["ItemIndex"];
        ItemDataTable.PrimaryKey = ItemDataTableKey;

        // { Index, Name, Explain, ItemType, ItemPrice, EquipmentType, MaxHP, Speed, AD, DF }
        ItemDataTable.Rows.Add(new object[] { 0, "나무 칼", "나무로 만든 칼", 0, 20 });
        ItemDataTable.Rows.Add(new object[] { 1, "돌 칼", "돌로 만든 칼", 0, 20 });
        ItemDataTable.Rows.Add(new object[] { 2, "체력 포션", "기초적인 체력포션이다", 1, 50 });

        // 장비 아이템 스텟 테이블
        //addColumn(equipmentDataTable, "EquipmentType", typeof(int));
        //addColumn(equipmentDataTable, "MaxHP", typeof(int));
        //addColumn(equipmentDataTable, "Speed", typeof(int));
        //addColumn(equipmentDataTable, "AD", typeof(int));
        //addColumn(equipmentDataTable, "DF", typeof(int));
    }
}

