using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private static Pool pool_LoudAudioSource;
    public static PlayerUse playerUse;
    public static Text hintText;
    public static Text mainUseText;

    // Start is called before the first frame update
    void Awake()
    {

        pool_LoudAudioSource = transform.Find("Pool_LoudAudioSource").GetComponent<Pool>();

        playerUse = GameObject.Find("Player/PlayerCameraRoot/MainCamera").GetComponent<PlayerUse>();
        hintText = GameObject.Find("Canvas/HintText").GetComponent<Text>();
        mainUseText = GameObject.Find("Canvas/MainUseText").GetComponent<Text>();
    }
    public static AudioSource SpawnLoudAudio(AudioClip newAudioClip, Vector2 pitch = new Vector2(), float newVolume = 1f) {

        float sfxPitch;
        if (pitch.x <= 0.1f) {
            sfxPitch = 1;
        } else {
            sfxPitch = Random.Range(pitch.x, pitch.y);
        }

        AudioSource audioObject = pool_LoudAudioSource.Spawn(new Vector3(0f, 0f, 0f)).GetComponent<AudioSource>();
        audioObject.GetComponent<AudioSource>().pitch = sfxPitch;
        audioObject.PlayWebGL(newAudioClip, newVolume);
        return audioObject;
        // audio object will set itself to inactive after done playing.
    }
}
