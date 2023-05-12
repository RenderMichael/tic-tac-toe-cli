namespace Michael.TicTacToe;
using Michael.TicTacToe.Components;
using Michael.TicTacToe.Components.CharReaders;
using Michael.TicTacToe.Components.SquareSelectors;
using Michael.TicTacToe.Components.WinnerCheckers;
using Michael.TicTacToe.Components.Writers;

public sealed class TicTacToePlayer
{
    private readonly string title;
    private readonly string titleMessage;
    private readonly IWinnerCheckable winnerChecker;
    private readonly ICharReader charReader;
    private readonly IWriter writer;
    private readonly ISquareSelector squareSelector;

    public TicTacToePlayer(
        string title,
        string titleMessage,
        IWinnerCheckable winnerChecker,
        ICharReader charReader,
        IWriter writer,
        ISquareSelector squareSelector)
    {
        this.title = title;
        this.titleMessage = titleMessage;
        this.winnerChecker = winnerChecker;
        this.charReader = charReader;
        this.writer = writer;
        this.squareSelector = squareSelector;

        this.writer.SetTitleMessage(this.titleMessage);
    }

    public static TicTacToePlayer Default { get; } = new TicTacToePlayer(
        title: "Tic-Tac-Toe",
        titleMessage: "Welcome to Tic Tac Toe!",
        winnerChecker: new WinnerCheckerManual(),
        charReader: new ConsoleCharReader(),
        writer: new ConsoleWriter(),
        squareSelector: new NumPadSquareSelector()
    );

    public void PlayGame()
    {
        var game = new Game(
            title: this.title,
            winnerChecker: this.winnerChecker,
            charReader: this.charReader,
            writer: this.writer,
            squareSelector: this.squareSelector);

        do
        {
            game.DoTurn();
        }
        while (!game.IsGameOver);

        game.LogWinner();
    }
}
