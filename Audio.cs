using UnityEngine;
using System.Collections;

public class Audio {
	// source: http://answers.unity3d.com/questions/316575/adjust-properties-of-audiosource-created-with-play.html
	public static AudioSource PlayClipAtPoint(AudioClip clip, Vector3 pos){
		GameObject tempGO = new GameObject("One Shot Audio"); // create the temp object
		tempGO.transform.position = pos; // set its position
		AudioSource aSource = tempGO.AddComponent<AudioSource>(); // add an audio source
		aSource.clip = clip; // define the clip
		// set other aSource properties here, if desired
		aSource.Play(); // start the sound
		MonoBehaviour.DontDestroyOnLoad(tempGO);
		MonoBehaviour.Destroy(tempGO, clip.length); // destroy object after clip duration
		return aSource; // return the AudioSource reference
	}
	
	public static AudioSource PlayClipAtPoint(AudioClip clip, Vector2 pos) {
		return PlayClipAtPoint(clip, new Vector3(pos.x, pos.y, 0));
	}
	
	public static AudioSource PlayClipAtPoint(AudioClip clip, Transform t) {
		return PlayClipAtPoint(clip, t.position);
	}

	// TODO use main camera instead?
	public static AudioSource PlayClip(AudioClip clip) {
		return PlayClipAtPoint(clip, Vector3.zero);
	}
}
