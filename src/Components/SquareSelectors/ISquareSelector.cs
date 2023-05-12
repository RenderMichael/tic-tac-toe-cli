namespace Michael.TicTacToe.Components.SquareSelectors;

public interface ISquareSelector
{
    public (int x, int y) ParseCoordinates(char input);
}
