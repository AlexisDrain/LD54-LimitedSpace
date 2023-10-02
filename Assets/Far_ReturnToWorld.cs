using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Far_ReturnToWorld : MonoBehaviour
{
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Vector3.Distance(startPosition, transform.position) > 50f) {
            ReturnToStartPos();
        }
    }
    // called in other scripts as well
    public void ReturnToStartPos() {
        transform.position = startPosition;
    }
}
