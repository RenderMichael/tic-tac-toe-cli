namespace Michael.TicTacToe.Core;

using Michael.TicTacToe.Core.Interfaces;

public sealed record TicTacToeContext(
    string Title,
    string TitleMessage,
    IWinnerCheckable WinnerChecker,
    ICharReader CharReader,
    IWriter Writer,
    ISquareSelector SquareSelector);
