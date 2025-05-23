using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNUStockMate.View
{
    public static class MenuViews
    {
        public static int ShowSelectableMenu(string title, List<string> options)
        {
            int selectedIndex = 0;
            ConsoleKey key;

            do
            {
                Console.Clear();
                Console.WriteLine($"--- {title} ---");

                for (int i = 0; i < options.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine($"> {options[i]}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"  {options[i]}");
                    }
                }

                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                    selectedIndex = (selectedIndex == 0) ? options.Count - 1 : selectedIndex - 1;
                else if (key == ConsoleKey.DownArrow)
                    selectedIndex = (selectedIndex + 1) % options.Count;

            } while (key != ConsoleKey.Enter);

            return selectedIndex;
        }

        public static void PrintList<T>(string title, List<T> items)
        {
            Console.Clear();
            Console.WriteLine($"--- {title} ---");

            foreach (var p in items)
                Console.WriteLine($"- {p}");

            Console.WriteLine("Press any key to return...");
            Console.ReadKey(true);
        }
        
        public static T ShowSelectableList<T>(string title, List<T> items)
        {
            int selectedIndex = 0;
            ConsoleKey key;

            do
            {
                Console.Clear();
                Console.WriteLine($"--- {title} ---");

                for (int i = 0; i < items.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine($"> {items[i]}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"  {items[i]}");
                    }
                }

                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                    selectedIndex = (selectedIndex == 0) ? items.Count - 1 : selectedIndex - 1;
                else if (key == ConsoleKey.DownArrow)
                    selectedIndex = (selectedIndex + 1) % items.Count;

            } while (key != ConsoleKey.Enter);

            return items[selectedIndex];
        }
    }
}
