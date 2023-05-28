namespace Michael.TicTacToe.Core.ContextComponents;

using Michael.TicTacToe.Core.Components;

public sealed class WinnerCheckerManual : IWinnerCheckable
{
    public bool CheckWinner(Board game, out Square winner)
    {
        // Horizontal victories
        var spot11 = game.GetValue(1, 1);
        var spot12 = game.GetValue(1, 2);
        var spot13 = game.GetValue(1, 3);
        if (spot11 != Square.Empty && spot11 == spot12 && spot11 == spot13)
        {
            winner = spot11;
            return true;
        }

        var spot21 = game.GetValue(2, 1);
        var spot22 = game.GetValue(2, 2);
        var spot23 = game.GetValue(2, 3);

        if (spot21 != Square.Empty && spot21 == spot22 && spot21 == spot23)
        {
            winner = spot21;
            return true;
        }

        var spot31 = game.GetValue(3, 1);
        var spot32 = game.GetValue(3, 2);
        var spot33 = game.GetValue(3, 3);

        if (spot31 != Square.Empty && spot31 == spot32 && spot31 == spot33)
        {
            winner = spot31;
            return true;
        }

        // Vertical victories

        if (spot11 != Square.Empty && spot11 == spot21 && spot11 == spot31)
        {
            winner = spot11;
            return true;
        }

        if (spot12 != Square.Empty && spot12 == spot22 && spot12 == spot32)
        {
            winner = spot12;
            return true;
        }

        if (spot13 != Square.Empty && spot13 == spot23 && spot13 == spot33)
        {
            winner = spot13;
            return true;
        }

        // Diagonal victories

        if (spot11 != Square.Empty && spot11 == spot22 && spot11 == spot33)
        {
            winner = spot11;
            return true;
        }

        if (spot13 != Square.Empty && spot13 == spot22 && spot13 == spot31)
        {
            winner = spot13;
            return true;
        }

        winner = Square.Empty; // No winner

        // But if all spaces are occupied, the game is done.
        return
            spot11 != Square.Empty &&
            spot12 != Square.Empty &&
            spot13 != Square.Empty &&

            spot21 != Square.Empty &&
            spot22 != Square.Empty &&
            spot23 != Square.Empty &&

            spot31 != Square.Empty &&
            spot32 != Square.Empty &&
            spot33 != Square.Empty;
    }
}
