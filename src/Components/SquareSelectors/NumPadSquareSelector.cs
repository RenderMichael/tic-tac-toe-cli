namespace Michael.TicTacToe.Components.SquareSelectors;

public sealed class NumPadSquareSelector : ISquareSelector
{
    public (int x, int y) ParseCoordinates(char input) => input switch
    {
        '1' => (3, 1),
        '2' => (3, 2),
        '3' => (3, 3),
        '4' => (2, 1),
        '5' => (2, 2),
        '6' => (2, 3),
        '7' => (1, 1),
        '8' => (1, 2),
        '9' => (1, 3),
        _ => throw new ArgumentException($"Invalid character: {input}", nameof(input))
    };
}
