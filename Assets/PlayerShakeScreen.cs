using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerShakeScreen : MonoBehaviour
{

    public Vector2 shakeRange = new Vector2(10f, 35f);
    private float destinationShakeAngle;

    [Header("Read only")]
    public bool shake = false;

    private bool right = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(shake == false) {
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0f);
            return;
        }
        if(Mathf.Abs(transform.rotation.z) - Mathf.Abs(destinationShakeAngle) < 0.1f) {
            destinationShakeAngle = Random.Range(shakeRange.x, shakeRange.y);
            if(right) {
                right = false;
            } else if(right == false) {
                right = true;
                destinationShakeAngle = -destinationShakeAngle;
            }
        }

        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, Mathf.LerpAngle(transform.eulerAngles.z, destinationShakeAngle, 0.1f));
    }
}
