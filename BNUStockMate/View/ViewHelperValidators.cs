using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace BNUStockMate.View;

/// <summary>
/// Provides utility methods for validating user input in console applications.
/// </summary>
/// <remarks>This class includes methods for validating integers, strings, and email addresses entered by the
/// user. Each method displays a prompt to the user and ensures the input meets the required criteria. If the user
/// enters "q" in certain methods, the operation is canceled, and <see langword="null"/> is returned.</remarks>
[ExcludeFromCodeCoverage]
public static class ViewHelperValidators
{
    /// <summary>
    /// Prompts the user for input and validates that the input is a valid integer.
    /// </summary>
    /// <param name="prompt">The message displayed to the user to request input.</param>
    /// <returns>The integer value entered by the user after successful validation.</returns>
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

    /// <summary>
    /// Prompts the user for input and validates the response.
    /// </summary>
    /// <param name="prompt">The message displayed to the user to request input.</param>
    /// <returns>The trimmed, non-empty string entered by the user, or <see langword="null"/> if the user cancels by entering
    /// "q".</returns>
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

    /// <summary>
    /// Prompts the user to enter a valid email address and validates the input.
    /// </summary>
    /// <param name="prompt">The message displayed to the user to request an email address.</param>
    /// <returns>The validated email address entered by the user, or <see langword="null"/> if the user cancels the operation
    /// by entering "q".</returns>
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
}