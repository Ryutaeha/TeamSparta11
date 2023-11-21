﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Teamproject;
using TeamSparta11;

// 몬스터 정보나 기타 등등의 일반적인 데이터를 담는 클래스
internal class Date
{
    internal enum ItemType { equipment, supplies }

    internal static int UserSelect()
    {
        Console.Write("입력 > ");
        if (int.TryParse(Console.ReadLine(), out int userInput)) return userInput; 
        else return -1;



    }

    public static DataTable ItemDateTable = new DataTable();
    public static DataTable EquipmentDateTable = new DataTable();
    public static DataTable SuppliesDateTable = new DataTable();

    internal static void ItemDateTableSetting()
    {
        // 테이블 컬럼 생성 및 기본키 지정
        #region
        Action<DataTable, string, Type> addColumn = (table, columnName, columnType) =>
        {
            table.Columns.Add(columnName, columnType);
        };

        addColumn(ItemDateTable, "ItemIndex", typeof(int));
        addColumn(ItemDateTable, "Name", typeof(string));
        addColumn(ItemDateTable, "Explain", typeof(string));
        addColumn(ItemDateTable, "ItemType", typeof(int));
        addColumn(ItemDateTable, "ItemPrice", typeof(int));

        DataColumn[] ItemDateTableKey = new DataColumn[1];
        ItemDateTableKey[0] = ItemDateTable.Columns["ItemIndex"];
        ItemDateTable.PrimaryKey = ItemDateTableKey;

        addColumn(EquipmentDateTable, "EquipmentIndex", typeof(int));
        addColumn(EquipmentDateTable, "EquipmentType", typeof(int));
        addColumn(EquipmentDateTable, "MaxHP", typeof(int));
        addColumn(EquipmentDateTable, "MaxMp", typeof(int));
        addColumn(EquipmentDateTable, "Speed", typeof(int));
        addColumn(EquipmentDateTable, "AD", typeof(int));
        addColumn(EquipmentDateTable, "DF", typeof(int));

        DataColumn[] EquipmentDateTableKey = new DataColumn[1];
        EquipmentDateTableKey[0] = EquipmentDateTable.Columns["EquipmentIndex"];
        EquipmentDateTable.PrimaryKey = EquipmentDateTableKey;

        #endregion

        // 아이템 데이터 테이블
        // { Index, Name, Explain, ItemType, ItemPrice }
        ItemDateTable.Rows.Add(new object[] { 0, "나무 칼", "나무로 만든 칼", 0, 20 });
        ItemDateTable.Rows.Add(new object[] { 1, "돌 칼", "돌로 만든 칼", 0, 20 });
        ItemDateTable.Rows.Add(new object[] { 2, "체력 포션", "기초적인 체력포션이다", 1, 50 });

        // 장비 아이템 스텟 테이블
        // { Index, EquipmentType, MaxHP, MaxMp, Speed, AD, DF }
        EquipmentDateTable.Rows.Add(new object[] { 0, 0, 0, 0, 0, 5, 0 });
        EquipmentDateTable.Rows.Add(new object[] { 1, 0, 0, 0, 0, 10, 0 });
    }

    // 몬스터 정리
    /// <summary>
    /// 키값,{몬스터이름, 레벨, 최대체력 , 현재체력 , 공격력 , 방어력 , 속도 , 경험치 , 골드} 
    /// </summary>
    public static Dictionary<int, string[]> goblin = new Dictionary<int, string[]>
    {
        { 0 , new string[] { "칼 고블린", "1", "10","10","5", "1" ,"1", "1", "10"} },
        { 1 , new string[] { "방패 고블린", "3", "30", "30", "3", "5" ,"1", "2", "15" } },
        { 2 , new string[] { "장로 고블린", "5", "50", "50", "5", "3", "1", "3", "20" } }
       
    };
    /// <summary>
    /// 키값,{몬스터이름, 레벨, 최대체력 , 현재체력 , 공격력 , 방어력 , 속도 , 경험치 , 골드} 
    /// </summary>
    public static Dictionary<int, string[]> golem = new Dictionary<int, string[]>
    {
        { 0 , new string[] { "점토 골렘", "11", "60","60","10", "3" ,"1", "6", "30"} },
        { 1 , new string[] { "다크 골렘", "13", "80", "80", "13", "5" ,"1", "7", "35" } },
        { 2 , new string[] { "강철 골렘", "15", "100", "100", "15", "7", "1", "8", "40" } }
       
    };
    /// <summary>
    /// 키값,{몬스터이름, 레벨, 최대체력 , 현재체력 , 공격력 , 방어력 , 속도 , 경험치 , 골드} 
    /// </summary>
    public static Dictionary<int, string[]> dragon = new Dictionary<int, string[]>
    {
        { 0 , new string[] { "레드 드래곤", "21", "100","100","15", "5" ,"2", "12", "50"} },
        { 1 , new string[] { "그린 드래곤", "23", "125", "125", "17", "5" ,"2", "13", "55" } },
        { 2 , new string[] { "블루 드래곤", "25", "150", "150", "19", "7", "2", "14", "60" } }
        
    };
    /// <summary>
    /// 키값,{몬스터이름, 레벨, 최대체력 , 현재체력 ,최대마나 ,현재마나, 공격력 , 방어력 , 속도 , 경험치 , 골드, 드랍아이템} 
    /// </summary>
    public static Dictionary<int, string[]> boss = new Dictionary<int, string[]>
    {
        { 0 , new string[] { "킹 고블린","10", "100", "100", "50", "50", "25", "10", "2", "10", "100", "?" } }, 
        { 1 , new string[] { "다이아 골렘","20", "200", "200", "100", "100", "50", "20", "2", "20", "200", "?" } },
        { 2 , new string[] { "다크 드래곤", "30", "300", "300", "150", "150", "75", "30", "3", "30", "300", "?" } }
    
    };




