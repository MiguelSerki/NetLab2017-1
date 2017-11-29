using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;

namespace App
{
    class Program
    {
        static OrderService service = new OrderService();

        static void Main(string[] args)
        {
            do
            {
                var MenuSelection = ArrowMenu("Order management menu",
                    new string[] { "Create", "Read", "Update", "Delete", "Quit" });

                switch (MenuSelection)
                {
                    case 0:
                        CreateMenu();
                        break;
                    case 1:
                        ReadMenu();
                        break;
                    case 2:
                        UpdateMenu();
                        break;
                    case 3:
                        DeleteMenu();
                        break;
                    default:
                        return;
                }

            } while (true);
        }

        public static int ArrowMenu(string menu, string[] menuItems)
        {
            var curItem = 0;
            ConsoleKeyInfo key;

            do
            {
                Console.Clear();

                Console.WriteLine("   ================================");
                Console.WriteLine("\t" + menu);
                Console.WriteLine("   ================================\n");

                Console.WriteLine("Move with up and down arrows, press enter to select:");

                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (curItem == i)
                    {
                        Console.Write("=> ");
                        Console.WriteLine(menuItems[i]);
                    }
                    else
                        Console.WriteLine($"   {menuItems[i]}");
                }

                key = Console.ReadKey(true);

                if (key.Key.ToString() == "DownArrow" && curItem < menuItems.Length - 1)
                    curItem++;
                else if (key.Key.ToString() == "UpArrow" && curItem > 0)
                    curItem--;

            } while (key.KeyChar != 13); //13 = Enter

            return curItem;
        }

        public static void CreateMenu() { }

        public static void ReadMenu() {

            var menuSelection = ArrowMenu("Read order menu",
                new string[] {"All orders", "Best customer and product by country", "Back"});

            switch (menuSelection)
            {
                case 0:
                    var all = service.ReadAll();
                    foreach (var o in all)
                    {
                        Console.WriteLine($"ID: {o.OrderID}, Customer: {o.CustomerName}, Freight: {o.Freight}");
                    }
                    Console.Read();
                    break;
                case 1:
                    break;
            }
        }

        public static void UpdateMenu() { }

        public static void DeleteMenu() { }
    }
}
