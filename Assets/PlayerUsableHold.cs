using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerUsableHold : MonoBehaviour
{
    public string itemNameHint = "";
    [TextArea(2,2)]
    public string customUseText = "";
    [Header("OnUse = start hold right")]
    public UnityEvent onStartUseRightTrigger;
    public UnityEvent onStartUseLeftTrigger;
    public UnityEvent onStopUseTrigger;

    public bool alternateDirection = false;
    private int direction = 1;
    private bool holding = false;

    void Start()
    {
        
    }


    public void StartHold() {

        if(holding == true) {
            return;
        }
        if(alternateDirection) {
            if(direction == 1) {
                direction = -1;
                onStartUseLeftTrigger.Invoke();
                itemNameHint = "Turn Valve Left"; // HACK HACK HACK
            } else {
                direction = 1;
                onStartUseRightTrigger.Invoke();
                itemNameHint = "Turn Valve Right"; // HACK HACK HACK
            }
        } else {
            onStartUseRightTrigger.Invoke();
        }
        holding = true;
    }


    void Update()
    {
        if(holding) {
            if(Input.GetButtonUp("Use")) {
                onStopUseTrigger.Invoke();
                holding = false;
            }
        }
    }
}
