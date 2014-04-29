using UnityEngine;
using System.Collections;

namespace ERosson {
	public class DebugUtil {
		public static void Assert(bool val, string message) {
			if (!val) {
				throw new System.Exception(message);
			}
		}

		public static void Assert(bool val) {
			Assert(val, "Assertion failed");
		}

		public static T AssertNotNull<T>(T val) {
			Assert(val != null);
			return val;
		}
	}
}