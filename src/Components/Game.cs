namespace Michael.TicTacToe.Components;
using System.Diagnostics.CodeAnalysis;

public sealed class Game
{
    private readonly Board board;

    private readonly TicTacToeContext player;

    private Square? winner;

    private bool lastTurnOccupied;

    internal Game(TicTacToeContext player)
    {
        this.player = player;
        this.board = new Board();
        this.InitializeWriter();
    }

    private void InitializeWriter()
    {
        this.player.Writer.SetTitle(this.player.Title);
        this.player.Writer.Clear();
        this.player.Writer.WriteTitleMessage();
    }

    [MemberNotNullWhen(true, nameof(winner))]
    public bool IsGameOver
    {
        get
        {
            if (this.player.WinnerChecker.CheckWinner(this.board, out var winner))
            {
                this.winner = winner;
                return true;
            }
            return false;
        }
    }

    public Square CurrentTurn { get; private set; } = Square.X;

    public void DoTurn()
    {
        this.LogBoard();
        var key = this.player.CharReader.ReadChar();
        (var x, var y) = this.player.SquareSelector.ParseCoordinates(key);

        if (this.board.TryPlace(this.CurrentTurn, x, y))
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
        this.player.Writer.Reset();

        this.player.Writer.WriteLine($"It's {this.CurrentTurn}'s turn!");
        this.player.Writer.WriteLine(this.board.BoardString);
        this.player.Writer.WriteLine("");
        this.player.Writer.WriteLine(this.GetOccupationLog());
    }

    private string GetOccupationLog()
    {
        if (this.lastTurnOccupied)
        {
            this.player.Writer.Beep();
            return "Already occupied!";
        }

        return "                 ";
    }

    private void FlipTurn() => this.CurrentTurn = this.CurrentTurn == Square.X ? Square.O : Square.X;

    public void LogWinner()
    {
        var winner = this.winner ?? throw new InvalidOperationException("Cannot log winner of an incomplete game.");

        this.LogBoard();
        this.player.Writer.WriteLine(winner is Square.Empty ? "Tie!" : $"The winner is {winner}!");
    }
}
