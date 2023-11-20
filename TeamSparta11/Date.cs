using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teamproject;

// 몬스터 정보나 기타 등등의 일반적인 데이터를 담는 클래스
internal class Date
{
    internal static int userSelect()
    {
        Console.Write("입력 > ");
        if (int.TryParse(Console.ReadLine(), out int userInput)) return userInput; 
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

    internal static void Line()
    {
        Console.WriteLine("\n----------------------------------------------------------------\n");
    }

    //플레이어 생성시 해당 스킬중 랜덤 2가지 획득
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

internal class SaveData
{
    public PlayerStatus Player { get; set; }
    public List<Skill> SkillList { get; set; }
}

internal class PlayerInfo
{
    //가지고 있는 스킬 목록
    public static List<Skill> SkillList = new List<Skill>();
    //새로 만들거나 로드해올 때 끌어다 쓸 객체
    public static PlayerStatus player = null;
    //저장 슬롯
    public static int saveSlot;

}