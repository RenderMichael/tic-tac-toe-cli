namespace Michael.TicTacToe;

public static class TicTacToeHelpDisplayer
{
    public static void DisplayHelpMessage()
    {
        var help =
            "Description:" + Environment.NewLine +
            "  Plays a game of Tic-Tac-Toe. Controls are the with the number pad." + Environment.NewLine + Environment.NewLine +
            "Usage:" + Environment.NewLine +
            "  dotnet run" + Environment.NewLine + Environment.NewLine +
            "Options:" + Environment.NewLine +
            "  -?, -h, --help                       Show command line help." + Environment.NewLine;
        Console.WriteLine(help);
    }
}
