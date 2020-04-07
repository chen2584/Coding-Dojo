using CodingDojo.Interfaces;
using CodingDojo.Models;

namespace CodingDojo
{
    public class BoardGame : IBoardGame
    {
        readonly BoardGamePlayerType?[,] boardGame = new BoardGamePlayerType?[3 ,3];

        private BoardGamePlayerType GetBoardGamePlayerType(bool isX)
            => (isX) ? BoardGamePlayerType.X : BoardGamePlayerType.Y;

        public string GetWinner()
        {

            return BoardGamePlayerType.X.ToString();
        }

        public bool TakeSlot(bool isX, int row, int column)
        {
            var boardSlotIndex = boardGame[(row-1), (column-1)];
            if (!boardSlotIndex.HasValue)
            {
                var playerType = GetBoardGamePlayerType(isX);
                boardSlotIndex = playerType;

                return true;
            }

            return false;
        }
    }
}