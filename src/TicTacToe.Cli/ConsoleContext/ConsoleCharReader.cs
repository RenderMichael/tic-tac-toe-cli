namespace Michael.TicTacToe.Cli.ConsoleContext;

using Michael.TicTacToe.Core.Interfaces;

public sealed class ConsoleCharReader : ICharReader
{
    public char ReadChar() => Console.ReadKey(intercept: true).KeyChar;
}
