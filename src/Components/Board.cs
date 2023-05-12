namespace Michael.TicTacToe.Components;
using System.Runtime.CompilerServices;

public readonly struct Board : IEquatable<Board>
{
    private readonly Square[,] squares;

    public Board() => this.squares = new Square[3, 3];

    public readonly Square GetValue(int x, int y)
    {
        ThrowIfOutOfRange(x);
        ThrowIfOutOfRange(y);

        return this.squares[x - 1, y - 1];
    }

    private void SetValue(Square value, int x, int y)
    {
        ThrowIfOutOfRange(x);
        ThrowIfOutOfRange(y);

        this.squares[x - 1, y - 1] = value;
    }

    public bool Place(Square square, int x, int y)
    {
        ThrowIfOutOfRange(x);
        ThrowIfOutOfRange(y);

        var val = this.GetValue(x, y);

        if (val == Square.Empty)
        {
            this.SetValue(square, x, y);
            return true;
        }
        return false;
    }

    public readonly string BoardString =>
        "^[4m" + GetSpaceDisplay(this.squares[0, 0]) + "|" + GetSpaceDisplay(this.squares[0, 1]) + "|" + GetSpaceDisplay(this.squares[0, 2]) + "" + Environment.NewLine +
        "-----" + Environment.NewLine +
        "^[4m" + GetSpaceDisplay(this.squares[1, 0]) + "|" + GetSpaceDisplay(this.squares[1, 1]) + "|" + GetSpaceDisplay(this.squares[1, 2]) + "" + Environment.NewLine +
        "-----" + Environment.NewLine +
        GetSpaceDisplay(this.squares[2, 0]) + "|" + GetSpaceDisplay(this.squares[2, 1]) + "|" + GetSpaceDisplay(this.squares[2, 2]);

    private static void ThrowIfOutOfRange(int coord, [CallerArgumentExpression("coord")] string? paramName = null)
    {
        if (coord < 1 || ((uint)coord > 3))
        {
            ThrowOutOfRange(paramName);
        }
    }

    private static void ThrowOutOfRange(string? paramName) => throw new ArgumentOutOfRangeException(paramName, "X must be between 1, 2, or 3");

    private static char GetSpaceDisplay(Square sq) => sq switch
    {
        Square.X => 'X',
        Square.O => 'O',
        Square.Empty => ' ',
        _ => throw new NotImplementedException()
    };

    public bool Equals(Board other) => this.squares.Equals(other.squares);

    public override bool Equals(object? obj) => obj is Board board && this.Equals(board);

    public override int GetHashCode() => this.squares.GetHashCode();

    public static bool operator ==(Board left, Board right) => left.Equals(right);

    public static bool operator !=(Board left, Board right) => !(left == right);
}
