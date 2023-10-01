using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileHole : MonoBehaviour
{


    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider col)
    {
        print(col.name + " " + col.tag);
    }
}
