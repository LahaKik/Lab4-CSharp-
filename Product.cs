namespace Лаба4_CSharp_
{
    public class Product
    {
        public int Id;

        public string Name;
        public float Weight;
        public float Price;
        public int Num;
        public Date EndDate;
        public bool Sale;

        public Product(string name, float weight, float price, int num, Date endDate, bool sale)
        {
            Name = name;
            Weight = weight;
            Price = price;
            Num = num;
            EndDate = endDate;
            Sale = sale;
        }

        public void Print()
            => Console.WriteLine(Id + "\t" + Name + "\t\t\t" + Weight + "\t" + Price + "\t" + Num + "\t\t" + EndDate.ToString() + "\t\t\t\t" + Sale);

        internal string PrintInFile()
        {
            return (Id + "\t" + Name + "\t\t\t" + Weight + "\t" + Price + "\t" + Num + "\t\t" + EndDate.ToString() + "\t\t\t\t" + Sale);
        }

        public bool Compare(Product other)
        {
            if (Name == other.Name && Weight == other.Weight && Price == other.Price && EndDate == other.EndDate && Sale == other.Sale)
                return true;
            return false;
        }
    }
}

