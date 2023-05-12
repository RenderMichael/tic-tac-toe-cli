namespace Michael.TicTacToe.Components;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Michael.TicTacToe.Components.CharReaders;
using Michael.TicTacToe.Components.SquareSelectors;
using Michael.TicTacToe.Components.WinnerCheckers;
using Michael.TicTacToe.Components.Writers;

public sealed class Game
{
    private readonly Board board;

    private readonly IWinnerCheckable winnerChecker;

    private readonly ICharReader charReader;

    private readonly IWriter writer;

    private readonly ISquareSelector squareSelector;

    private bool lastTurnOccupied;

    internal Game(string title, IWinnerCheckable winnerChecker, ICharReader charReader, IWriter writer, ISquareSelector squareSelector)
    {
        this.winnerChecker = winnerChecker;
        this.charReader = charReader;
        this.writer = writer;
        this.squareSelector = squareSelector;

        this.InitializeWriter(title);
    }

    private void InitializeWriter(string title)
    {
        this.writer.SetTitle(title);
        this.writer.Clear();
        this.writer.WriteTitleMessage();
    }

    public bool PlaceX(int x, int y) => this.board.Place(Square.X, x, y);

    public bool PlaceO(int x, int y) => this.board.Place(Square.O, x, y);

    [MemberNotNullWhen(true, nameof(Winner))]
    public bool IsGameOver
    {
        get
        {
            if (this.winnerChecker.CheckWinner(this.board, out var winner))
            {
                this.Winner = winner;
                return true;
            }
            return false;
        }
    }

    public Square CurrentTurn { get; private set; } = Square.X;

    public Square? Winner { get; private set; }

    public void DoTurn()
    {
        this.LogBoard();
        var key = this.charReader.ReadChar();
        (var x, var y) = this.squareSelector.ParseCoordinates(key);

        if (this.TryPlace(x, y))
        {
            this.FlipTurn();
            this.lastTurnOccupied = false;
        }
        else
        {
            this.lastTurnOccupied = true;
        }
    }

    private void LogBoard()
    {
        this.writer.Reset();

        this.writer.WriteLine($"It's {this.CurrentTurn}'s turn!");
        this.writer.WriteLine(this.board.BoardString);
        this.writer.WriteLine("");
        this.writer.WriteLine(this.GetOccupationLog());
    }

    private string GetOccupationLog()
    {
        if (this.lastTurnOccupied)
        {
            this.writer.Beep();
            return "Already occupied!";
        }

        return "                 ";
    }

    private bool TryPlace(int x, int y)
    {
        if (this.CurrentTurn == Square.X)
        {
            return this.PlaceX(x, y);
        }

        Debug.Assert(this.CurrentTurn == Square.O);
        return this.PlaceO(x, y);
    }

    private void FlipTurn() => this.CurrentTurn = this.CurrentTurn == Square.X ? Square.O : Square.X;

    public void LogWinner()
    {
        var winner = this.Winner ?? throw new InvalidOperationException("Cannot log winner of an incomplete game.");

        this.LogBoard();
        this.writer.WriteLine(winner == Square.Empty ? "Tie!" : $"The winner is {winner}!");
    }
}
