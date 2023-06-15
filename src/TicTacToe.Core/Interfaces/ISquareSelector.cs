namespace Michael.TicTacToe.Core.Interfaces;

public interface ISquareSelector
{
    public (int x, int y) ParseCoordinates(char input);
}
