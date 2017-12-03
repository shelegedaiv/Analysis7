using System.Collections.Generic;

namespace Analysis7.Model.Observer
{
    public abstract class Subject
    {
        private readonly List<IListener>  _listeners=new List<IListener>();

        public void Notify()
        {
            foreach (var listener in _listeners)     {
                listener.Update();
            }
        }

        public void AttachListener(IListener listener)
        {
            _listeners.Add(listener);
        }
    }
}