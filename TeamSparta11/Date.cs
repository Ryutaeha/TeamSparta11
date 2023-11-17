using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 몬스터 정보나 기타 등등의 일반적인 데이터를 담는 클래스


internal static class Date
{
    internal static int userSelect()
    {
        Console.Write("입력 > ");
        if (int.TryParse(Console.ReadLine(), out int userInput)) return userInput;
        else return -1;

    }


    internal static void ItemDataTableSetting()
    {
        DataTable equipmentDataTable = new DataTable();
        DataTable SuppliesDataTable = new DataTable();

        Action<DataTable, string, Type> addColumn = (table, columnName, columnType) =>
        {
            table.Columns.Add(columnName, columnType);
        };

        addColumn(equipmentDataTable, "ItemIndex", typeof(int));
        addColumn(equipmentDataTable, "Name", typeof(string));
        addColumn(equipmentDataTable, "Explain", typeof(string));
        addColumn(equipmentDataTable, "ItemType", typeof(int));
        addColumn(equipmentDataTable, "ItemPrice", typeof(int));

        addColumn(equipmentDataTable, "EquipmentType", typeof(int));
        addColumn(equipmentDataTable, "MaxHP", typeof(int));
        addColumn(equipmentDataTable, "Speed", typeof(int));
        addColumn(equipmentDataTable, "AD", typeof(int));
        addColumn(equipmentDataTable, "DF", typeof(int));

        // { Index, Name, Explain, ItemType, ItemPrice, EquipmentType, MaxHP, Speed, AD, DF }
        equipmentDataTable.Rows.Add(new object[] { 0, "나무 칼", "나무로 만든 칼", 0, 20, 0, 0, 0, 5, 0});
    }
}

