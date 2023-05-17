namespace Michael.TicTacToe;
using Michael.TicTacToe.Components;

public sealed class TicTacToePlayer
{
    public static void Play(TicTacToeContext context)
    {
        var game = new Game(context);

        do
        {
            game.DoTurn();
        }
        while (!game.IsGameOver);

        game.LogWinner();
    }
}
