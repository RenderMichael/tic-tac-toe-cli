using Michael.TicTacToe.Core.Components;

namespace Michael.TicTacToe.Core.Interfaces;

public interface IWinnerCheckable
{
    bool CheckWinner(Board game, out Square winner);
}
