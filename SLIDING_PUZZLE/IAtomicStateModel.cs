using System;
using System.Collections.Generic;

namespace SLIDING_PUZZLE
{
    public interface IAtomicStateModel<T>
    {
        //Property
        string State { get; }

        List<T> GenerateActions();
        string TransitionState(T action);
        double PathCost(T action);
    }
}
