using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Michael.TicTacToe.Core.Components;

public readonly struct Board : IEquatable<Board>
{
    private readonly Square[,] _squares;

    public Board() => _squares = new Square[3, 3];

    public readonly Square GetValue(int x, int y)
    {
        ThrowIfOutOfRange(x);
        ThrowIfOutOfRange(y);

        return _squares[x - 1, y - 1];
    }

    public readonly bool TryPlace(Square square, int x, int y)
    {
        ThrowIfInvalidValue(square);
        ThrowIfOutOfRange(x);
        ThrowIfOutOfRange(y);

        Square val = GetValue(x, y);

        if (val == Square.Empty)
        {
            _squares[x - 1, y - 1] = square;
            return true;
        }
        return false;
    }

    public readonly string BoardString =>
        GetSpaceDisplay(_squares[0, 0]) + "|" + GetSpaceDisplay(_squares[0, 1]) + "|" + GetSpaceDisplay(_squares[0, 2]) + "" + Environment.NewLine +
        "-----" + Environment.NewLine +
        GetSpaceDisplay(_squares[1, 0]) + "|" + GetSpaceDisplay(_squares[1, 1]) + "|" + GetSpaceDisplay(_squares[1, 2]) + "" + Environment.NewLine +
        "-----" + Environment.NewLine +
        GetSpaceDisplay(_squares[2, 0]) + "|" + GetSpaceDisplay(_squares[2, 1]) + "|" + GetSpaceDisplay(_squares[2, 2]);

    private static void ThrowIfOutOfRange(int coord, [CallerArgumentExpression(nameof(coord))] string? paramName = null)
    {
        if (coord is >= 1 and <= 3)
        {
            return;
        }

        ThrowOutOfRange(paramName);
    }

    private static void ThrowIfInvalidValue(Square square)
    {
        if (Enum.IsDefined(square))
        {
            return;
        }

        ThrowInvalidValue(square);
    }

    [DoesNotReturn]
    private static void ThrowInvalidValue(Square square) => throw new ArgumentException($"Invalid argument value: {square}", nameof(square));

    [DoesNotReturn]
    private static void ThrowOutOfRange(string? paramName) => throw new ArgumentOutOfRangeException(paramName, "X must be between 1, 2, or 3");

    private static char GetSpaceDisplay(Square sq) => sq switch
    {
        Square.X => 'X',
        Square.O => 'O',
        Square.Empty => ' ',
        _ => throw new NotImplementedException()
    };

    public readonly bool Equals(Board other) => _squares.Equals(other._squares);

    public override readonly bool Equals(object? obj) => obj is Board board && Equals(board);

    public override readonly int GetHashCode() => _squares.GetHashCode();

    public static bool operator ==(Board left, Board right) => left.Equals(right);

    public static bool operator !=(Board left, Board right) => !(left == right);
}
