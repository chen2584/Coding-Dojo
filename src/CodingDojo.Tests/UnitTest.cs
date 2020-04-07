using System;
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
    }
}
