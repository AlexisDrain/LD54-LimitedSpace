using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToggleAudio : MonoBehaviour
{
    public bool pauseAndUnpause = true;
    bool started = false;
    public UnityEvent onTurnedOn;
    public UnityEvent onTurnedOff;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Toggle()
    {
        if (GetComponent<AudioSource>().isPlaying) {
            if(pauseAndUnpause) {
                GetComponent<AudioSource>().Pause();
            } else {
                GetComponent<AudioSource>().StopWebGL();
            }
            onTurnedOff.Invoke();
        } else {
            if (pauseAndUnpause && started == true) {
                GetComponent<AudioSource>().UnPause();
            } else {
                started = true;
                GetComponent<AudioSource>().PlayWebGL();
            }
            onTurnedOn.Invoke();
        }
    }
}
