using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyObj : MonoBehaviour
{
    public UnityEvent onDestroy;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Destroy()
    {
        onDestroy?.Invoke();
        Destroy(gameObject);
    }
}
