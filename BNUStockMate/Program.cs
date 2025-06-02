using System.Diagnostics.CodeAnalysis;
using BNUStockMate.Controller;

namespace BNUStockMate;

/// <summary>
/// Entry point into BNUStockMate
/// </summary>
[ExcludeFromCodeCoverage]
public static class Program
{
    /// <summary>
    /// App starting point
    /// </summary>
    /// <param name="args"> Command line args </param>
    public static void Main(string[] args)
    {
        // Initialize the main menu controller and run it to start the application.
        var mainMenu = new MainMenuController();
        mainMenu.Run();
    }
}