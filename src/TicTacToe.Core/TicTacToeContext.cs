namespace Michael.TicTacToe.Core;

using Michael.TicTacToe.Core.ContextComponents;

public sealed class TicTacToeContext
{
    public string Title { get; }
    public string TitleMessage { get; }
    public IWinnerCheckable WinnerChecker { get; }
    public ICharReader CharReader { get; }
    public IWriter Writer { get; }
    public ISquareSelector SquareSelector { get; }

    public TicTacToeContext(
        string title,
        string titleMessage,
        IWinnerCheckable winnerChecker,
        ICharReader charReader,
        IWriter writer,
        ISquareSelector squareSelector)
    {
        this.Title = title;
        this.TitleMessage = titleMessage;
        this.WinnerChecker = winnerChecker;
        this.CharReader = charReader;
        this.Writer = writer;
        this.SquareSelector = squareSelector;

        this.Writer.SetTitleMessage(this.TitleMessage);
    }
}
