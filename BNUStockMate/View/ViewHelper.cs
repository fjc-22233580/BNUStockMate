using BNUStockMate.Model.Enums;
using System.Text;
using System.Text.RegularExpressions;

namespace BNUStockMate.View
{
    /// <summary>
    /// Provides utility methods for displaying information and interacting with the user via the console.
    /// </summary>
    public static class ViewHelper
    {
        /// <summary>
        /// Prints the contents of the report to the console, displaying each key-value pair in a formatted manner.
        /// </summary>
        /// <param name="report">A dictionary containing the report data, where the key represents the item name and the value represents the
        /// associated amount.</param>
        public static void PrintReport(Dictionary<string, double> report)
        {
            foreach (var entry in report)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value:C}");
            }
        }

        /// <summary>
        /// Displays a list of items with a title in a formatted console output.
        /// </summary>
        /// <typeparam name="T">The type of items in the list.</typeparam>
        /// <param name="title">The title to display above the list. Cannot be null or empty.</param>
        /// <param name="items">The list of items to display. If the list is empty, a message indicating no items will be shown.</param>
        public static void PrintList<T>(string title, List<T> items)
        {
            Console.Clear();
            Console.WriteLine($"--- {title} ---");

            if (items.Count > 0)
            {
                int count = 1;

                foreach (var p in items)
                {
                    Console.WriteLine($"{count}: {p}");
                    count++;
                }
            }
            else
            {
                Console.WriteLine("No items to show.");
            }

            Console.WriteLine("Press any key to return...");
            Console.ReadKey(true);
        }

        /// <summary>
        /// Displays a message to the console, followed by a prompt to press any key to continue.
        /// </summary>
        /// <remarks>The console is cleared before displaying the message. This method waits for the user
        /// to press a key before proceeding.</remarks>
        /// <param name="prompt">An optional message to display before the "Press any key to continue..." prompt. If <paramref
        /// name="prompt"/> is null or empty, only the continuation prompt is displayed.</param>
        public static void PrintReturnMessage(string prompt = "")
        {
            Console.Clear();

            if (!string.IsNullOrEmpty(prompt))
            {
                Console.WriteLine();
                Console.WriteLine(prompt);
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }

        /// <summary>
        /// Displays a yes/no prompt to the user and returns their response.
        /// </summary>
        /// <param name="question">The question to display to the user. </param>
        /// <returns><see langword="true"/> if the user responds with 'Y'; otherwise, <see langword="false"/>. </returns>
        public static bool ShowYesNoPrompt(string question)
        {
            Console.WriteLine($"{Environment.NewLine}{question} (Y/N): ");
            return Console.ReadKey(true).Key == ConsoleKey.Y;
        }

        /// <summary>
        /// Prints a summary of financial data, including expenses, revenue, net income, and the net income status.
        /// </summary>
        /// <param name="expenses">The total expenses incurred, formatted as a monetary value.</param>
        /// <param name="revenue">The total revenue generated, formatted as a monetary value.</param>
        /// <param name="netIncome">The net income calculated as revenue minus expenses, formatted as a monetary value.</param>
        /// <param name="netIncomeStatus">The status of the net income, indicating whether the business is making a profit, a loss, or breaking even.</param>
        public static void PrintFinanceSummary(double expenses, double revenue, double netIncome, NetIncomeStatus netIncomeStatus)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Finance Summary");
            sb.AppendLine();
            sb.AppendLine($"Total outgoings: {expenses:C}");
            sb.AppendLine($"Total revenue: {revenue:C}");
            sb.AppendLine($"Net income: {netIncome:C}");

            switch (netIncomeStatus)
            {
                case NetIncomeStatus.Profit:
                    sb.AppendLine("Congratulations! Your business is making a profit.");
                    break;
                case NetIncomeStatus.Loss:
                    sb.AppendLine("Warning! Your business is making a loss. Consider reviewing your expenses and revenue strategies.");
                    break;
                case NetIncomeStatus.BreakEven:
                    sb.AppendLine("Your business is breaking even. No profit or loss at this time.");
                    break;
            }

            PrintReturnMessage(sb.ToString());
        }

        /// <summary>
        /// Writes the specified message to the console, followed by a newline character.
        /// </summary>
        /// <param name="message">The message to be written to the console.</param>
        public static void PrintLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
