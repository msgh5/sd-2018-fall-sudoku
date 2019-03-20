using System;
using Xunit;

namespace SudokuValidator.Tests
{
    public class LINQSudokuValidatorTests
    {
        private ISudokuValidator SudokuValidator { get; }

        public LINQSudokuValidatorTests()
        {
            SudokuValidator = new LINQSudokuValidator();
        }

        [Fact]
        public void Should_Be_Valid_Solution()
        {
            var validBoard = new[,]
            {
                {5, 3, 4, 6, 7, 8, 9, 1, 2},
                {6, 7, 2, 1, 9, 5, 3, 4, 8},
                {1, 9, 8, 3, 4, 2, 5, 6, 7},
                {8, 5, 9, 7, 6, 1, 4, 2, 3},
                {4, 2, 6, 8, 5, 3, 7, 9, 1},
                {7, 1, 3, 9, 2, 4, 8, 5, 6},
                {9, 6, 1, 5, 3, 7, 2, 8, 4},
                {2, 8, 7, 4, 1, 9, 6, 3, 5},
                {3, 4, 5, 2, 8, 6, 1, 7, 9},
            };

            Assert.True(SudokuValidator.Validate(validBoard));
        }

        [Fact]
        public void Should_Be_Invalid_Solution_VerticalLine()
        {
            var invalidBoardVerticalLine = new[,]
            {
                {5, 3, 4, 6, 7, 8, 9, 1, 2},
                {6, 7, 2, 1, 9, 5, 3, 4, 8},
                {1, 9, 8, 3, 4, 2, 5, 6, 7},
                {5, 5, 9, 7, 6, 1, 4, 2, 3},
                {4, 2, 6, 8, 5, 3, 7, 9, 1},
                {7, 1, 3, 9, 2, 4, 8, 5, 6},
                {9, 6, 1, 5, 3, 7, 2, 8, 4},
                {2, 8, 7, 4, 1, 9, 6, 3, 5},
                {3, 4, 5, 2, 8, 6, 1, 7, 9},
            };

            Assert.False(SudokuValidator.Validate(invalidBoardVerticalLine));
        }

        [Fact]
        public void Should_Be_Invalid_Solution_HorizontalLine()
        {
            var invalidBoardHorizontalLine = new[,]
            {
                {5, 3, 4, 6, 7, 8, 5, 1, 2},
                {6, 3, 2, 1, 9, 5, 3, 4, 8},
                {1, 9, 8, 3, 4, 2, 5, 6, 7},
                {8, 5, 9, 7, 6, 1, 4, 2, 3},
                {4, 2, 6, 8, 5, 3, 7, 9, 1},
                {7, 1, 3, 9, 2, 4, 8, 5, 6},
                {9, 6, 1, 5, 3, 7, 2, 8, 4},
                {2, 8, 7, 4, 1, 9, 6, 3, 5},
                {3, 4, 5, 2, 8, 6, 1, 7, 9},
            };

            Assert.False(SudokuValidator.Validate(invalidBoardHorizontalLine));
        }

        [Fact]
        public void Should_Be_Invalid_Solution_Number_Not_Between_1_And_9()
        {
            var invalidBoardRange = new[,]
            {
                {5, 3, 4, 6, 7, 8, 5, 1, 2},
                {6, 3, 2, 0, 9, 5, 3, 4, 8},
                {1, 9, 8, 3, 4, 2, 5, 6, 7},
                {8, 5, 9, 7, 6, 1, 4, 2, 3},
                {4, 2, 6, 8, 16, 3, 7, 9, 1},
                {7, 1, 3, 9, 2, 4, 8, 5, 6},
                {9, 6, 1, 5, 3, 7, 2, 8, 4},
                {2, 8, 7, 4, 1, 9, 6, 3, 5},
                {3, 4, 5, 2, 8, 6, 1, 7, 9},
            };

            Assert.False(SudokuValidator.Validate(invalidBoardRange));
        }

        [Fact]
        public void Should_Be_Invalid_Solution_Squares()
        {
            var invalidBoardRange = new[,]
            {
                {5, 3, 4, 6, 7, 8, 5, 1, 2},
                {6, 5, 2, 0, 9, 5, 3, 4, 8},
                {1, 9, 8, 3, 4, 2, 5, 6, 7},
                {8, 5, 9, 7, 6, 1, 4, 2, 3},
                {4, 2, 6, 8, 5, 3, 7, 9, 1},
                {7, 1, 3, 9, 2, 4, 8, 5, 6},
                {9, 6, 1, 5, 3, 7, 2, 8, 4},
                {2, 8, 7, 4, 1, 9, 6, 3, 5},
                {3, 4, 5, 2, 8, 6, 1, 7, 9},
            };

            Assert.False(SudokuValidator.Validate(invalidBoardRange));
        }

        [Fact]
        public void Should_Be_Invalid_Solution_Board_Size()
        {
            var invalidBoardSize = new[,]
            {
                {5, 3, 4, 6, 7, 8, 5, 1, 2, 1},
                {6, 3, 2, 0, 9, 5, 3, 4, 8, 1},
                {1, 9, 8, 3, 4, 2, 5, 6, 7, 1},
                {8, 5, 9, 7, 6, 1, 4, 2, 3, 1},
                {4, 2, 6, 8, 16, 3, 7, 9, 1, 1},
                {7, 1, 3, 9, 2, 4, 8, 5, 6, 1},
                {9, 6, 1, 5, 3, 7, 2, 8, 4, 1},
                {2, 8, 7, 4, 1, 9, 6, 3, 5, 1},
                {3, 4, 5, 2, 8, 6, 1, 7, 9, 1},
            };

            Assert.Throws<ArgumentException>(() => SudokuValidator.Validate(invalidBoardSize));
        }
    }
}
