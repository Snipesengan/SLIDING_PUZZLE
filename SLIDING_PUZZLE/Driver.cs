using System;
using System.Collections.Generic;

namespace SLIDING_PUZZLE
{
    public class Driver
    {
        public static void Main(String[] args)
        {
            IAtomicStateModel<TilePuzzleAction> stateModel = new TilePuzzle();
            System.Console.WriteLine(stateModel.State);

            TilePuzzleAction[] actionArr = stateModel.GenerateActions().ToArray();

            foreach(TilePuzzleAction action in actionArr)
            {
                System.Console.WriteLine(action);
            }

            System.Console.WriteLine(stateModel.TransitionState(actionArr[1]));

            TilePuzzle puzzle = (TilePuzzle) stateModel;
            //puzzle.ShuffleBoard();
            puzzle.SwapTile(actionArr[0].From, actionArr[0].To);

            System.Console.WriteLine(puzzle);

        }
    }


}
