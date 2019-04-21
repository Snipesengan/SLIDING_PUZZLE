using System;
using System.Collections.Generic;

namespace StateModel.Interface
{
    public interface IAtomicState<THash,TAction>
    {
        //Methods
        THash GetState();
        void SetState(THash state);
        List<TAction> GetActions();
        THash TransitionState(TAction action);
        double PathCost(TAction action);
    }
}
