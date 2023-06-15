using System.Diagnostics.CodeAnalysis;

namespace Michael.TicTacToe.Core.Components;

public sealed class Game
{
    public Board Board { get; }

    private readonly TicTacToeContext _context;

    private Square? _winner;

    private Square _currentTurn = Square.X;

    private bool _lastTurnOccupied;

    public Game(TicTacToeContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        Board = new Board();
        InitializeWriter();
    }

    private void InitializeWriter()
    {
        _context.Writer.SetTitleMessage(_context.TitleMessage);
        _context.Writer.SetTitle(_context.Title);
        _context.Writer.Clear();
        _context.Writer.WriteTitleMessage();
    }

    [MemberNotNullWhen(true, nameof(_winner))]
    public bool IsGameOver
    {
        get
        {
            if (_context.WinnerChecker.CheckWinner(Board, out Square winner))
            {
                _winner = winner;
                return true;
            }
            return false;
        }
    }

    public void DoTurn()
    {
        char key = _context.CharReader.ReadChar();
        (int x, int y) = _context.SquareSelector.ParseCoordinates(key);

        if (Board.TryPlace(_currentTurn, x, y))
        {
            FlipTurn();
            _lastTurnOccupied = false;
        }
        else
        {
            _lastTurnOccupied = true;
        }
    }

    public void LogBoard()
    {
        _context.Writer.Reset();

        _context.Writer.WriteLine($"It's {_currentTurn}'s turn!");
        _context.Writer.WriteLine(Board.BoardString);
        _context.Writer.WriteLine("");
        _context.Writer.WriteLine(GetOccupiedLog());
    }

    private string GetOccupiedLog()
    {
        if (_lastTurnOccupied)
        {
            _context.Writer.Beep();
            return "Already occupied!";
        }

        return "                 ";
    }

    private void FlipTurn() => _currentTurn = _currentTurn == Square.X ? Square.O : Square.X;

    public void LogWinner()
    {
        Square winner = _winner ?? throw new InvalidOperationException("Cannot log winner of an incomplete game.");

        _context.Writer.WriteLine(winner is Square.Empty ? "Tie!" : $"The winner is {winner}!");
    }
}
