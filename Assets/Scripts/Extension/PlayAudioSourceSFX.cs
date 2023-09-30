using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioSourceSFX: MonoBehaviour {

	public float overrideAudioSourceVolume = 1f;
	public AudioSource overrideAudioSource;
	//private Transform myTransform;

	public void PlaySFX () {

		if(overrideAudioSource == null) {
			GetComponent<AudioSource>().PlayWebGL(GetComponent<AudioSource>().clip, overrideAudioSourceVolume);
		} else {
            overrideAudioSource.PlayWebGL(overrideAudioSource.clip, overrideAudioSourceVolume);
        }
		//myTransform = transform;
	}
	public void StopSFX() {

        if (overrideAudioSource == null) {
            GetComponent<AudioSource>().StopWebGL();
        } else {
            overrideAudioSource.StopWebGL();
        }
    }
	public void PlayLoudSFXInGameManager(AudioClip newAudioClip) {

		GameManager.SpawnLoudAudio(newAudioClip, new Vector2(), overrideAudioSourceVolume);
	}


	/*
	private void Update () {
		
	}
	*/
}
