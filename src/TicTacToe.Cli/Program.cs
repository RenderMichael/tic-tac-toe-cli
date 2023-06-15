using System.Runtime.CompilerServices;
using Michael.TicTacToe.Cli;
using Michael.TicTacToe.Cli.ConsoleContext;
using Michael.TicTacToe.Core;
using Michael.TicTacToe.Core.ContextComponents;

if (args.Length == 0)
{
    var defaultContext = new TicTacToeContext(
        Title: "Tic-Tac-Toe",
        TitleMessage: "Welcome to Tic Tac Toe!",
        WinnerChecker: new WinnerCheckerManual(),
        CharReader: new ConsoleCharReader(),
        Writer: new ConsoleWriter(),
        SquareSelector: new NumPadSquareSelector()
    );
    TicTacToePlayer.Play(defaultContext);
}
else if (args.Length == 1 && args[0] is "--help" or "-h" or "-?")
{
    TicTacToeHelpDisplayer.DisplayHelpMessage();
}
else
{
    LogErrorMessage(args);
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
