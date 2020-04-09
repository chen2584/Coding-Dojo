using System;
using CodingDojo.Models;
using Xunit;

namespace CodingDojo.Tests
{
    public class UnitTest
    {
        [Theory]
        [InlineData(1, 1, 1, 2, 1, 3, BoardGamePlayerType.X)]
        [InlineData(1, 1, 1, 2, 1, 3, BoardGamePlayerType.Y)]
        [InlineData(1, 1, 2, 1, 3, 1, BoardGamePlayerType.X)]
        [InlineData(1, 1, 2, 1, 3, 1, BoardGamePlayerType.Y)]
        [InlineData(1, 1, 2, 2, 3, 3, BoardGamePlayerType.X)]
        [InlineData(1, 1, 2, 2, 3, 3, BoardGamePlayerType.Y)]
        [InlineData(3, 1, 2, 2, 1, 3, BoardGamePlayerType.X)]
        [InlineData(3, 1, 2, 2, 1, 3, BoardGamePlayerType.Y)]
        public void TestGetWinner(int row1, int column1, int row2, int column2, int row3, int column3, BoardGamePlayerType? boardPlayerType)
        {
            var boardGame = new BoardGame();

            var isX = (boardPlayerType == BoardGamePlayerType.X);
            boardGame.TakeSlot(isX: isX, row: row1, column: column1);
            boardGame.TakeSlot(isX: isX, row: row2, column: column2);
            boardGame.TakeSlot(isX: isX, row: row3, column: column3);
            
            var winner = boardGame.GetWinner();
            var expected = Convert.ToString(boardPlayerType);
            Assert.Equal(winner, expected);
        }
    }
}
