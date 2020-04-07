namespace CodingDojo.Interfaces
{
    public interface IBoardGame
    {
        string GetWinner();
        bool TakeSlot(bool isX, int row, int column);
    }
}