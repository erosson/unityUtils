using UnityEngine;
using System.Collections;

namespace ERosson {
	public class TitleScreenScaffold : MonoBehaviour {
		public AudioClip select;
		public Texture2D titleLogo = null;
		public string titleText = "";
		public string tutorialText = "";
		public string mainLevelName = "Game";
		public string website = "";

		void OnGUI() {
			GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
			RenderTitle(titleLogo, titleText);
			if (tutorialText != "") {
				GUILayout.Box(tutorialText);
			}
			DebugUtil.Assert(mainLevelName != "");
			if (GUILayout.Button ("\nPlay\n")) {
				Audio.PlayClipAtPoint(select, transform);
				Application.LoadLevel(mainLevelName);
			}
			if (website != "") {
				if (GUILayout.Button ("Website")) {
					Audio.PlayClipAtPoint(select, transform);
					Application.OpenURL(website);
				}
			}
			if (!Application.isWebPlayer && !Application.isEditor) {
				if (GUILayout.Button("Exit")) {
					Audio.PlayClipAtPoint(select, transform);
					Application.Quit();
				}
			}
			GUILayout.EndArea();
		}

		void Update() {
			if (Input.GetKeyDown (KeyCode.Escape)) {
				Audio.PlayClipAtPoint(select, transform);
				Application.Quit();
			}
		}

		// shared with GameOverScaffold. I want Java's package-level access :(
		internal static void RenderTitle(Texture2D img, string text) {
			// image xor text; exactly one is required
			DebugUtil.Assert(img == null ^ text == "");

			if (img != null) {
				GUI.backgroundColor = Color.clear;
				// box is centered
				GUILayout.Box(img);
				GUI.backgroundColor = Color.white;
			}
			if (text != "") {
				GUI.backgroundColor = Color.clear;
				// box is centered
				var fontSize = GUI.skin.box.fontSize;
				GUI.skin.box.fontSize = 36;
				GUILayout.Box(text);
				GUI.skin.box.fontSize = fontSize;
				GUI.backgroundColor = Color.white;
			}
		}
	}
}