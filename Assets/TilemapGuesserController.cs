using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapGuesserController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("TilemapRed")) {
            GameManager.gameManagerObject.GetComponent<GameManager>().ExplodeVessel();
        }
    }
}
