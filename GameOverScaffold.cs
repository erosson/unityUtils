using UnityEngine;
using System.Collections;

namespace ERosson {
	public class GameOverScaffold : MonoBehaviour {
		public AudioClip select;
		public Texture2D titleLogo = null;
		public string titleText = "";
		public string defaultGameOverText = "Game over!";
		public string titleScreenLevelName = "TitleScreen";
		private string gameOverText;

		void Start() {
			gameOverText = LoadLevelArgs.Pop<System.Object>(defaultGameOverText).ToString();
		}
	    
		void OnGUI() {
			GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
			TitleScreenScaffold.RenderTitle(titleLogo, titleText);
	        if (gameOverText != "") {
				GUILayout.Box(gameOverText);
			}
			DebugUtil.Assert(titleScreenLevelName != "");
			if (GUILayout.Button ("\nReturn to Title\n")) {
				Audio.PlayClipAtPoint(select, transform);
				Application.LoadLevel(titleScreenLevelName);
			}
	        GUILayout.EndArea();
	    }
	    
	    void Update() {
	        if (Input.GetKeyDown(KeyCode.Escape)) {
				Audio.PlayClipAtPoint(select, transform);
				Application.LoadLevel(titleScreenLevelName);
            }
	    }
	}
}