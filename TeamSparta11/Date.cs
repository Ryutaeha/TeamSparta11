using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 몬스터 정보나 기타 등등의 일반적인 데이터를 담는 클래스
internal static class Date
{
    internal static int userSelect(string Input)
    {
        if (int.TryParse(Input, out int userInput)) return userInput;
        else return -1;
        
    }


    
    
    // 몬스터 정리
    public static Dictionary<int, string[]> goblin = new Dictionary<int, string[]>
    {
        { 0 , new string[] { "칼 고블린", "1", "10","10","5", "1" ,"1", "?", "?"} },
        { 1 , new string[] { "방패 고블린", "3", "30", "30", "3", "5" ,"1", "?", "?" } },
        { 2 , new string[] { "장로 고블린", "5", "50", "50", "5", "3", "1", "?", "?" } }
       
    };

    public static Dictionary<int, string[]> golem = new Dictionary<int, string[]>
    {
        { 0 , new string[] { "점토 골렘", "11", "60","60","10", "3" ,"1", "?", "?"} },
        { 1 , new string[] { "다크 골렘", "13", "80", "80", "13", "5" ,"1", "?", "?" } },
        { 2 , new string[] { "강철 골렘", "15", "100", "100", "15", "7", "1", "?", "?" } }
       
    };

    public static Dictionary<int, string[]> dragon = new Dictionary<int, string[]>
    {
        { 0 , new string[] { "레드 드래곤", "21", "100","100","15", "5" ,"2", "?", "?"} },
        { 1 , new string[] { "그린 드래곤", "23", "125", "125", "17", "5" ,"2", "?", "?" } },
        { 2 , new string[] { "블루 드래곤", "25", "150", "150", "19", "7", "2", "?", "?" } }
        
    };

    public static Dictionary<int, string[]> boss = new Dictionary<int, string[]>
    {
        { 0 , new string[] { "킹 고블린","10", "100", "100", "50", "50", "15", "5", "2", "?", "?", "?" } }, 
        { 1 , new string[] { "다이아 골렘","20", "200", "200", "100", "100", "20", "10", "2", "?", "?", "?" } },
        { 2 , new string[] { "다크 드래곤", "30", "300", "300", "150", "150", "25", "15", "3", "?", "?", "?" } }
    
    };




    //직업 정리
    public static Dictionary<int, string[]> jobClass = new Dictionary<int, string[]>
    {
        { 0 , new string[] {"", "", "1", "150","150", "50","50", "10", "2", "1", "100","0" } }, //전사 
        { 1 , new string[] { "", "", "1", "100", "100", "50", "50", "15", "1", "2", "100", "0" } }, //도적
        { 2 , new string[] { "", "", "1", "100", "100", "100", "100", "5", "1", "1", "100", "0" } } //마법사

    };

    
    //직업별 레벨업당 스탯 정리 
    public static Dictionary<int, int[]> playerUpStatus = new Dictionary<int, int[]>
    {
        { 0 , new int[] { } }, //전사 
        { 1 , new int[] {  } }, //도적
        { 2 , new int[] {  } } //마법사

    };

}

