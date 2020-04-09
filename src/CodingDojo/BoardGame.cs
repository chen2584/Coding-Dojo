using System;
using System.Collections.Generic;
using System.Linq;
using CodingDojo.Interfaces;
using CodingDojo.Models;

namespace CodingDojo
{
    public class BoardGame : IBoardGame
    {
        private const int _boardLength = 3;
        private BoardGamePlayerType?[,] _boardGame = new BoardGamePlayerType?[_boardLength, _boardLength];

        private BoardGamePlayerType GetBoardGamePlayerType(bool isX)
            => (isX) ? BoardGamePlayerType.X : BoardGamePlayerType.Y;

        #region Check for Winner
        private BoardGamePlayerType? GetWinner(Dictionary<BoardGamePlayerType, int> dictPlayerScore, int desiredScore)
        {
            foreach (var boardPlayerType in dictPlayerScore)
            {
                if (boardPlayerType.Value == desiredScore)
                {
                    return boardPlayerType.Key;
                }
            }

            return null;
        }

        private BoardGamePlayerType? GetRowWinner()
        {
            for (var column = 0; column < _boardLength; column++)
            {
                var dictPlayerScore = new Dictionary<BoardGamePlayerType, int>();

                for (var row = 0; row < _boardLength; row++)
                {
                    var boardSlot = _boardGame[row, column];
                    if (boardSlot.HasValue)
                    {
                        var boardSlotValue = boardSlot.Value;
                        if (!dictPlayerScore.ContainsKey(boardSlotValue)) // Initial if not exists
                        {
                            dictPlayerScore[boardSlotValue] = 0; 
                        }
                        dictPlayerScore[boardSlotValue]++;
                    }
                }

                var winner = GetWinner(dictPlayerScore, _boardLength);
                if (winner.HasValue)
                {
                    return winner;
                }
            }

            return null;
        }

        private BoardGamePlayerType? GetColumnWinner()
        {
            for (var row = 0; row < _boardLength; row++)
            {
                var dictPlayerScore = new Dictionary<BoardGamePlayerType, int>();

                for (var column = 0; column < _boardLength; column++)
                {
                    var boardSlot = _boardGame[row, column];
                    if (boardSlot.HasValue)
                    {
                        var boardSlotValue = boardSlot.Value;
                        if (!dictPlayerScore.ContainsKey(boardSlotValue)) // Initial if not exists
                        {
                            dictPlayerScore[boardSlotValue] = 0; 
                        }
                        dictPlayerScore[boardSlotValue]++;
                    }
                }

                var winner = GetWinner(dictPlayerScore, _boardLength);
                if (winner.HasValue)
                {
                    return winner;
                }
            }

            return null;
        }

        private BoardGamePlayerType? GetTopDiagonalWinner()
        {
            var dictPlayerScore = new Dictionary<BoardGamePlayerType, int>();
            for (var index = 0; index < _boardLength; index++)
            {
                var boardSlot = _boardGame[index, index];
                if (boardSlot.HasValue)
                {
                    var boardSlotValue = boardSlot.Value;
                    if (!dictPlayerScore.ContainsKey(boardSlotValue)) // Initial if not exists
                    {
                        dictPlayerScore[boardSlotValue] = 0; 
                    }
                    dictPlayerScore[boardSlotValue]++;
                }
            }
            var winner = GetWinner(dictPlayerScore, _boardLength);
            return winner;
        }

        private BoardGamePlayerType? GetBottomDiagonalWinner()
        {
            var column = 0;
            var dictPlayerScore = new Dictionary<BoardGamePlayerType, int>();
            for (var row = _boardLength; row > 0; row--)
            {
                var boardSlot = _boardGame[row-1, column];
                if (boardSlot.HasValue)
                {
                    var boardSlotValue = boardSlot.Value;
                    if (!dictPlayerScore.ContainsKey(boardSlotValue)) // Initial if not exists
                    {
                        dictPlayerScore[boardSlotValue] = 0; 
                    }
                    dictPlayerScore[boardSlotValue]++;
                }

                column++;
            }
            var winner = GetWinner(dictPlayerScore, _boardLength);
            return winner;
        }

        private BoardGamePlayerType? GetDiagonalWinner()
            => GetTopDiagonalWinner() ?? GetBottomDiagonalWinner();
        #endregion

        public string GetWinner()
        {
            var winner = GetRowWinner() ?? GetColumnWinner() ?? GetDiagonalWinner();
            var winnerString = Convert.ToString(winner);
            return winnerString;
        }

        public bool TakeSlot(bool isX, int row, int column)
        {
            ref var boardSlot = ref _boardGame[(row-1), (column-1)];
            if (!boardSlot.HasValue)
            {
                var boardPlayerType = GetBoardGamePlayerType(isX);
                boardSlot = boardPlayerType;

                return true;
            }
            return false;
        }
    }
}