using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 몬스터 정보나 기타 등등의 일반적인 데이터를 담는 클래스
internal class Date
{
    internal static int userSelect()
    {
        Console.Write("입력 > ");
        if (int.TryParse(Console.ReadLine(), out int userInput)) return userInput; 
        else return -1;

    }
    internal static void Line()
    {
        Console.WriteLine("\n----------------------------------------------------------------\n");
    }
}

internal class SaveData
{

    public Test.Player Player { get; set; }
}