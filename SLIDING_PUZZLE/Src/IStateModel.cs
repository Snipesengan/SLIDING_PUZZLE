using System;
using System.Collections.Generic;

namespace StateModel.Interface
{
    public interface IAtomicStateModel<E,T>
    {
        //Property
        E State { get;}

        //Methods
        List<T> GetActions();
        E TransitionState(T action);
        double PathCost(T action);
    }
}
