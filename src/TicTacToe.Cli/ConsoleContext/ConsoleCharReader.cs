using Michael.TicTacToe.Core.Interfaces;

namespace Michael.TicTacToe.Cli.ConsoleContext;

public sealed class ConsoleCharReader : ICharReader
{
    public char ReadChar() => Console.ReadKey(intercept: true).KeyChar;
}
