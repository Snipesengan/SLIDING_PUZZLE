using System;
using Xunit;
using StateModel.BoardGame;
using StateModel.Interface;
using System.Linq;
using Moq;
using System.Collections.Generic;

namespace StateModelTest
{
    public class SlidingPuzzleTest
    {

        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void TestConstructor1(int size)
        {
            SlidingPuzzle puzzle;
            System.Console.WriteLine("Testing SlidingPuzzle(int {0})", size);
            puzzle = new SlidingPuzzle(size);
            Assert.Equal(puzzle.GetSize(), size);
        }

        [Theory]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 })]
        [InlineData(new int[] { 1, 2, 3, 4, 0, 5, 6, 7, 8 })]
        [InlineData(new int[] { 1, 2, 3, 4, 7, 5, 0, 6, 8 })]
        public void TestConstructo2(int[] board)
        {
            SlidingPuzzle puzzle = new SlidingPuzzle(board);
            string str = "{" + string.Join(",", board) + "}";
            System.Console.WriteLine("Testing SlidingPuzzle(int[] {0})", str);
            Assert.True(Enumerable.SequenceEqual(puzzle.Board, board));
        }

        [Theory]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 })]
        [InlineData(new int[] { 1, 2, 3, 4, 0, 5, 6, 7, 8 })]
        [InlineData(new int[] { 1, 2, 3, 4, 7, 5, 6, 0, 8 })]
        public void TestGetState(int[] board)
        {
            SlidingPuzzle puzzle = new SlidingPuzzle(board);
            string str = "{" + string.Join(",", board) + "}";
            System.Console.WriteLine("Testing GetState() - Expect{0}",str);
            Assert.Equal(str, puzzle.GetState());
        }

        [Theory]
        [InlineData("{0,1,2,3,4,5,6,7,8}")]
        [InlineData("{1,2,3,4,0,5,6,7,8}")]
        [InlineData("{1,2,3,4,7,5,6,0,8}")]
        public void TestSetState(string state)
        {
            SlidingPuzzle puzzle = new SlidingPuzzle();
            puzzle.SetState(state);
            string board = "{" + string.Join(",", puzzle.Board) + "}";
            System.Console.WriteLine("Testing SetState({0})", state);
            Assert.Equal(board, state);
        }

        [Fact]
        public void TestSwapTile()
        {
            SlidingPuzzle puzzle = new SlidingPuzzle();
            int[] expected1 = { 1, 0, 2, 3, 4, 5, 6, 7, 8 };
            int[] expected2 = { 1, 4, 2, 3, 0, 5, 6, 7, 8 };
            int[] expected3 = { 1, 4, 2, 0, 3, 5, 6, 7, 8 };
            int[] expected4 = { 1, 4, 2, 6, 3, 5, 0, 7, 8 };
            int[] expected5 = { 1, 4, 2, 6, 3, 5, 7, 0, 8 };
            int[] expected6 = { 1, 4, 2, 6, 3, 5, 7, 8, 0 };
            int[] expected7 = { 1, 4, 2, 6, 3, 0, 7, 8, 5 };

            System.Console.WriteLine("Testing sequential swapping of tiles...");
            puzzle.SwapTile(0, 1);
            Assert.True(Enumerable.SequenceEqual(puzzle.Board, expected1));
            System.Console.WriteLine("\tSwapped 0,1");
            puzzle.SwapTile(1, 4);
            Assert.True(Enumerable.SequenceEqual(puzzle.Board, expected2));
            System.Console.WriteLine("\tSwapped 1,4");
            puzzle.SwapTile(4, 3);
            Assert.True(Enumerable.SequenceEqual(puzzle.Board, expected3));
            System.Console.WriteLine("\tSwapped 4,3");
            puzzle.SwapTile(3, 6);
            Assert.True(Enumerable.SequenceEqual(puzzle.Board, expected4));
            System.Console.WriteLine("\tSwapped 3,6");
            puzzle.SwapTile(6, 7);
            Assert.True(Enumerable.SequenceEqual(puzzle.Board, expected5));
            System.Console.WriteLine("\tSwapped 6,7");
            puzzle.SwapTile(7, 8);
            Assert.True(Enumerable.SequenceEqual(puzzle.Board, expected6));
            System.Console.WriteLine("\tSwapped 7,8");
            puzzle.SwapTile(8, 5);
            Assert.True(Enumerable.SequenceEqual(puzzle.Board, expected7));
            System.Console.WriteLine("\tSwapped 8,5");
        }

        [Fact]
        public void TestGenerateAction1()
        {
            // Center case
            int[] board = { 1, 2, 3, 4, 0, 5, 6, 7, 8 };
            SlidingPuzzle puzzle = new SlidingPuzzle(board);
            SlidingPuzzleAction[] actual = puzzle.GetActions().ToArray();
            SlidingPuzzleAction[] expected = new SlidingPuzzleAction[4];
            expected[0] = new SlidingPuzzleAction(4, 4 - 1);
            expected[1] = new SlidingPuzzleAction(4, 4 + 1);
            expected[2] = new SlidingPuzzleAction(4, 4 - 3);
            expected[3] = new SlidingPuzzleAction(4, 4 + 3);

            System.Console.WriteLine("Testing GenerateActions()");
            System.Console.WriteLine("\tCenter Case");
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void TestGenerateAction2()
        {
            // Center case
            int[] board = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            SlidingPuzzle puzzle = new SlidingPuzzle(board);
            SlidingPuzzleAction[] actual = puzzle.GetActions().ToArray();
            SlidingPuzzleAction[] expected = new SlidingPuzzleAction[2];
            expected[0] = new SlidingPuzzleAction(0, 0 + 1);
            expected[1] = new SlidingPuzzleAction(0, 0 + 3);

            System.Console.WriteLine("Testing GenerateActions()");
            System.Console.WriteLine("\tTop-Left Case");
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void TestGenerateAction3()
        {
            // Center case
            int[] board = { 8, 1, 2, 3, 4, 5, 6, 7, 0 };
            SlidingPuzzle puzzle = new SlidingPuzzle(board);
            SlidingPuzzleAction[] actual = puzzle.GetActions().ToArray();
            SlidingPuzzleAction[] expected = new SlidingPuzzleAction[2];
            expected[0] = new SlidingPuzzleAction(8, 8 - 1);
            expected[1] = new SlidingPuzzleAction(8, 8 - 3);

            System.Console.WriteLine("Testing GenerateActions()");
            System.Console.WriteLine("\tBottom-Right Case");
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void TestTransitionState()
        {
            int[] board = { 1, 2, 3, 4, 0, 5, 6, 7, 8 };
            SlidingPuzzle puzzle = new SlidingPuzzle(board);
            Queue<int[]> expectedQ = new Queue<int[]>();
            SlidingPuzzleAction[] actions = new SlidingPuzzleAction[4];
            actions[0] = new SlidingPuzzleAction(4, 4 - 1);
            actions[1] = new SlidingPuzzleAction(4, 4 + 1);
            actions[2] = new SlidingPuzzleAction(4, 4 - 3);
            actions[3] = new SlidingPuzzleAction(4, 4 + 3);
            expectedQ.Enqueue(new int[] { 1, 2, 3, 0, 4, 5, 6, 7, 8 });
            expectedQ.Enqueue(new int[] { 1, 2, 3, 4, 5, 0, 6, 7, 8 });
            expectedQ.Enqueue(new int[] { 1, 0, 3, 4, 2, 5, 6, 7, 8 });
            expectedQ.Enqueue(new int[] { 1, 2, 3, 4, 7, 5, 6, 0, 8 });


            for(int i = 0; i < 4; i++)
            {
                System.Console.WriteLine("Testing TransitionState(" +
                    string.Format("SlidingPuzzleAction {0}", 
                    actions[i].ToString()));
                string actual = puzzle.TransitionState(actions[i]);
                string expected = "{" + string.Join(",", 
                    expectedQ.Dequeue()) + "}";

                Assert.Equal(actual, expected);
            }

        }

        // Private
    }
}
