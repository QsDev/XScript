using System;
using System.Threading;

namespace QsScript.Help {
	[Serializable]
    public class Stack
    {
        volatile BasicObject[] Scops;
        volatile int index = -1;
        [NonSerialized]
        volatile Thread _onRun;

        public int Count => index + 1;

        public Stack(int max = 10000)
        {
            Scops = new Scop[max];
        }

        public BasicObject _Pop()
        {
            lock (this) {
            deb:
                if (_onRun == null) { _onRun = Thread.CurrentThread; }
                else {
                    Thread.Sleep(10);
                    goto deb;
                }
                BasicObject l = Pop();
                _onRun = null;
                return l;
            }
        }
        public void _Push(BasicObject s)
        {
            lock (this) {
            deb:
                if (_onRun == null) { _onRun = Thread.CurrentThread; }
                else {
                    Thread.Sleep(1);
                    goto deb;
                }
                Push(s);
                _onRun = null;
            }
        }

        public BasicObject Pop()
        {
            if (index < 0) return null;
            return Scops[index--];
        }
        public void Push(BasicObject s)
        {
            if (index >= 10000) throw null;
            Scops[++index] = s;
        }

        public void Clean() { index = -1; }
    }

}
