using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMoveToAngle : MonoBehaviour
{

    public Transform  destinationRotation;

    private Rigidbody myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
		myRigidbody = GetComponent<Rigidbody>();


    }
    // FixedUpdate: KINEMATIC ONLY
    public void FixedUpdate() {

        transform.rotation = Quaternion.Lerp(transform.rotation, destinationRotation.rotation, 0.1f);
    }

    public void SetDestinationAngle(Transform newDestination) {
        destinationRotation = newDestination;
    }

}
