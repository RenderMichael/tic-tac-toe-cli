namespace Michael.TicTacToe.Cli.ConsoleContext;

using Michael.TicTacToe.Core.Interfaces;

public sealed class ConsoleWriter : IWriter
{
    private string? titleMessage;

    public void Beep() => Console.Beep();

    public void Clear() => Console.Clear();

    public void Reset()
    {
        Console.SetCursorPosition(0, 1);

        (_, var linesWritten) = Console.GetCursorPosition();

        string blankLine = new(' ', Console.LargestWindowWidth);
        for (var i = 0; i <= linesWritten; i++)
        {
            Console.WriteLine(blankLine);
        }
        Console.SetCursorPosition(0, 1);
    }

    public void SetTitle(string title) => Console.Title = title;

    public void SetTitleMessage(string titleMessage) => this.titleMessage = titleMessage;

    public void WriteLine(string? value) => Console.WriteLine(value);

    public void WriteTitleMessage() => Console.WriteLine(this.titleMessage);
}
