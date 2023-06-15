using Michael.TicTacToe.Core.Interfaces;

namespace Michael.TicTacToe.Cli.ConsoleContext;

public sealed class ConsoleWriter : IWriter
{
    private string? _titleMessage;

    public void Beep() => Console.Beep();

    public void Clear() => Console.Clear();

    public void Reset()
    {
        Console.SetCursorPosition(0, 1);

        (_, int linesWritten) = Console.GetCursorPosition();

        string blankLine = new(' ', Console.LargestWindowWidth);
        for (int i = 0; i <= linesWritten; i++)
        {
            Console.WriteLine(blankLine);
        }
        Console.SetCursorPosition(0, 1);
    }

    public void SetTitle(string title) => Console.Title = title;

    public void SetTitleMessage(string titleMessage) => _titleMessage = titleMessage;

    public void WriteLine(string? value) => Console.WriteLine(value);

    public void WriteTitleMessage() => Console.WriteLine(_titleMessage);
}
