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
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool left = Input.GetKey(KeyCode.J);
        bool right = Input.GetKey(KeyCode.L);
        if (left == true) {
            transform.eulerAngles += new Vector3(0, 0, rotationSpeed);
        } else if(right == true) {
            transform.eulerAngles += new Vector3(0, 0, -rotationSpeed);
        }

        if (Input.GetKey(KeyCode.I)) {
            myRigidbody2D.AddForce(transform.up * forwardSpeed, ForceMode2D.Force);
        }
    }
}
