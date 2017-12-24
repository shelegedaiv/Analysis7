using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Analysis7.Model.Observer
{
    [Serializable]
    public abstract class Subject
    {
        [NonSerialized]
        private List<IListener>  _listeners=new List<IListener>();

        private void _setList()
        {
            if (_listeners is null) _listeners=new List<IListener>();
        }
        public void Notify()
        {
            _setList();
            foreach (var listener in _listeners)     {
                listener.Update();
            }
        }

        public void AttachListener(IListener listener)
        {
            _setList();
            _listeners.Add(listener);
        }
    }
}