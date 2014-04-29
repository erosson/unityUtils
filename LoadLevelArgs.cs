using UnityEngine;
using System.Collections;

namespace ERosson {
	public class LoadLevelArgs {
		// oh no, a mutable static value! It's the most practical way to pass parameters across Application.LoadLevel, though,
		// since LoadLevel destroys all GameObjects. Usage here is tightly controlled, too, usable only with loadlevel.
		//
		// Normally, mutable static values are pure evil. Careful about copying this.
		private static System.Object loadLevelArgs = null;
		
		public static void LoadLevel<T>(string level, T args) {
			Set(args);
			Application.LoadLevel(level);
		}
		public static void LoadLevel<T>(int level, T args) {
			Set(args);
			Application.LoadLevel(level);
		}
		
		// TODO expose this function? What about for other LoadLevel variants not directly supported here? (Are there any?)
		private static void Set<T>(T args) {
			DebugUtil.Assert(loadLevelArgs == null);
			DebugUtil.AssertNotNull(args);
			loadLevelArgs = args;
		}
		
		public static T Pop<T>(T default_) {
			if (loadLevelArgs == null) {
				return default_;
			}
			var ret = (T)loadLevelArgs;
			loadLevelArgs = null;
			return ret;
		}
		
		public static T Pop<T>() where T:new() {
			return Pop(new T());
		}
	}
}