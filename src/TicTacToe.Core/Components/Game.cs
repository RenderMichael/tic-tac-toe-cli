namespace Michael.TicTacToe.Core.Components;
using System.Diagnostics.CodeAnalysis;

public sealed class Game
{
    public Board Board { get; }

    private readonly TicTacToeContext context;

    private Square? winner;

    private Square currentTurn = Square.X;

    private bool lastTurnOccupied;

    public Game(TicTacToeContext context)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context));
        this.Board = new Board();
        this.InitializeWriter();
    }

    private void InitializeWriter()
    {
        this.context.Writer.SetTitleMessage(this.context.TitleMessage);
        this.context.Writer.SetTitle(this.context.Title);
        this.context.Writer.Clear();
        this.context.Writer.WriteTitleMessage();
    }

    [MemberNotNullWhen(true, nameof(winner))]
    public bool IsGameOver
    {
        get
        {
            if (this.context.WinnerChecker.CheckWinner(this.Board, out var winner))
            {
                this.winner = winner;
                return true;
            }
            return false;
        }
    }

    public void DoTurn()
    {
        var key = this.context.CharReader.ReadChar();
        (var x, var y) = this.context.SquareSelector.ParseCoordinates(key);

        if (this.Board.TryPlace(this.currentTurn, x, y))
        {
            this.FlipTurn();
            this.lastTurnOccupied = false;
        }
        else
        {
            this.lastTurnOccupied = true;
        }
    }

    public void LogBoard()
    {
        this.context.Writer.Reset();

        this.context.Writer.WriteLine($"It's {this.currentTurn}'s turn!");
        this.context.Writer.WriteLine(this.Board.BoardString);
        this.context.Writer.WriteLine("");
        this.context.Writer.WriteLine(this.GetOccupiedLog());
    }

    private string GetOccupiedLog()
    {
        if (this.lastTurnOccupied)
        {
            this.context.Writer.Beep();
            return "Already occupied!";
        }

        return "                 ";
    }

    private void FlipTurn() => this.currentTurn = this.currentTurn == Square.X ? Square.O : Square.X;

    public void LogWinner()
    {
        var winner = this.winner ?? throw new InvalidOperationException("Cannot log winner of an incomplete game.");

        this.context.Writer.WriteLine(winner is Square.Empty ? "Tie!" : $"The winner is {winner}!");
    }
}
