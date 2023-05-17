namespace Michael.TicTacToe;
using Michael.TicTacToe.Components.CharReaders;
using Michael.TicTacToe.Components.SquareSelectors;
using Michael.TicTacToe.Components.WinnerCheckers;
using Michael.TicTacToe.Components.Writers;

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

    public static TicTacToeContext Default { get; } = new TicTacToeContext(
        title: "Tic-Tac-Toe",
        titleMessage: "Welcome to Tic Tac Toe!",
        winnerChecker: new WinnerCheckerManual(),
        charReader: new ConsoleCharReader(),
        writer: new ConsoleWriter(),
        squareSelector: new NumPadSquareSelector()
    );
}
