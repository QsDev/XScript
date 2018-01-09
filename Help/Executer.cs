using System;

namespace QsScript.Help {
	[Serializable]
    public static class Executer_
    {
        private readonly static Stack Scops = new Stack();
        public readonly static Stack CleanedScop = new Stack();
        public readonly static Stack DirtyScops = new Stack();

        public static void Reset()
        {
            Scops.Clean();
            OpenScop();
            GlobalScop = CurrentScop;
        }
        public static BasicObject CurrentScop { get; private set; }
        static Executer_()
        {
            OpenScop();
        }

        public static BasicObject GlobalScop { get; private set; }
        public static void OpenScop()
        {
            Scops.Push(CurrentScop);
            CurrentScop = CleanedScop.Pop() ?? new Scop(null) { isMultiScops = true };
            CurrentScop.Initialize();
        }

        internal static void SetScop(BasicObject scop)
        {
            Scops.Push(CurrentScop);
            CurrentScop = scop;
        }
        public static void OpenScop(BasicObject scop)
        {
            Scops.Push(CurrentScop);
            CurrentScop = scop;
            scop.Initialize();
        }
        public static void CloseScop(bool safe = false)
        {
            if (!safe)
            {
                CurrentScop.Dispose();
                CleanedScop.Push(CurrentScop);
            }
            CurrentScop = Scops.Pop();
        }
        //public static void Declare(string v, Expression exp = null)
        //{
        //    CurrentScop[v] = exp;
        //}
        internal static void AddFunction(Function function)
        {
            CurrentScop.Add(function);
        }

        public static int IsBack { get; private set; }

        #region Throw
        public static bool IsThrow { get; private set; }
        private static BasicObject ThrowValue;
        internal static void SetThrow(BasicObject value)
        {
            IsBack = 1;
            IsThrow = true;
            ThrowValue = value;
        }
        internal static BasicObject StopThrow()
        {
            IsBack = 0;
            IsThrow = false;
            var l = ThrowValue;
            ThrowValue = null;
            return l;
        }
        #endregion

        #region Return
        public static bool IsReturn { get; private set; }
        private static BasicObject ReturnValue;

        internal static BasicObject GetCleanScop(BasicObject scop)
        {
            var x = CleanedScop.Pop();
            if (x == null)
                return new Scop(scop) { isMultiScops = true };
            if (x is Scop)
                ((Scop)x).Base = scop;
            return x;
        }


        internal static void SetReturn(BasicObject value)
        {
            IsBack = 2;
            ReturnValue = value;
            IsReturn = true;
        }
        internal static BasicObject StopReturn()
        {
            IsBack = 0;
            IsReturn = false;
            var l = ReturnValue;
            ReturnValue = null;
            return l;
        }
        #endregion

        #region Break
        public static bool IsBreak { get; private set; }
        private static BasicObject BreakValue;
        internal static void SetBreak(BasicObject value)
        {
            IsBack = 3;
            IsBreak = true;
            BreakValue = value;
        }
        internal static BasicObject StopBreak()
        {
            IsBack = 0;
            IsBreak = false;
            var l = BreakValue;
            BreakValue = null;
            return l;
        }
        #endregion

        #region Continue
        public static bool IsContinue { get; private set; }
        internal static void SetContinue()
        {
            IsBack = 4;
            IsContinue = true;
        }
        internal static void StopContinue()
        {
            IsBack = 0;
            IsContinue = false;
        }

        #endregion

    }

}
