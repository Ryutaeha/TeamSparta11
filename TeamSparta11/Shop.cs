using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSparta11
{
    internal class ShopProduct
    {
        //public int ShopCategory { get; set; }
        public int ProductIndex { get; private set; }
        public int ItemIndex { get; private set; }
        public int ProductPrice { get; private set; }
        public string ShopExplain { get; private set; }

        public ShopProduct CreateShopProduct(int index)
        {
            DataRow? itemData = Date.ShopDateTable.Rows.Find(index);

            ProductIndex = Convert.ToInt32(itemData["ProductIndex"]);
            ItemIndex = Convert.ToInt32(itemData["ItemIndex"]);
            ProductPrice = Convert.ToInt32(itemData["ProductPrice"]);
            ShopExplain = itemData["ShopExplain"].ToString();

            return this;
        }

        public string ProductItemName()
        {
            DataRow? itemData = Date.ItemDateTable.Rows.Find(ItemIndex);

            return itemData["Name"].ToString();
        }
    }

    internal class Shop
    {
        public Shop()
        {
            
        }

        public void ShopProductReset()
        {
            PlayerInfo.ShopProductList.Clear();
            object[] tableObj = Date.ShopDateTable.Select().Select(table => table["ProductIndex"]).ToArray();
            int[] indexArr = tableObj.Cast<int>().ToArray();

            foreach (int index in indexArr)
            {
                ShopProduct newProduct = new ShopProduct();
                ShopProduct addProduct = newProduct.CreateShopProduct(index);
                PlayerInfo.ShopProductList.Add(addProduct);
            }
        }

        public void ProductBuy(int index)
        {
            ShopProduct buySelectProduct = PlayerInfo.ShopProductList[index];

            if (buySelectProduct.ProductPrice > PlayerInfo.Player.Gold)
            {
                Console.WriteLine("소지금이 부족합니다.");
            }
            else
            {
                PlayerInfo.Player.Gold -= buySelectProduct.ProductPrice;
                PlayerInfo.Inventory.GetItem(buySelectProduct.ItemIndex);
                Console.WriteLine($"{buySelectProduct.ProductItemName()}을 구매했습니다. 남은 소지금 : {PlayerInfo.Player.Gold} Gold");
            }
        }
    }
}
