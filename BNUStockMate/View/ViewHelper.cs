using BNUStockMate.Model.Enums;
using System.Text;
using System.Text.RegularExpressions;

namespace BNUStockMate.View
{
    public static class ViewHelper
    {
        public static void PrintReport(Dictionary<string, double> report)
        {
            foreach (var entry in report)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value:C}");
            }
        }

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
        /// 
        /// </summary>
        /// <param name="prompt"></param>
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

        public static bool ShowYesNoPrompt(string question)
        {
            Console.WriteLine($"{Environment.NewLine}{question} (Y/N): ");
            return Console.ReadKey(true).Key == ConsoleKey.Y;
        }

        public static int GetValidatedNumber(string prompt)
        {
            int result;
            while (true)
            {
                Console.Write($"{prompt}: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out result))
                {
                    return result;
                }

                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }


        public static string? GetValidatedString(string prompt)
        {
            while (true)
            {
                Console.Write($"{prompt} (or press q to cancel): ");
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    if (input == "q")
                    {
                        return null;
                    }
                    return input.Trim();
                }
                Console.WriteLine("Input cannot be empty. Please enter a valid input.");
            }
        }

        public static string? GetValidatedEmail(string prompt)
        {
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

            while (true)
            {
                Console.Write($"{prompt} (or press q to cancel): ");
                string input = Console.ReadLine();

                if (emailRegex.IsMatch(input))
                {
                    return input;
                }

                if (input == "q")
                {
                    return null;
                }

                Console.WriteLine("Invalid email address. Please enter a valid email.");
            }
        }

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

        public static void PrintLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
