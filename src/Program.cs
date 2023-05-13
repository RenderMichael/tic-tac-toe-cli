using System.Runtime.CompilerServices;
using Michael.TicTacToe;

if (args.Length == 0)
{
    TicTacToePlayer.Default.PlayGame();
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