    //직업 정리
    /// <summary>
    /// 키값,{캐릭터이름, 직업, 레벨, 최대체력 , 현재체력 ,최대마나, 현재마나, 공격력 , 방어력 , 속도 , 경험치 , 골드} 
    /// </summary>
    public static Dictionary<int, string[]> jobClass = new Dictionary<int, string[]>
    {
        { 0 , new string[] {"", "전사", "1", "120","120", "50","50", "10", "2", "1", "0","100" } }, //전사 
        { 1 , new string[] { "", "도적", "1", "100", "100", "50", "50", "12", "1", "1", "0", "100" } }, //도적
        { 2 , new string[] { "", "마법사", "1", "100", "100", "70", "70", "8", "1", "1", "0", "100" } } //마법사

    };       


    internal static void Line()
    {
        Console.WriteLine("\n----------------------------------------------------------------\n");
    }

    //플레이어 생성시 해당 스킬중 랜덤 2가지 획득
    /// <summary>
    /// 키값, {스킬이름, 데미지, 코스트, 설명}
    /// </summary>
    internal static Dictionary<int, string[]> warriorSkill = new Dictionary<int, string[]>
    {
        { 0 , new string[] {"강타", "3", "5", "쌔게때리기"} },
        { 1 , new string[] {"돌진", "6", "8", "전장으로~"} },
        { 2 , new string[] {"마무리 일격", "10", "13", "아직 한발 남았다"} },
        { 3 , new string[] {"두개골 부시기", "15", "17", "뚝!빼기"} }
    };
    internal static Dictionary<int, string[]> banditSkill = new Dictionary<int, string[]>
    {
        { 0 , new string[] {"수리검", "3", "5", "빠른 수리검"} },
        { 1 , new string[] {"암습", "6", "8", "보이지 않는 검이 가장 무서운 법" } },
        { 2 , new string[] {"화둔", "10", "13", "아마테라스"} },
        { 3 , new string[] {"나X환", "15", "17", "졸렬한 풀 냄새가 난다"} }
    };
    internal static Dictionary<int, string[]> wizardSkill = new Dictionary<int, string[]>
    {
        { 0 , new string[] {"지팡이 던지기(물리)", "3", "5", "마법사(물리)"} },
        { 1 , new string[] {"화염구", "6", "8", "단단묵직"} },
        { 2 , new string[] {"물벼락", "10", "13", "X북이 물대포!"} },
        { 3 , new string[] { "블랙홀", "15", "17", "히어로스 오브 더 X톰" } }
    };


}
//세이브시 저장될 목록
internal class SaveDate
{
    public PlayerStatus Player { get; set; }
    public List<Skill> SkillList { get; set; }
    //public Inventory Inventory { get; set; }
}
//세이브 가져올 객체 모음
internal class PlayerInfo
{
    //가지고 있는 스킬 목록
    public static List<Skill> SkillList = new List<Skill>();
    //새로 만들거나 로드해올 때 끌어다 쓸 객체
    public static PlayerStatus Player = null;
    //저장 슬롯
    public static int saveSlot;
    //유저의 인벤토리 클래스, 매개변수는 인벤토리 크기이며 현재는 따로 변수가 없어 직접 지정했습니다.
    public static Inventory Inventory = new Inventory(12);

}