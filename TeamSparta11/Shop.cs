using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSparta11
{
    internal class ShopProduct
    {
        public int ShopCategory { get; set; }
        public int ProductIndex { get; set; }
        public int ItemIndex { get; set; }
        public int Stock { get; set; }
        public string ShopExplain { get; set; }
    }

    internal class Shop
    {
        public List<ShopProduct> ShopProductList;

        public Shop()
        {
            ShopProductList = new List<ShopProduct>();
        }


    }
}
