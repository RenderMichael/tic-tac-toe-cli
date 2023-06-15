using System.Runtime.CompilerServices;
using Michael.TicTacToe.Cli;
using Michael.TicTacToe.Cli.ConsoleContext;
using Michael.TicTacToe.Core;
using Michael.TicTacToe.Core.Components;
using Michael.TicTacToe.Core.Interfaces;

if (args.Length == 0)
{
    PlayGame();
    return;
}
if (args.Length == 1 && args[0] is "--help" or "-h" or "-?")
{
    TicTacToeHelpDisplayer.DisplayHelpMessage();
    return;
}

LogErrorMessage(args);

static void PlayGame()
{
    var context = new TicTacToeContext(
        Title: "Tic-Tac-Toe",
        TitleMessage: "Welcome to Tic Tac Toe!",
        WinnerChecker: new WinnerCheckerManual(),
        CharReader: new ConsoleCharReader(),
        Writer: new ConsoleWriter(),
        SquareSelector: new NumPadSquareSelector()
    );
    var game = new Game(context);

    do
    {
        game.LogBoard();
        game.DoTurn();
    }
    while (!game.IsGameOver);

    game.LogBoard();
    game.LogWinner();
}

[MethodImpl(MethodImplOptions.NoInlining)] // Cold path
static void LogErrorMessage(string[] args)
{
    Console.WriteLine($"Unknown subcommand(s): {string.Join(' ', args)}");
    Console.WriteLine("Run the --help command for more info");
}

internal sealed partial class Program
{
}
