namespace Michael.TicTacToe.Core.ContextComponents;

public interface ISquareSelector
{
    public (int x, int y) ParseCoordinates(char input);
}
