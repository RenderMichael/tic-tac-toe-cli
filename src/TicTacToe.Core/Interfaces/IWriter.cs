namespace Michael.TicTacToe.Core.Interfaces;

public interface IWriter
{
    void Beep();
    void Clear();
    void Reset();
    void SetTitle(string title);
    void SetTitleMessage(string titleMessage);
    void WriteLine(string? value);
    void WriteTitleMessage();
}
