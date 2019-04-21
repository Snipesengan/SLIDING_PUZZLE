using System;
using StateModel.InformedSearch;
using StateModel.Interface;
using StateModel.BoardGame;

namespace StateModel
{
    public class Driver
    {
        public static void Main(String[] args)
        {
            SlidingPuzzle stateModel = new SlidingPuzzle();
            stateModel.ShuffleBoard();
            //stateModel.State;
            A_StarSearch<string, SlidingPuzzleAction> searcher;

        }
    }

}
