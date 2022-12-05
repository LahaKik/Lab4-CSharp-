using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба4_CSharp_
{
    public class ListProducts
    {
        private static ListProducts _instance;
        public static ListProducts Instance => _instance ??= new ListProducts();


        private List<Product> products = new List<Product>();
        private int tId = 1;

        public void AddProduct(Product product)
        {
            products.Add(product);
            product.Id = tId;
            tId++;
        }

        public void Print()
        {
            Console.Clear();
            Console.WriteLine("ID\tНазвание продукта\tВес\tЦена\tКоличество\tДата, когда товар испортится\tЕсть ли скидка");
            foreach (Product product in products)
            {
                product.Print();
            }
        }
        public string PrintInFile()
        {
            string str = "";
            foreach (Product product in products)
            {
                str += product.PrintInFile() + "\r\n";
            }
            return str;
        }
    }
}
