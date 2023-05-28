namespace Michael.TicTacToe.Core;
using Michael.TicTacToe.Core.Components;

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
