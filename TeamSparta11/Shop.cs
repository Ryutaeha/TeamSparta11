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
        public int ProductIndex { get; set; }
        public int ItemIndex { get; set; }
        public int ProductPrice { get; set; }
        public string ShopExplain { get; set; }

        public ShopProduct CreateShopProduct(int index)
        {
            DataRow? itemData = Date.ShopDateTable.Rows.Find(index);

            ProductIndex = Convert.ToInt32(itemData["ProductIndex"]);
            ItemIndex = Convert.ToInt32(itemData["ItemIndex"]);
            ProductPrice = Convert.ToInt32(itemData["ProductPrice"]);
            ShopExplain = itemData["ShopExplain"].ToString();

            return this;
        }
    }

    internal class Shop
    {
        public List<ShopProduct> shopProductList;

        public Shop(int productLimit)
        {
            shopProductList = new List<ShopProduct>();
        }

        public void ShopProductReset()
        {
            shopProductList.Clear();
            object[] tableObj = Date.ShopDateTable.Select().Select(table => table["ProductIndex"]).ToArray();
            int[] indexArr = tableObj.Cast<int>().ToArray();

            foreach (int index in indexArr)
            {
                ShopProduct newProduct = new ShopProduct();
                ShopProduct addProduct = newProduct.CreateShopProduct(index);
                shopProductList.Add(addProduct);
            }
        }
    }
}
