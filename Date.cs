namespace Лаба4_CSharp_
{
    public class Date
    {
        private int _day;
        private int _month; 
        private int _year;
        private readonly char[] separateDate = { '/', '.', ',' };

        public Date(string EndDate)
        {
            string[] Nums = EndDate.Split(separateDate);
            try
            {
            _day = int.Parse(Nums[0]);
            _month = int.Parse(Nums[1]);
            _year = int.Parse(Nums[2]);

            }
            catch
            {
               
            }
        }

        public Date(int day, int month, int year)
        {
            _day = day;
            _month = month;
            _year = year;
        }

        public override string ToString()
        {
            return (_day.ToString() + "/" + _month.ToString() + "/" + _year.ToString());
        }
    }
    
}