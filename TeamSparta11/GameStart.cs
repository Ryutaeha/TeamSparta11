﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


using Teamproject;
namespace TeamSparta11
{
    internal class GameStart
    {

        // 첫화면 로딩
        internal void Game()
        {
            while (true)
            {
                Date.Line();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("◆This is 스파르타 던전◆");
                Console.ResetColor();
                Console.WriteLine("원하시는 항목을 선택해주세요\n");


                Console.WriteLine("1. 새게임");
                Console.WriteLine("2. 저장된 게임");
                Console.WriteLine("0. 끝내기\n");

                
                int UserSelect = Date.UserSelect();
                switch (UserSelect)
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

        // 새게임
        void CreateCharacter()
        {
            while (true)
            {
                Date.Line();
                Console.WriteLine("\n새로 저장할 슬롯을 선택하세요\n");

                for(int i = 0; i < 3; i++)
                {
                    
                    if (Json.JsonLoad(i) == null)
                    {
                        Console.WriteLine(i + 1 + ". 저장된 데이터가 없습니다.");
                        
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(i + 1 + $". 이름: {Json.JsonLoad(i).Player.Name} 직업: {Json.JsonLoad(i).Player.Job}");
                        Console.ResetColor() ;
                    }
                }
                Console.WriteLine("0. 돌아가기\n");
                int UserSelect = Date.UserSelect();
                PlayerInfo.saveSlot = UserSelect-1;
                switch (UserSelect)
                {
                    case 0:
                        return;
                    case 1:
                        if (NewGame(Json.JsonLoad(PlayerInfo.saveSlot), PlayerInfo.saveSlot)) return;
                        else break;

                    case 2:
                        if (NewGame(Json.JsonLoad(PlayerInfo.saveSlot), PlayerInfo.saveSlot)) return;
                        else break;
                    case 3:
                        if (NewGame(Json.JsonLoad(PlayerInfo.saveSlot), PlayerInfo.saveSlot)) return;
                        else break;
                    default:
                        Console.WriteLine("\n번호를 다시 입력해주세요\n");
                        break;
                }
            }
        }

        //새게임 생성
        private bool NewGame(SaveDate saveDate, int SaveSlot)                 
        {
            if(saveDate != null)
            {
                while(true)
                {
                    Console.WriteLine("저장 데이터를 덮어 쓰겠습니까?");
                    Console.WriteLine("1. 예");
                    Console.WriteLine("2. 아니요");
                    int UserSelect = Date.UserSelect();
                    switch (UserSelect)
                    {
                        case 1:
                            CreatePlayer();
                            Json.JsonSave(PlayerInfo.saveSlot);
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
                CreatePlayer();
                Json.JsonSave(PlayerInfo.saveSlot);
                //게임 메인메뉴 위치
                GameLord();
                return true;
            }
        }
        void CreatePlayer()
        {
            Console.Write("\n이름을 입력하세요 : ");
            string name = Console.ReadLine();
            Console.WriteLine("\n직업을 선택하세요 : ");
            Console.WriteLine("1. 전사");
            Console.WriteLine("2. 도적");
            Console.WriteLine("3. 마법사");
            int UserSelect = Date.UserSelect();
            Dictionary<int, string[]> jobSkill = null;
            
            if (UserSelect == 1)
            {
                jobSkill = Date.warriorSkill;
            }
            if (UserSelect == 2)
            {
                jobSkill = Date.banditSkill;
            }
            if (UserSelect == 3)
            {
                jobSkill = Date.wizardSkill;
            }
            string[] job = Date.jobClass[UserSelect-1];

            // Random 클래스를 사용하여 무작위로 2개의 인덱스 선택
            Random random = new Random();
            int choice = -1;

            while (PlayerInfo.SkillList.Count < 2)
            {
                int randomIndex = random.Next(jobSkill.Count);
                // 이미 선택한 인덱스인지 확인
                if (!(choice == randomIndex))
                {
                    string[] skillString = jobSkill[randomIndex];
                    Skill skill = new Skill(skillString[0], int.Parse(skillString[1]), int.Parse(skillString[2]), skillString[3]);
                    PlayerInfo.SkillList.Add(skill);
                }
                choice = randomIndex;
            }

            PlayerInfo.Player = new PlayerStatus(name, job[1], int.Parse(job[2]), int.Parse(job[3]), int.Parse(job[4]), int.Parse(job[5]), int.Parse(job[6]), int.Parse(job[7]), int.Parse(job[8]), int.Parse(job[9]), int.Parse(job[10]), int.Parse(job[11]),1);
            PlayerInfo.Inventory = new Inventory(12);
            PlayerInfo.Shop.ShopProductReset();
            PlayerInfo.Inventory.GetItem(0);
            PlayerInfo.Inventory.GetItem(1);

        }
        // 이미 저장되어있는 슬롯 제어
        void LordCharacter()
        {
            while (true)
            {
                Date.Line();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n◆저장된 슬롯을 선택하세요◆\n");
                Console.ResetColor();
                for (int i = 0; i < 3; i++)
                {

                    if (Json.JsonLoad(i) == null)
                    {
                        Console.WriteLine(i + 1 + ". 저장된 데이터가 없습니다.");

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(i + 1 + $". 이름: {Json.JsonLoad(i).Player.Name} 직업: {Json.JsonLoad(i).Player.Job}");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine("0. 돌아가기\n");
                int UserSelect = Date.UserSelect();
                PlayerInfo.saveSlot = UserSelect - 1;
                switch (UserSelect)
                {
                    case 0:
                        return;
                    case 1:
                        if (Json.JsonLoad(PlayerInfo.saveSlot) == null) Console.WriteLine("\n비어있는 슬롯입니다.\n");
                        else if (ChoiceLordSlot(PlayerInfo.saveSlot)) return;
                        break;
                    case 2:
                        if (Json.JsonLoad(PlayerInfo.saveSlot) == null) Console.WriteLine("\n비어있는 슬롯입니다.\n");
                        else if (ChoiceLordSlot(PlayerInfo.saveSlot)) return;
                        break;
                    case 3:
                        if (Json.JsonLoad(PlayerInfo.saveSlot) == null) Console.WriteLine("\n비어있는 슬롯입니다.\n");
                        else if (ChoiceLordSlot(PlayerInfo.saveSlot)) return;
                        break;

                    default:
                        Console.WriteLine("\n번호를 다시 입력해주세요\n");
                        break;
                }
                Json.JsonLoad(PlayerInfo.saveSlot);
            }
        }
        // 저장슬롯 선택시 
        bool ChoiceLordSlot(int saveSlot)
        {
            while (true)
            {
                Date.Line();
                Console.WriteLine($"{saveSlot+1}번 슬롯) 이름: {Json.JsonLoad(saveSlot).Player.Name} 직업: {Json.JsonLoad(saveSlot).Player.Job}");
                Console.WriteLine("1. 이어하기");
                Console.WriteLine("2. 삭제하기");
                Console.WriteLine("0. 돌아가기");
                int UserSelect = Date.UserSelect();
                switch (UserSelect)
                {
                    case 0:
                        return false;
                    case 1:
                        // 세이브 가져오고 싶을 때 여기에 추가하면 됩니다.
                        SaveDate saveDate = Json.JsonLoad(saveSlot);
                        PlayerInfo.Player = saveDate.Player;
                        PlayerInfo.SkillList = saveDate.SkillList;
                        PlayerInfo.ShopProductList = saveDate.ShopProductList;
                        PlayerInfo.Inventory = saveDate.Inventory;
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

        

        //저장 슬롯 삭제
        void DeleteCheck()
        {
            while(true)
            {
                Date.Line();
                Console.WriteLine(PlayerInfo.saveSlot+1+"번 슬롯을 정말로 삭제하시겠습니까?");
                Console.WriteLine("1. 예");
                Console.WriteLine("2. 아니요");
                int UserSelect = Date.UserSelect();
                switch (UserSelect)
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


        //삭제시 나오는 메세지
        void Delete()
        {
            string filePath = "..\\..\\..\\dates\\Save" + PlayerInfo.saveSlot + ".json";
            File.Delete(filePath);

            Console.WriteLine("파일이 정상적으로 삭제되었습니다.");
        }

        //게임 시작시 나오는 화면
        public void GameLord()
        {
            while (true)
            {
                Date.Line();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("★마을★\n");
                Console.ResetColor();
                Console.WriteLine("1. 상세정보");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점");
                Console.WriteLine("4. 모험");
                Console.WriteLine("0. 끝내기");
                int UserSelect = Date.UserSelect();
                switch (UserSelect)
                {
                    case 1:
                        PlayerInfomation();
                        break;
                    case 2:
                        //인벤토리 메서드 인스턴스화해서 호출
                        InvetoryDisplay();
                        break; 
                    case 3:
                        //상점 메서드 인스턴스화해서 호출
                        ShopMainDisplay();
                        break;
                    case 4:
                        
                        BattleNew battleNew = new BattleNew();
                        bool isDead = battleNew.Battle();
                        if (isDead) break;
                        else return;
                        
                    case 0:
                        Json.JsonSave(PlayerInfo.saveSlot);
                        PlayerInfo.Inventory = null;
                        PlayerInfo.SkillList.Clear();
                        PlayerInfo.Player = null;
                        PlayerInfo.Inventory = null;
                        PlayerInfo.ShopProductList = null;
                        //저장및 돌아가기 메서드 인스턴스화해서 호출
                        return;

                     default:
                        Console.WriteLine("\n번호를 다시 입력해주세요\n");
                        break;
                }
            }
        }
        

        private void InvetoryDisplay()

        {
            Console.Clear();
            while (true)
            {
                int equipmentItemCount = PlayerInfo.Inventory.ItemCount[(int)Date.ItemType.Equipment];
                //int suppliesItemCount = PlayerInfo.Inventory.ItemCount[(int)Date.ItemType.Supplies];

                Console.WriteLine("인벤토리");
                Console.WriteLine("보유 중인 아이템을 확인 할 수 있습니다.");
                Console.WriteLine("");
                Console.WriteLine("--- 장비 아이템 ---");
                for (int i = 0; i < equipmentItemCount; i++)
                {
                    Item currentItem = PlayerInfo.Inventory.EquipmentInventory[i];

                    Console.WriteLine($"- {currentItem.Name} | {currentItem.Explain}");
                }
                //Console.WriteLine("\n--- 소비 아이템 ---");
                //for (int i = 0; i < suppliesItemCount; i++)
                //{
                //    Item currentItem = PlayerInfo.Inventory.SuppliesInventory[i];

                //    Console.WriteLine($"- {currentItem.Name} | {currentItem.Explain}");
                //}
                Console.WriteLine("");
                Console.WriteLine("1. 장비 장착하기");
                Console.WriteLine("0. 나가기");
                int userSelect = Date.UserSelect();

                switch (userSelect)
                {
                    case 1:
                        ItemUseDisplay();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("\n번호를 다시 입력해주세요\n");
                        break;
                }
            }
            
        }

        private void ItemUseDisplay()
        {
            Console.Clear();
            while (true)
            {
                int equipmentItemCount = PlayerInfo.Inventory.ItemCount[(int)Date.ItemType.Equipment];

                Console.WriteLine("장착 / 사용할 아이템의 번호를 입력해주세요.");
                Console.WriteLine("");
                Console.WriteLine("--- 장비 아이템 ---");
                for (int i = 0; i < equipmentItemCount; i++)
                {
                    Item currentItem = PlayerInfo.Inventory.EquipmentInventory[i];

                    Console.WriteLine($"- {i + 1}. {currentItem.Name} | {currentItem.Explain}");
                }
                Console.WriteLine("");
                Console.WriteLine("0. 나가기");
                int userSelect = Date.UserSelect();
                if (userSelect == 0)
                {
                    return;
                }
                else
                {
                    PlayerInfo.Inventory.ItemUse(userSelect - 1);
                }
            }

        }

        private void ShopMainDisplay()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("상점");
                Console.WriteLine("아이템을 구매 및 판매할 수 있습니다.");
                Console.WriteLine("구입 가능한 물품은 ???마다 갱신됩니다.");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("1. 구매하기");
                Console.WriteLine("2. 판매하기");
                Console.WriteLine("0. 나가기");
                int userSelect = Date.UserSelect();

                switch (userSelect)
                {
                    case 1:
                        ShopBuyDisplay();
                        break;
                    case 2:
                        ShopSellDisplay();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("\n번호를 다시 입력해주세요\n");
                        break;
                }
            }
        }

        private void ShopBuyDisplay()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("상점 - 구매하기");
                Console.WriteLine("구매할 아이템의 번호를 입력해주세요.");
                Console.WriteLine("");
                for (int i = 0; i < PlayerInfo.ShopProductList.Count; i++)
                {
                    ShopProduct currentProduct = PlayerInfo.ShopProductList[i];

                    Console.WriteLine($"- {i + 1}. {currentProduct.ProductItemName()} | {currentProduct.ShopExplain} | 가격 : {currentProduct.ProductPrice} Gold");
                }
                Console.WriteLine("");
                Console.WriteLine("0. 나가기");
                int userSelect = Date.UserSelect();
                if (userSelect == 0)
                {
                    return;
                }
                else
                {
                    PlayerInfo.Shop.ProductBuy(userSelect - 1);
                }
            }
        }
        private void ShopSellDisplay()
        {
            Console.Clear();
            while (true)
            {
                int equipmentItemCount = PlayerInfo.Inventory.ItemCount[(int)Date.ItemType.Equipment];

                Console.WriteLine("상점 - 판매하기");
                Console.WriteLine("판매할 아이템의 번호를 입력해주세요.");
                Console.WriteLine("");
                for (int i = 0; i < equipmentItemCount; i++)
                {
                    Item currentItem = PlayerInfo.Inventory.EquipmentInventory[i];

                    Console.WriteLine($"- {i + 1}. {currentItem.Name} | {currentItem.Explain} | 판매 가격 {currentItem.ItemPrice} Gold");
                }
                Console.WriteLine("");
                Console.WriteLine("0. 나가기");
                int userSelect = Date.UserSelect();
                if (userSelect == 0)
                {
                    return;
                }
                else
                {
                    PlayerInfo.Inventory.ItemSell(userSelect - 1);
                }
            }
        }
        public void PlayerInfomation()
        {
            Date.Line();

            Console.WriteLine($"\nLV. {PlayerInfo.Player.Level}  {PlayerInfo.Player.Name} ({PlayerInfo.Player.Job})     현재 스테이지 : {PlayerInfo.Player.Stage}");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"HP : {PlayerInfo.Player.HP} / {PlayerInfo.Player.MaxHP}\t  ");
            Console.ResetColor();
            Console.ForegroundColor= ConsoleColor.Blue;
            Console.WriteLine($"MP : {PlayerInfo.Player.MP} / {PlayerInfo.Player.MaxMP}");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine($"공격력 : {PlayerInfo.Player.AD}    방어력 : {PlayerInfo.Player.DF}    스피드 : {PlayerInfo.Player.Speed}");
            Console.WriteLine();
            Console.WriteLine($"현재 경험치 : {PlayerInfo.Player.EXP}        골드 : {PlayerInfo.Player.Gold}\n");
            Console.WriteLine("현재 가지고 있는 스킬 목록\n");
            for(int i = 0; i <PlayerInfo.SkillList.Count; i++)
            {
                Console.WriteLine($"스킬명 : {PlayerInfo.SkillList[i].Name.PadRight(10)} 데미지 : {PlayerInfo.SkillList[i].Ability} 마나 소모량 : {PlayerInfo.SkillList[i].Cost} 설명 : {PlayerInfo.SkillList[i].SkillInfo}");
            }

            Console.WriteLine("\n장착중인 장비");
            if (PlayerInfo.Inventory.EquippedItem[0] == null) Console.WriteLine("장착중인 장비 없음");
            else Console.WriteLine($"이름 : {PlayerInfo.Inventory.EquippedItem[0].Name}       공격력 : {PlayerInfo.Inventory.EquippedItem[0].AD}");
        }
    }
}
