using BlazorFlux.Stores.CouterStore;
using System;

namespace BlazorFlux.Stores
{
    public interface IActionDispatcher
    {
        void Dispatch(IAction action);
        void Subscript(Action<IAction> actionHandler);
        void Unsubscript(Action<IAction> actionHandler);
    }
}