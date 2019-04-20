using System;

using StateModel.Interface;
using StateModel.BoardGame;

namespace StateModel
{
    public class Driver
    {
        public static void Main(String[] args)
        {
            IAtomicStateModel<string,SlidingPuzzleAction> stateModel = new SlidingPuzzle();
            System.Console.WriteLine(stateModel.State);

            SlidingPuzzleAction[] actionArr = stateModel.GetActions().ToArray();
   
            foreach(SlidingPuzzleAction action in actionArr)
            {
                System.Console.WriteLine(action);
            }

            System.Console.WriteLine(stateModel.TransitionState(actionArr[1]));

            SlidingPuzzle puzzle = (SlidingPuzzle) stateModel;
            //puzzle.ShuffleBoard();
            puzzle.SwapTile(actionArr[0].From, actionArr[0].To);

            System.Console.WriteLine(puzzle);

        }
    }

}
