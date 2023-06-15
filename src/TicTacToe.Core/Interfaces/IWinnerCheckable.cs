namespace Michael.TicTacToe.Core.ContextComponents;

using Michael.TicTacToe.Core.Components;

public interface IWinnerCheckable
{
    bool CheckWinner(Board game, out Square winner);
}
