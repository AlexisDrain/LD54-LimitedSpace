using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    public TriggerSequence explosionTriggerSeq;
    void OnEnable()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("TilemapTarget")) {
            col.GetComponent<DestroyObj>().Destroy();
        }
    }
}
