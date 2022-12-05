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
            foreach (Product prod in products)
            {
                if (prod.Compare(product))
                {
                    prod.Num += product.Num;
                    return;
                }
            }
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

        public void DeleteAll()
            => products.Clear();

        public void DeleteProduct(int id)
        {
            Console.Clear();
            try
            {
                products.RemoveAt(id - 1);
                for (int i = id - 1; i < products.Count; i++)
                {
                    products[i].Id--;
                }
                tId--;
                Console.WriteLine("Удалено");
                Console.Read();
            }
            catch
            {
                Console.WriteLine("Отменено");
                Console.Read();
            }
        }
    }
}
