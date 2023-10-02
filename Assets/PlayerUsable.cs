using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerUsable : MonoBehaviour
{
    public string itemNameHint = "";
    [TextArea(2,2)]
    public string customUseText = "";
    [Header("OnUse = start hold right")]
    public UnityEvent onUseTrigger;
    public UnityEvent onUseAltTrigger;
    public UnityEvent onDropTrigger;
    public UnityEvent onStopUseTrigger;
    public bool useGravity = true;
    public bool disableColliderOnPickup = true;
    public bool pickedUp = false;
    public Vector3 pickupRotation = new Vector3(0f,0f,0f);

    public bool alternateDirection = false;
    private int direction = 1;
    private bool holding = false;

    private Rigidbody myRigidbody;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }
    public void TriggerFunction() {
        onUseTrigger.Invoke();
    }
    public void PickUp() {
        onUseTrigger.Invoke();
        if(disableColliderOnPickup) {
            GetComponent<MeshCollider>().enabled = false;
        }
        myRigidbody.useGravity = false;
        pickedUp = true;
    }
    public void Drop() {
        onDropTrigger.Invoke();
        GetComponent<MeshCollider>().enabled = true;
        if(useGravity) {
            myRigidbody.useGravity = true;
        }
        pickedUp = false;
    }

    public void StartHold() {

        if(holding == true) {
            return;
        }
        if(alternateDirection) {
            if(direction == 1) {
                direction = -1;
                onUseAltTrigger.Invoke();
            } else {
                direction = 1;
                onUseTrigger.Invoke();
            }
        }
    }
    public void StopHold() {
        onStopUseTrigger.Invoke();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(holding) {
            if(Input.GetButtonUp("Use")) {
                StopHold();
            }
        }

        if(pickedUp) {
            myRigidbody.MoveRotation(Quaternion.Euler(pickupRotation));
            myRigidbody.MovePosition(GameManager.playerUse.grabLocation.position);
        }
    }
}
