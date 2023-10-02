using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapGuesserController : MonoBehaviour {
    public Tilemap allTilemap;
    void Start() {

    }

    public void ShootMissile() {
        GameObject missile = GameManager.pool_MapMissiles.Spawn(transform.position);
    }

    private void Update() {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.O)) {
            print("Player override shoot missle");
            ShootMissile();
        }

        // Vector3Int currentPos = allTilemap.WorldToCell(transform.position);
        // print(currentPos);
        // print(allTilemap.GetTile(currentPos));
    }
    private IEnumerator StopShake() {
        yield return new WaitForSeconds(15f);
        GameManager.playerShakescreen.shake = false;

    }
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        
        if(col.CompareTag("TilemapRed")) {
            GameManager.gameManagerObject.GetComponent<GameManager>().ExplodeVessel();
        } else if (col.CompareTag("TilemapYellow")) {
            GameManager.playerShakescreen.shake = true;
            StopCoroutine("StopShake");
            StartCoroutine("StopShake");
        } else if (col.CompareTag("TilemapNothing")) {
            GameManager.playerShakescreen.shake = false;
        } else if (col.CompareTag("TilemapTarget")) {
            GameManager.playerShakescreen.shake = false;
        } else {

            GameManager.playerShakescreen.shake = false;
        }
    }
}
