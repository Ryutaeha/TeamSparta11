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
            Console.WriteLine("This is 스파르타 던전");
            Console.WriteLine("원하시는 항목을 선택해주세요");

            Console.WriteLine("1. 새게임");
            Console.WriteLine("2. 이어하기");
            Console.WriteLine("3. 끝내기");
            while (true)
            {
                int userSelect = Date.userSelect(Console.ReadLine());
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
            throw new NotImplementedException();
        }

        private void LordCharacter()
        {
            throw new NotImplementedException();
        }

    }
}
