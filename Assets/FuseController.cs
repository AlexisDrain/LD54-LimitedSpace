using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FuseController : MonoBehaviour
{
    public UnityEvent onMazeSuccess;
    private Vector3 startPos;
    private Rigidbody myRigidbody;
    void Start()
    {
        startPos = transform.position;
        myRigidbody = GetComponent<Rigidbody>();
    }

    public void OnTriggerEnter(Collider other) {

        if(other.CompareTag("Maze")) {
            if(other.name == "MazeEnd") {
                onMazeSuccess.Invoke();
                KillFuse();
                print("Maze Success snd + particles. Turn on computer sound");
            } else {
                KillFuse();
            }
        }
    }
    void KillFuse()
    {
        print("spark particles + sound");
        GetComponent<PlayerUsable>().Drop();
        transform.position = startPos;
        myRigidbody.position = startPos;
    }
}
