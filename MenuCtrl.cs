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
                state = (State)(int.Parse((inpNum == "" || inpNum == " " || inpNum == "\t") ? "0" : inpNum));
                switch (state)
                {
                    case State.startMenu:
                        break;

                    case State.addMenu:
                        InputProductMenu();
                        break;

                    case State.deleteMenu:
                        break;

                    case State.showListMenu:
                        ShowList();
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
                "5 - Загрузить из файла\r\n" +
                "9 - Выход");
        }

        private void InputProductMenu()
        {
            Console.Clear();
            Console.WriteLine("Название продукта\tВес\tЦена\tКоличество\tДата, когда товар испортится\tЕсть ли скидка");
            string[] input = InputCtrl.Instance.ChechProduct();
            products.AddProduct(new Product(input[0], float.Parse(input[1]), float.Parse(input[2]), int.Parse(input[3]),
                    new Date(input[4]), bool.Parse(input[5])));
        }

        private void ShowList()
        {
            products.Print();
            Console.ReadLine();
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
                StreamReader loadFile = new StreamReader("C:\\LabProgr\\Save.txt");
                string readedFileAsStr = loadFile.ReadToEnd();

            }
            catch
            {
                Console.WriteLine("Файл не найден");
                Console.Read();
            }
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
