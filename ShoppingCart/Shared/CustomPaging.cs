using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.Shared
{
    public class CustomPaging
    {
        public int ListCount { get; set; }
        public List<Product> PagedList(List<Product> productList, int pageNumber, int pageSize)
        {
            ListCount = productList.Count;
            int startIndex = (pageNumber - 1) * pageSize;
            int endIndex = startIndex + pageSize - 1;
            List<Product> pageProductList = new List<Product>();
            for (int i = startIndex; i <= endIndex; i++)
            {
                if (i == ListCount)
                {
                    break;
                }
                pageProductList.Add(productList[i]);
            }
            return pageProductList;
        }
    }
}