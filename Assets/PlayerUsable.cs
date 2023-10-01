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
    public UnityEvent onUseTrigger;
    public UnityEvent onDropTrigger;
    public bool useGravity = true;
    public bool disableColliderOnPickup = true;
    public bool pickedUp = false;
    public Vector3 pickupRotation = new Vector3(0f,0f,0f);

    public bool holdable = false;
    private bool holdingRight = false;
    private bool holdingLeft = false;

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

    public void Hold(bool direction) {

        if(holdingLeft || holdingRight) {
            return;
        }

        if (direction == false) {
            holdingLeft = true;
        } else {
            holdingRight = true;
        }
    }

    public void StopHold() {

        holdingLeft = false;
        holdingRight = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(pickedUp) {
            myRigidbody.MoveRotation(Quaternion.Euler(pickupRotation));
            myRigidbody.MovePosition(GameManager.playerUse.grabLocation.position);
        }
    }
}
