using System;
namespace Sliding_Puzzle
{
    public class Driver
    {
        public static void Main(String[] args)
        {
            TilePuzzle puzzle = new TilePuzzle();
            //puzzle.ShuffleBoard();
            System.Console.WriteLine(puzzle);
            puzzle.SwapTile(0, 1);
            System.Console.WriteLine(puzzle);
            puzzle.SwapTile(1, 4);
            System.Console.WriteLine(puzzle);
            puzzle.SwapTile(4, 0);
            System.Console.WriteLine(puzzle);

        }
    }


}
