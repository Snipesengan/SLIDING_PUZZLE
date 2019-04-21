using System;
using System.Collections.Generic;
using StateModel.Interface;

namespace StateModel.InformedSearch
{
    public class A_StarSearch<THash, TAction>
    {
        private IAtomicState<THash, TAction> curState;
        private IAtomicState<THash, TAction> goalState;
        private Dictionary<THash,IAtomicState<THash,TAction>> visited;
        private SortedList<double, THash> priorityQ;

        public A_StarSearch(IAtomicState<THash,TAction> startState,
            IAtomicState<THash,TAction> goalState)
        {
            curState = startState;
            this.goalState = goalState;
        }

        public Queue<THash> FindShortestPath()
        {
            Queue<THash> path = new Queue<THash>();

            SortedList<double, THash> priorityQ =
                new SortedList<double, THash>();

            priorityQ.Add(0, curState.GetState());
            visited.Add(curState.GetState(), curState);
            do
            {
                curState = visited[priorityQ[]]
            } while (priorityQ.Count > 0);

            return path;
        }


    }
}
