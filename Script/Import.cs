using System;

namespace QsScript {

	public enum PathType {
		GaG,File,Url
	}
	[Serializable]
	public class Import : Expression {
        public override bool IsCalculable => true;
        public string Assembly;
		public PathType PathType;
		public Import() {

		}
		public Import(PathType pathType,string assembly) {
			this.Assembly = assembly;
			this.PathType = pathType;

		}
		protected override BasicObject calc() {
			switch(PathType) {
				case PathType.GaG:
					return VM.ImportAssemblyFromGaG(Assembly);
					break;
				case PathType.File:
				 return	VM.ImportAssemblyFromFile(Assembly);
					break;
				case PathType.Url:
					  return VM.ImportAssemblyFromUrl(Assembly);
					break;
				default:
					VM.SetThrow(Void.Value);
					return Void.Value;
			}
		}
	}
}
