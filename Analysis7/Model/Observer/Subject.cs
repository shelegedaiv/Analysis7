using System;
using System.Collections.Generic;

namespace Analysis7.Model.Observer
{
    [Serializable]
    public abstract class Subject
    {
        [NonSerialized]
        private List<IListener> _listenersViewModel;
        private List<IListener> _listeners;

        private void _setList()
        {
            if (_listeners is null) _listeners=new List<IListener>();
            if (_listenersViewModel is null) _listenersViewModel=new List<IListener>();
        }
        public void Notify()
        {
            _setList();
            foreach (var listener in _listeners)     {
                listener.Update();
            }
            foreach (var listener in _listenersViewModel)        {
                listener.Update();
            }
        }

        public void AttachListener(IListener listener)
        {
            _setList();
            _listeners.Add(listener);
        }

        public void AttachListenerViewModel(IListener listener)
        {
            _setList();
            _listenersViewModel.Add(listener);
        }    
    }
}