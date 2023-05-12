namespace Michael.TicTacToe.Components.WinnerCheckers;

public interface IWinnerCheckable
{
    bool CheckWinner(Board game, out Square winner);
}
