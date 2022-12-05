namespace Лаба4_CSharp_
{
    internal class Program
    {

        
        static void Main(string[] args)
        {
            ListProducts products = ListProducts.Instance;
            InputCtrl InController = InputCtrl.Instance;
            MenuCtrl Menu = MenuCtrl.Instance;
            Menu.StartMenu();
        }
    }
}