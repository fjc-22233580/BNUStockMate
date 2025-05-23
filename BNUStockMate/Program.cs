using BNUStockMate.Controller;
using BNUStockMate.View;

namespace BNUStockMate;

/// <summary>
/// Entry point into BNUStockMate
/// </summary>
public static class Program
{
    /// <summary>
    /// App starting point
    /// </summary>
    /// <param name="args"> Command line args </param>
    public static void Main(string[] args)
    {
        var mainMenu = new MainMenuController();
        mainMenu.Run();
    }
}