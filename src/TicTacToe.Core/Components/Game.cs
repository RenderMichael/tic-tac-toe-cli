namespace Michael.TicTacToe.Core.Components;
using System.Diagnostics.CodeAnalysis;

public sealed class Game
{
    public Board Board { get; }

    private readonly TicTacToeContext player;

    private Square? winner;

    private Square currentTurn = Square.X;

    private bool lastTurnOccupied;

    public Game(TicTacToeContext player)
    {
        this.player = player ?? throw new ArgumentNullException(nameof(player));
        this.Board = new Board();
        this.InitializeWriter();
    }

    private void InitializeWriter()
    {
        this.player.Writer.SetTitleMessage(this.player.TitleMessage);
        this.player.Writer.SetTitle(this.player.Title);
        this.player.Writer.Clear();
        this.player.Writer.WriteTitleMessage();
    }

    [MemberNotNullWhen(true, nameof(winner))]
    public bool IsGameOver
    {
        get
        {
            if (this.player.WinnerChecker.CheckWinner(this.Board, out var winner))
            {
                this.winner = winner;
                return true;
            }
            return false;
        }
    }

    public void DoTurn()
    {
        this.LogBoard();
        var key = this.player.CharReader.ReadChar();
        (var x, var y) = this.player.SquareSelector.ParseCoordinates(key);

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

    private void LogBoard()
    {
        this.player.Writer.Reset();

        this.player.Writer.WriteLine($"It's {this.currentTurn}'s turn!");
        this.player.Writer.WriteLine(this.Board.BoardString);
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

    private void FlipTurn() => this.currentTurn = this.currentTurn == Square.X ? Square.O : Square.X;

    public void LogWinner()
    {
        var winner = this.winner ?? throw new InvalidOperationException("Cannot log winner of an incomplete game.");

        this.LogBoard();
        this.player.Writer.WriteLine(winner is Square.Empty ? "Tie!" : $"The winner is {winner}!");
    }
}
