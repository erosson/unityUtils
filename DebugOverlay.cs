using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ERosson {
	/**
	 * Show debug variables in the bottom left of the screen with a single call.
	 */
	public class DebugOverlay : MonoBehaviour {
		private struct OverlayVar {
			public string Name;
			public OverlayGetter ValueFn;

			public OverlayVar(string name, OverlayGetter valFn) {
				Name = name;
				ValueFn = valFn;
			}

			public override string ToString() {
				return string.Format("{0}: {1}", Name, ValueFn());
			}
		}

		public delegate System.Object OverlayGetter();
		private List<OverlayVar> getters = new List<OverlayVar>();
		// Mutable static, as required by singletons.
		private static DebugOverlay singleton = null;

		[MethodImpl(MethodImplOptions.Synchronized)]
		private static void Init() {
			if (singleton == null) {
				var gameobject = new GameObject();
				gameobject.name = "DebugOverlay";
				gameobject.AddComponent("DebugOverlay");
				singleton = DebugUtil.AssertNotNull(gameobject.GetComponent<DebugOverlay>());
			}
		}

		// This is the only public interface to DebugOverlay.
		public static void Watch(string name, OverlayGetter getter) {
			if (Debug.isDebugBuild) {
				Init();
				singleton.Add(name, getter);
			}
		}

		private DebugOverlay() {
			// private ctor; singleton
		}

		void Add(string name, OverlayGetter getter) {
			getters.Add(new OverlayVar(name, getter));
		}

		void OnGUI() {
			GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
			var lines = new List<string>();
			foreach (var pair in getters) {
				lines.Add(pair.ToString());
			}
			// FlexibleSpace aligns bottom; GUI style aligns box contents left. 
			// This isn't styleable - the singleton doesn't exist in the inspector before running -
			// but screw it, if you really want a styleable overlay, write your own.
			var style = new GUIStyle(GUI.skin.GetStyle("box"));
			style.alignment = TextAnchor.LowerLeft;
			GUILayout.FlexibleSpace();
			GUILayout.Box(string.Join("\n", lines.ToArray()), style, GUILayout.ExpandWidth (false));
			GUILayout.EndArea();
		}
	}
}