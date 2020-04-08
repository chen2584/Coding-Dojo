using System;
using System.Collections.Generic;
using System.Linq;
using CodingDojo.Interfaces;
using CodingDojo.Models;

namespace CodingDojo
{
    public class BoardGame : IBoardGame
    {
        private BoardGamePlayerType?[,] boardGame = new BoardGamePlayerType?[3 ,3];

        private int GetBoardGameRowLength()
            => boardGame.GetLength(0);

        private int GetBoardGameColumnLength()
            => boardGame.GetLength(1);

        private BoardGamePlayerType GetBoardGamePlayerType(bool isX)
            => (isX) ? BoardGamePlayerType.X : BoardGamePlayerType.Y;

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
            for (var column = 0; column < GetBoardGameColumnLength(); column++)
            {
                var dictPlayerScore = new Dictionary<BoardGamePlayerType, int>();

                var rowLength = GetBoardGameRowLength();
                for (var row = 0; row < GetBoardGameRowLength(); row++)
                {
                    var boardSlot = boardGame[row, column];
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

                var winner = GetWinner(dictPlayerScore, rowLength);
                if (winner.HasValue)
                {
                    return winner;
                }
            }

            return null;
        }

        private BoardGamePlayerType? GetColumnWinner()
        {
            for (var row = 0; row < GetBoardGameRowLength(); row++)
            {
                var dictPlayerScore = new Dictionary<BoardGamePlayerType, int>();

                var columnLength = GetBoardGameColumnLength();
                for (var column = 0; column < columnLength; column++)
                {
                    var boardSlot = boardGame[row, column];
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

                var winner = GetWinner(dictPlayerScore, columnLength);
                if (winner.HasValue)
                {
                    return winner;
                }
            }

            return null;
        }

        public string GetWinner()
        {
            var winner = GetRowWinner() ?? GetColumnWinner();
            var winnerString = Convert.ToString(winner);
            return winnerString;
        }

        public bool TakeSlot(bool isX, int row, int column)
        {
            ref var boardSlot = ref boardGame[(row-1), (column-1)];
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