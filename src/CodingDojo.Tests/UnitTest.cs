using System;
using CodingDojo.Models;
using Xunit;

namespace CodingDojo.Tests
{
    public class UnitTest
    {
        [Fact]
        public void TestTakeSlot()
        {
            var boardGame = new BoardGame();
            boardGame.TakeSlot(isX: true, row: 3, column: 3);
        }

        [Fact]
        public void TestGetWinner()
        {
            var boardGame = new BoardGame();
            boardGame.TakeSlot(isX: true, row: 3, column: 1);
            boardGame.TakeSlot(isX: true, row: 3, column: 2);
            boardGame.TakeSlot(isX: true, row: 3, column: 3);
            
            var winner = boardGame.GetWinner();
            Assert.Equal(BoardGamePlayerType.Y.ToString(), winner);
        }
    }
}
