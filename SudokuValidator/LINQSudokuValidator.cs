using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuValidator
{
    /// <summary>
    /// Simple LINQ Sudoku Validator
    /// </summary>
    public class LINQSudokuValidator : ISudokuValidator
    {
        /// <summary>
        /// Validates the given board (9x9 two-dimensional array) based on the Sudoku's Rules
        /// </summary>
        /// <param name="board">9x9 Two-dimensional array</param>
        /// <returns>True if the solution is valid or false otherwise</returns>
        /// <exception cref="ArgumentException">If board dimensions don't match</exception>
        public bool Validate(int[,] board)
        {
            if (!ValidateBoardSize(board))
            {
                throw new ArgumentException("Board size is invalid. It needs to be a 9x9 two-dimensional", nameof(board));
            }

            var horizontalLines = GetHorizontalLines(board);
            var verticalLines = GetVerticalLines(board);
            var squares = GetAllSquares(board);

            return squares.All(IsLineValid) &&
            horizontalLines.All(IsLineValid)
                   && verticalLines.All(IsLineValid);
                   
        }

        /// <summary>
        /// Validates the given board size
        /// </summary>
        /// <param name="board">9x9 Two-dimensional array</param>
        /// <returns>True if the size is correct or false otherwise</returns>
        private bool ValidateBoardSize(int[,] board)
        {
            return board.GetLength(0) == 9 && board.GetLength(1) == 9;
        }

        /// <summary>
        /// Gets the vertical lines in the given array
        /// </summary>
        /// <param name="array">9x9 Two-dimensional array</param>
        /// <returns>All the vertical lines in the array</returns>
        private IEnumerable<IEnumerable<int>> GetVerticalLines(int[,] array)
        {
            return from y in Enumerable.Range(0, 9)
                   select from x in Enumerable.Range(0, 9)
                          select array[y, x];
        }

        /// <summary>
        /// Gets the vertical lines in the given array
        /// </summary>
        /// <param name="array">9x9 Two-dimensional array</param>
        /// <returns>All the horizontal lines in the array</returns>
        private IEnumerable<IEnumerable<int>> GetHorizontalLines(int[,] array)
        {
            return from y in Enumerable.Range(0, 9)
                   select from x in Enumerable.Range(0, 9)
                          select array[x, y];
        }

        /// <summary>
        /// Gets all the squares in the given array
        /// </summary>
        /// <param name="array">9x9 Two-dimensional array</param>
        /// <returns>All the 3x3 squares in the array</returns>
        private IEnumerable<IEnumerable<int>> GetAllSquares(int[,] array)
        {
            return from x in Enumerable.Range(0, 3)
                   from y in Enumerable.Range(0, 3)
                   select GetSquare(array, x, y);
        }

        /// <summary>
        /// Gets a single square in the given array by the x and y position
        /// </summary>
        /// <param name="array">9x9 Two-dimensional array</param>
        /// <param name="x">X start position</param>
        /// <param name="y">Y start position</param>
        /// <returns></returns>
        private IEnumerable<int> GetSquare(int[,] array, int x, int y)
        {
            return from squareX in Enumerable.Range(0, 3)
                   from squareY in Enumerable.Range(0, 3)
                   select array[x * 3 + squareX, y * 3 + squareY];
        }

        /// <summary>
        /// Check if the given line is valid by grouping the items in the array and making sure that only numbers 1-9 are present
        /// </summary>
        /// <param name="line">Array representing a line in the array</param>
        /// <returns>True if the rules are met, false otherwise</returns>
        private bool IsLineValid(IEnumerable<int> line)
        {
            var validNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            return !(from item in line
                     group item by item
                     into itemGroup
                     where itemGroup.Count() > 1 ||
                           itemGroup.Any(p => !validNumbers.Contains(p))
                     select itemGroup).Any();
        }
    }
}
