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
                Console.WriteLine("This is 스파르타 던전");
                Console.WriteLine("원하시는 항목을 선택해주세요\n");


                Console.WriteLine("1. 새게임");
                Console.WriteLine("2. 이어하기");
                Console.WriteLine("3. 끝내기\n");

                
                int userSelect = Date.userSelect();
                switch (userSelect)
                {
                    case 1:
                        CreateCharacter();
                        break;
                    case 2:
                        LordCharacter();
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("번호를 다시 입력해주세요");
                        break;
                }
            }
        }

        private void CreateCharacter()
        {
            Console.WriteLine("저장 슬롯을 선택하세요");

            Console.WriteLine("1. ");
            Console.WriteLine("2. ");
            Console.WriteLine("3. ");
            while (true)
            {
                int userSelect = Date.userSelect();
                switch (userSelect)
                {
                    case 1:

                        break;
                    case 2:

                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("번호를 다시 입력해주세요");
                        break;
                }
            }
        }

        private void LordCharacter()
        {
            throw new NotImplementedException();
        }

    }
}
