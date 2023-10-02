using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FuseController : MonoBehaviour
{
    public UnityEvent onMazeSuccess;
    public UnityEvent onMazeFail;
    private Vector3 startPos;
    private Rigidbody myRigidbody;

    public ParticleSystem particleSystem_sparks;
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
            } else {
                onMazeFail.Invoke();
                KillFuse();
            }
        }
    }
    void KillFuse()
    {
        particleSystem_sparks.transform.position = transform.position;
        particleSystem_sparks.Play();

        GetComponent<PlayerUsable>().Drop();
        transform.position = startPos;
        myRigidbody.position = startPos;


    }
}
