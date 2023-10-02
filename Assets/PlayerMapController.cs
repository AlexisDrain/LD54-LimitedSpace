using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMapController : MonoBehaviour
{
    public float rotationSpeed = 0.3f;
    public float forwardSpeed = 0.01f;

    public BoxCollider2D tileGuesser;
    private Rigidbody2D myRigidbody2D;

    private int turnDirection;
    private bool moveForward;
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void TurnHorizontally(int direction) {
        turnDirection = direction;
    }
    public void StopTurnHorizontally(int direction) {
        turnDirection = 0;
    }
    public void MoveForward() {
        moveForward = true;
    }
    public void StopMoveForward() {
        moveForward = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (turnDirection == -1) {
            transform.eulerAngles += new Vector3(0, 0, rotationSpeed);
        } else if(turnDirection == 1) {
            transform.eulerAngles += new Vector3(0, 0, -rotationSpeed);
        }

        if (moveForward) {
            myRigidbody2D.AddForce(transform.up * forwardSpeed, ForceMode2D.Force);
        }


    }
}
