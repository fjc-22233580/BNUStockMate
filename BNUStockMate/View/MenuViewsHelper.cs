namespace BNUStockMate.View
{
    /// <summary>
    /// Provides utility methods for displaying selectable menus and lists in the console.
    /// </summary>
    /// <remarks>This class includes methods for creating selectable menus that allow users to navigate
    /// through options using the arrow keys and make a selection by pressing the Enter key.</remarks>
    public static class MenuViewsHelper
    {
        /// <summary>
        /// Displays a selectable menu with the given title and options.
        /// </summary>
        /// <param name="title">The title of the menu.</param>
        /// <param name="options">A list of options to display in the menu.</param>
        /// <returns>The index of the selected option.</returns>
        public static int ShowSelectableMenu(string title, List<string> options)
        {
            return (int)PrintList<string>(title, options);
        }

        /// <summary>
        /// Displays a selectable list of items with the specified title and allows the user to select one.
        /// </summary>
        /// <typeparam name="T">The type of items in the list.</typeparam>
        /// <param name="title">The title displayed above the list. Cannot be null or empty.</param>
        /// <param name="items">The list of items to display. Cannot be null or empty.</param>
        /// <returns>The item selected by the user.</returns>
        public static T ShowSelectableList<T>(string title, List<T> items)
        {
            return (T)PrintList(title, items);
        }

        /// <summary>
        /// Helper method for both selectable list methods above.
        /// </summary>
        /// <typeparam name="T">The type of items in the list. If <typeparamref name="T"/> is <see langword="string"/>, the method returns
        /// the index of the selected item; otherwise, it returns the selected item itself.</typeparam>
        /// <param name="title">The title displayed above the list in the console. Cannot be <see langword="null"/> or empty.</param>
        /// <param name="items">The list of items to display. Cannot be <see langword="null"/> or empty.</param>
        /// <returns>If <typeparamref name="T"/> is <see langword="string"/>, returns the zero-based index of the selected item.
        /// Otherwise, returns the selected item of type <typeparamref name="T"/>.</returns>
        private static object PrintList<T>(string title, List<T> items)
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
                {
                    selectedIndex = (selectedIndex == 0) ? items.Count - 1 : selectedIndex - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex + 1) % items.Count;
                }

            } while (key != ConsoleKey.Enter);

            if (typeof(T) == typeof(string))
            {
                return selectedIndex;
            }

            return items[selectedIndex];
        }
    }
}
