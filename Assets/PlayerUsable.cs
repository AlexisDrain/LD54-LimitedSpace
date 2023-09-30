using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerUsable : MonoBehaviour
{
    public string itemNameHint = "";
    public UnityEvent onUseTrigger;
    public bool pickedUp = false;
    public Vector3 pickupRotation = new Vector3(0f,0f,0f);

    private Rigidbody myRigidbody;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }
    public void TriggerFunction() {
        onUseTrigger.Invoke();
    }
    public void PickUp() {
        GetComponent<MeshCollider>().enabled = false;
        myRigidbody.useGravity = false;
        pickedUp = true;
    }
    public void Drop() {
        GetComponent<MeshCollider>().enabled = true;
        myRigidbody.useGravity = true;
        pickedUp = false;
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
