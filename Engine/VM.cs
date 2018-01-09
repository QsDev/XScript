using System;
using System.Xml.Serialization;
using QsScript.Help;

namespace QsScript {
    public enum BreakType
    {
        None = 0,
        Continue = 1,
        Break = 2,
        Return = 4,
        Throw = 8,
        Exit = 16,

        Loop = Continue | Break,
        Method = Return,
    }
    [Serializable]
	public static class VM {
		public readonly static XmlSerializer Serializer = new XmlSerializer(typeof(Expression));
		private readonly static Stack Scops = new Stack();
		public readonly static Stack CleanedScop = new Stack();
		public readonly static Stack DirtyScops = new Stack();

		public static void Reset() {
			
			JumperCode = 0;
			IsBreak = false;
			IsContinue = false;
			IsReturn = false;
			IsThrow = false;
			BreakValue = null;
			ReturnValue = null;
			ThrowValue = null;
			while(Scops.Count > 0) {
				var s = Scops.Pop();
				if(s == null)
					continue;
				s.Dispose();
				CleanedScop.Push(s);
			}
			OpenScop();
			GlobalScop = CurrentScop;
		}

		internal static BasicObject ImportAssemblyFromUrl(string assembly) {
			throw new NotImplementedException();
		}

		internal static BasicObject ImportAssemblyFromFile(string assembly) {
			throw new NotImplementedException();
		}

		internal static BasicObject ImportAssemblyFromGaG(string assembly) {
			throw new NotImplementedException();
		}

		public static BasicObject CurrentScop { get; private set; }
		static VM() {
			OpenScop();
		}

		public static BasicObject GlobalScop { get; private set; }
		public static void OpenScop() {
			Scops.Push(CurrentScop);
			CurrentScop = CleanedScop.Pop() ?? new Scop(null) { isMultiScops = true };
			CurrentScop.Initialize();
		}

		internal static void SetScop(BasicObject scop) {
			Scops.Push(CurrentScop);
			CurrentScop = scop;
		}
		public static void OpenScop(BasicObject scop) {
			Scops.Push(CurrentScop);
			CurrentScop = scop;
			scop.Initialize();
		}
		public static void CloseScop(bool safe = false) {
			if(!safe) {
				CurrentScop.Dispose();
				CleanedScop.Push(CurrentScop);
			}
			CurrentScop = Scops.Pop();
		}
		internal static void AddFunction(Function function) {
			CurrentScop.Add(function);
		}

		public static int JumperCode { get; private set; }

		#region Throw
		public static bool IsThrow { get; private set; }
		private static BasicObject ThrowValue;
		internal static void SetThrow(BasicObject value) {
			JumperCode = 5;
			IsThrow = true;
			ThrowValue = value;
		}
		internal static BasicObject StopThrow() {
			JumperCode = 0;
			IsThrow = false;
			var l = ThrowValue;
			ThrowValue = null;
			return l;
		}
		#endregion

		#region Return
		public static bool IsReturn { get; private set; }
		private static BasicObject ReturnValue;

		internal static BasicObject GetCleanScop(BasicObject scop) {
			var x = CleanedScop.Pop();
			if(x == null)
				return new Scop(scop) { isMultiScops = true };
			if(x is Scop)
				((Scop) x).Base = scop;
			return x;
		}


		internal static void SetReturn(BasicObject value) {
			JumperCode = 4;
			ReturnValue = value;
			IsReturn = true;
		}
		internal static BasicObject StopReturn() {
			JumperCode = 0;
			IsReturn = false;
			var l = ReturnValue;
			ReturnValue = null;
			return l;
		}
        #endregion

        #region Break
        public static int _breakType = 0;

        public static bool IsLoopBreak => (_breakType & (int)BreakType.Loop) != 0;
        public static bool IsFunctionBreak => (_breakType & (int)BreakType.Method) != 0;
        public static BreakType Break
        {
            get => (BreakType)_breakType; set
            {
                if (_breakType != 0) throw new System.Exception("CodeBreack {" + (BreakType)_breakType + "} cannot be applyied");
                _breakType = (int)value;
            }
        }
        public static bool CanBlockContinue => _breakType != (int)BreakType.None;
        public static bool CanLoopContinue => _breakType > (int)BreakType.Continue;

        public static bool IsBreak { get; private set; }
		private static BasicObject BreakValue;
		internal static void SetBreak(BasicObject value) {
			JumperCode = 3;
			IsBreak = true;
			BreakValue = value;
		}
		internal static BasicObject StopBreak() {
			JumperCode = 0;
			IsBreak = false;
			var l = BreakValue;
			BreakValue = null;
			return l;
		}
		#endregion

		
		#region Continue
		public static bool IsContinue { get; private set; }
		internal static void SetContinue() {
			JumperCode = 2;
			IsContinue = true;
		}
		internal static void StopContinue() {
			JumperCode = 0;
			IsContinue = false;
		}

		#endregion


		#region Back
		public static bool IsBack { get; private set; }
		private static BasicObject BackValue;
		internal static void SetBack(BasicObject value) {
			JumperCode = 1;
			IsBack = true;
			BackValue = value;
		}
		internal static BasicObject StopBack() {
			JumperCode = 0;
			IsBack = false;
			var l = BackValue;
			BackValue = null;
			return l;
		}
		#endregion

	}

}
