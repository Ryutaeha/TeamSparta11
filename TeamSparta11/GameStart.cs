using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSparta11
{
    internal class GameStart
    {
        internal void Game()
        {

            while (true)
            {
                Date.Line();
                Console.WriteLine("This is 스파르타 던전");
                Console.WriteLine("원하시는 항목을 선택해주세요\n");


                Console.WriteLine("1. 새게임");
                Console.WriteLine("2. 저장된 게임");
                Console.WriteLine("0. 끝내기\n");

                
                int userSelect = Date.userSelect();
                switch (userSelect)
                {
                    case 1:
                        CreateCharacter();
                        break;
                    case 2:
                        LordCharacter();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("\n번호를 다시 입력해주세요\n");
                        break;
                }
            }
        }

        void CreateCharacter()
        {
            while (true)
            {
                Date.Line();
                Console.WriteLine("\n새로 저장할 슬롯을 선택하세요\n");

                for(int i = 0; i < 3; i++)
                {

                    string resultString = Json.JsonLoad(i) == null
                    ? "저장된 데이터가 없습니다."
                    : $"이름: {Json.JsonLoad(i).Player.name} 직업: {Json.JsonLoad(i).Player.jobClass}";
                    Console.WriteLine(i+1 + ". " + resultString);
                }
                Console.WriteLine("0. 돌아가기\n");
                int userSelect = Date.userSelect();
                Program.saveSlot = userSelect-1;
                switch (userSelect)
                {
                    case 0:
                        return;
                    case 1:
                        if (newGame(Json.JsonLoad(Program.saveSlot), Program.saveSlot)) return;
                        else break;

                    case 2:
                        if (newGame(Json.JsonLoad(Program.saveSlot), Program.saveSlot)) return;
                        else break;
                    case 3:
                        if (newGame(Json.JsonLoad(Program.saveSlot), Program.saveSlot)) return;
                        else break;
                    default:
                        Console.WriteLine("\n번호를 다시 입력해주세요\n");
                        break;
                }
            }
        }

        private bool newGame(SaveData saveData, int SaveSlot)
        {
            if(saveData != null)
            {
                while(true)
                {
                    Console.WriteLine("저장 데이터를 덮어 쓰겠습니까?");
                    Console.WriteLine("1. 예");
                    Console.WriteLine("2. 아니요");
                    int userSelect = Date.userSelect();
                    switch (userSelect)
                    {
                        case 1:
                            Console.Write("\n이름을 입력하세요 : ");
                            string name = Console.ReadLine();
                            Console.Write("\n직업을 입력하세요 : ");
                            string Jobclass = Console.ReadLine();
                            Program.player = new Test.Player(name, Jobclass);
                            Json.JsonSave(SaveSlot);
                            //게임 메인메뉴 위치
                            GameLord();

                            return true;
                        case 2:
                            return false;
                        default:
                            Console.WriteLine("\n번호를 다시 입력해주세요\n");
                            break;
                    }
                }

            }
            else
            {
                Console.Write("\n이름을 입력하세요 : ");
                string name = Console.ReadLine();
                Console.Write("\n직업을 입력하세요 : ");
                string Jobclass = Console.ReadLine();
                Program.player = new Test.Player(name, Jobclass);
                Json.JsonSave(SaveSlot);
                //게임 메인메뉴 위치
                GameLord();
                return true;
            }
        }

        void LordCharacter()
        {
            while (true)
            {
                Date.Line();
                Console.WriteLine("\n저장된 슬롯을 선택하세요\n");

                for(int i = 0; i < 3; i++)
                {
                    string resultString = Json.JsonLoad(i) == null
                    ? "저장된 데이터가 없습니다."
                    : $"이름: {Json.JsonLoad(i).Player.name} 직업: {Json.JsonLoad(i).Player.jobClass}";
                    Console.WriteLine(i+1 + ". " + resultString);
                }
                Console.WriteLine("0. 돌아가기\n");
                int userSelect = Date.userSelect();
                Program.saveSlot = userSelect - 1;
                switch (userSelect)
                {
                    case 0:
                        return;
                    case 1:
                        if (Json.JsonLoad(Program.saveSlot) == null) Console.WriteLine("\n비어있는 슬롯입니다.\n");
                        else if (ChoiceLordSlot(Program.saveSlot)) return;
                        break;
                    case 2:
                        if (Json.JsonLoad(Program.saveSlot) == null) Console.WriteLine("\n비어있는 슬롯입니다.\n");
                        else if (ChoiceLordSlot(Program.saveSlot)) return;
                        break;
                    case 3:
                        if (Json.JsonLoad(Program.saveSlot) == null) Console.WriteLine("\n비어있는 슬롯입니다.\n");
                        else if (ChoiceLordSlot(Program.saveSlot)) return;
                        break;

                    default:
                        Console.WriteLine("\n번호를 다시 입력해주세요\n");
                        break;
                }
                Json.JsonLoad(Program.saveSlot);
            }
        }

        bool ChoiceLordSlot(int saveSlot)
        {
            while (true)
            {
                Date.Line();
                Console.WriteLine($"{saveSlot+1}번 슬롯) 이름: {Json.JsonLoad(saveSlot).Player.name} 직업: {Json.JsonLoad(saveSlot).Player.jobClass}");
                Console.WriteLine("1. 이어하기");
                Console.WriteLine("2. 삭제하기");
                Console.WriteLine("0. 돌아가기");
                int userSelect = Date.userSelect();
                switch (userSelect)
                {
                    case 0:
                        return false;
                    case 1:
                        Program.player = Json.JsonLoad(saveSlot).Player;
                        GameLord();
                        return true;
                    case 2:
                        DeleteCheck();
                        return false;
                    default:
                        Console.WriteLine("\n번호를 다시 입력해주세요\n");
                        break;
                }
            }

        }


        void DeleteCheck()
        {
            while(true)
            {
                Date.Line();
                Console.WriteLine(Program.saveSlot+1+"번 슬롯을 정말로 삭제하시겠습니까?");
                Console.WriteLine("1. 예");
                Console.WriteLine("2. 아니요");
                int userSelect = Date.userSelect();
                switch (userSelect)
                {
                    case 1:
                        Delete();
                        return;
                    case 2:
                        return;
                    default:
                        Console.WriteLine("\n번호를 다시 입력해주세요\n");
                        break;
                }
            }
        }

        void Delete()
        {
            string filePath = "..\\..\\..\\dates\\Save" + Program.saveSlot + ".json";
            File.Delete(filePath);

            Console.WriteLine("파일이 정삭적으로 삭제되었습니다.");
        }

        private void GameLord()
        {
            while (true)
            {
                Date.Line();

                Console.WriteLine("★마을★\n");

                Console.WriteLine("1. 상세정보");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점");
                Console.WriteLine("4. 모험");
                Console.WriteLine("0. 끝내기");
                int userSelect = Date.userSelect();
                switch (userSelect)
                {
                    case 1:
                        //상세정보 메서드 인스턴스화해서 호출
                        break;
                    case 2:
                        //인벤토리 메서드 인스턴스화해서 호출
                        break;
                    case 3:
                        //상점 메서드 인스턴스화해서 호출
                        break;
                    case 4:
                        //모험 메서드 인스턴스화해서 호출
                        break;
                    case 0:
                        Json.JsonSave(Program.saveSlot);
                        //저장및 돌아가기 메서드 인스턴스화해서 호출
                        return;
                    default:
                        Console.WriteLine("\n번호를 다시 입력해주세요\n");
                        break;
                }
            }
        }
    }

    
}
