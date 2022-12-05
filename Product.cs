using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба4_CSharp_
{
    public class Product
    {
        public int Id;

        private string _name;
        private float _weight;
        private float _price;
        private int _num;
        private Date _endDate;
        private bool _sale;

        public Product(string name, float weight, float price, int num, Date endDate, bool sale)
        {
            _name = name;
            _weight = weight;
            _price = price;
            _num = num;
            _endDate = endDate;
            _sale = sale;
        }

        public void Print()
            => Console.WriteLine(Id + "\t" + _name + "\t\t\t" + _weight + "\t" + _price + "\t" + _num + "\t\t" + _endDate.ToString() + "\t\t\t\t" + _sale);

        internal string PrintInFile()
        {
            return (Id + "\t" + _name + "\t\t\t" + _weight + "\t" + _price + "\t" + _num + "\t\t" + _endDate.ToString() + "\t\t\t\t" + _sale);
        }

        
    }
}

