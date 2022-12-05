using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба4_CSharp_
{
    public class MenuCtrl
    {

        private static MenuCtrl _instance;
        public static MenuCtrl Instance => _instance ??= new MenuCtrl();

        private ListProducts products = ListProducts.Instance;

        public void StartMenu()
        {
            bool IsExit = false;
            State? state = State.startMenu;

            while(!IsExit)
            {
                Console.Clear();
                PrintMenu();
                string? inpNum = Console.ReadLine();
                try
                {
                state = (State)(int.Parse((inpNum == "" || inpNum == " " || inpNum == "\t") ? "0" : inpNum));
                }
                catch 
                {
                    state = State.startMenu;
                }
                switch (state)
                {
                    case State.startMenu:
                        break;

                    case State.addMenu:
                        InputProductMenu();
                        break;

                    case State.deleteMenu:
                        DeleteMenu();
                        break;

                    case State.showListMenu:
                        ShowList();
                        Console.ReadLine();
                        break;

                    case State.saveMenu:
                        SaveMenu();
                        break; 

                    case State.loadMenu:
                        LoadMenu();
                        break;

                    case State.exit:
                        IsExit = true;
                        break;

                    default:
                        break;
                }
            }
        }


        private void PrintMenu()
        {
            Console.WriteLine("Меню:\r\n" +
                "1 - Добавить товар(ы)\r\n" +
                "2 - Удалить товар(ы)\r\n" +
                "3 - Показать список товаров\r\n" +
                "4 - Сохранить список в файл\r\n" +
                "5 - Загрузить из файла\r\n\n" +
                "9 - Выход");
            Console.Write("Действие: ");
        }

        private void InputProductMenu()
        {
            Console.Clear();
            Console.WriteLine("Название продукта\tВес\tЦена\tКоличество\tДата, когда товар испортится\tЕсть ли скидка");
            string[] input = InputCtrl.Instance.ChechProduct();
            products.AddProduct(new Product(input[0], float.Parse(input[1]), float.Parse(input[2]), int.Parse(input[3]),
                    new Date(input[4]), bool.Parse(input[5])));
        }

        private void DeleteMenu()
        {
            ShowList();
            Console.Write("(Для отмены вредите несуществующий номер)\r\n" +
                "Удаляемый товар с ID:");
            int delID = int.Parse(Console.ReadLine());
            products.DeleteProduct(delID);
        }

        private void ShowList()
        {
            products.Print();
        }

        private void SaveMenu()
        {
            Directory.CreateDirectory("C:\\LabProgr");
            File.Create("C:\\LabProgr\\Save.txt").Close();
            StreamWriter saveFile = new StreamWriter("C:\\LabProgr\\Save.txt");
            saveFile.WriteLine("ID\tНазвание продукта\tВес\tЦена\tКоличество\tДата, когда товар испортится\tЕсть ли скидка");
            saveFile.WriteLine(products.PrintInFile());
            saveFile.Close();
        }

        private void LoadMenu()
        {
            Console.Clear();
            try
            {
                products.DeleteAll();
                StreamReader loadFile = new StreamReader("C:\\LabProgr\\Save.txt");
                loadFile.ReadLine();
                string line = loadFile.ReadLine();
                while (line != "")
                {
                    products.AddProduct(ReadProduct(line));
                    line = loadFile.ReadLine();
                }
                loadFile.Close();
                Console.WriteLine("Успешно загруженно");
                Console.Read();
            }
            catch
            {
                Console.WriteLine("Файл не найден");
                Console.Read();
            }
        }

        private Product ReadProduct(string line)
        {
            string[] prodFields = line.Split('\t', options: StringSplitOptions.RemoveEmptyEntries);
            return new Product(prodFields[1], float.Parse(prodFields[2]), float.Parse(prodFields[3]), int.Parse(prodFields[4]),
                new Date(prodFields[5]), bool.Parse(prodFields[6]));
        }

        private enum State
        {
            startMenu,
            addMenu,
            deleteMenu,
            showListMenu,
            saveMenu,
            loadMenu,
            exit = 9
        }
    }
}
