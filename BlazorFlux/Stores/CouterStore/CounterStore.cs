using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorFlux.Stores.CouterStore
{
    public class CounterState
    {
        public int Count { get; }
        public CounterState(int count)
        {
            Count = count;
        }

    }
    public class CounterStore
    {
        private CounterState _state;
        public CounterState GetState()
        {
            return _state;
        }

        private readonly IActionDispatcher _actionDispatcher;
        public CounterStore(IActionDispatcher actionDispatcher)
        {
            _state = new CounterState(0);
            _actionDispatcher = actionDispatcher;
            _actionDispatcher.Subscript(HandleActions);
        }

        private void HandleActions(IAction action)
        {
            switch (action.Name)
            {
                case IncrementAction.INCREMENT:
                    IncrementCount();
                    break;
                case DecrementAction.DECREMENT:
                    DecrementCount();
                    break;
                default:
                    break;

            }
        }

        private void IncrementCount()
        {
            var count = this._state.Count;
            count++;
            this._state = new CounterState(count);
            BroadcastStateChange();
        }

        private void DecrementCount()
        {
            var count = this._state.Count;
            count++;
            this._state = new CounterState(count);
            BroadcastStateChange();
        }

        #region Observer Pattern

        private Action _listeners;

        public void AddStateChangeListeners(Action listener)
        {
            _listeners += listener;
        }

        public void RemoveStateChangeListeners(Action listener)
        {
            _listeners -= listener;
        }

        private void BroadcastStateChange()
        {
            _listeners.Invoke();
        }

        #endregion
    }
}
