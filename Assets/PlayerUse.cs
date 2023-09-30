using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUse : MonoBehaviour
{
    public Transform grabLocation;

    private Transform currentPickedUpObject;
    void Start()
    {
        
    }

    private void Update() {
        if (Input.GetButtonDown("Use")) {
            if (currentPickedUpObject) {
                currentPickedUpObject.GetComponent<PlayerUsable>().Drop();
                currentPickedUpObject = null;
                return;
            }
        }

        RaycastHit hit;
        Physics.Linecast(transform.position, (transform.position + transform.forward * 5), out hit);

        if (hit.collider != null) {
            // hint text
            if (hit.collider.CompareTag("Movable")) {
                GameManager.mainUseText.text = "Pickup: [E] [LeftMouse]";
                GameManager.hintText.text = hit.collider.GetComponent<PlayerUsable>().itemNameHint;
            }
            else if (hit.collider.CompareTag("Use")) {
                GameManager.mainUseText.text = "Use: [E] [LeftMouse]";
                GameManager.hintText.text = hit.collider.GetComponent<PlayerUsable>().itemNameHint;
            } else {
                GameManager.mainUseText.text = "";
                GameManager.hintText.text = "";
            }

            // actual use
            if (hit.collider.CompareTag("Movable") && Input.GetButtonDown("Use")) {

                currentPickedUpObject = hit.collider.transform;
                currentPickedUpObject.GetComponent<PlayerUsable>().PickUp();
            } else if (hit.collider.CompareTag("Use") && Input.GetButtonDown("Use")) {
                hit.collider.GetComponent<PlayerUsable>().TriggerFunction();
            }
            

        }
        else { // nothing hit
            GameManager.mainUseText.text = "";
            GameManager.hintText.text = "";
        }
    }

}
