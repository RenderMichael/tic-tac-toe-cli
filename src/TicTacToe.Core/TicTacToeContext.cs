using Michael.TicTacToe.Core.Interfaces;

namespace Michael.TicTacToe.Core;

public sealed record TicTacToeContext(
    string Title,
    string TitleMessage,
    IWinnerCheckable WinnerChecker,
    ICharReader CharReader,
    IWriter Writer,
    ISquareSelector SquareSelector);
