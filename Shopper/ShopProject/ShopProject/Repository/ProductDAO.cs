using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopProject.Repository
{
    public class ProductDAO
    {
        public string formatNumber(string strNum)
        {
            string newNum = String.Format("{0:0,0}", Int32.Parse(strNum));
            return newNum;
        }
    }
}