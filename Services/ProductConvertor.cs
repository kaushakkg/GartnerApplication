using ConsoleApp1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class ProductConvertor
    {
        public static List<Product1> ToProduct1(List<Product2> products2)
        {
            List<Product1> products1 = new List<Product1>();
            foreach (var _product2 in products2)
            {
                products1.Add(new Product1()
                {
                    Title = _product2.name,
                    Categories = _product2.tags.Split(','),
                    Twitter = _product2.twitter
                });
            }
            return products1;
        }
    }
}
