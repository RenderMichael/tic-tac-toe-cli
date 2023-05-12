namespace Michael.TicTacToe.Components.CharReaders;

public sealed class ConsoleCharReader : ICharReader
{
    public char ReadChar() => Console.ReadKey(intercept: true).KeyChar;
}
