using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileHole : MonoBehaviour
{
    private bool hasMissile = false;

    public AudioClip upwaterExplosionClip;
    public AudioClip noMissileClip;
    public AudioClip hasMissileClip;

    public MeshRenderer missileGraphicsMesh;
    public Animator missileHoleAnimator;

    void Start()
    {
        
    }

    public void PressLaunchButton() {
        if(hasMissile) {
            missileHoleAnimator.SetTrigger("ShootMissile");
            hasMissile = false;
            GameManager.playerTileMapGuesser.ShootMissile();
            StopCoroutine("RemoveMissileGraphic");
            StartCoroutine("RemoveMissileGraphic");
            StartCoroutine("DelayedMissileExplosions");
            GameManager.SpawnLoudAudio(hasMissileClip);
        } else {
            missileHoleAnimator.SetTrigger("ShootNoMissile");
            GameManager.SpawnLoudAudio(noMissileClip);
        }
    }

    private IEnumerator RemoveMissileGraphic() {
        yield return new WaitForSeconds(2f);
        missileGraphicsMesh.enabled = false;
    }
    private IEnumerator DelayedMissileExplosions() {
        yield return new WaitForSeconds(4f);
        GameManager.SpawnLoudAudio(upwaterExplosionClip);
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider col)
    {
        if(hasMissile == false) {

            if(col.CompareTag("Missile")) {
                hasMissile = true;

                missileHoleAnimator.SetTrigger("PutInMissile");
                missileGraphicsMesh.enabled = true;
                col.transform.parent.GetComponent<PlayerUsable>().Drop();
                col.transform.parent.GetComponent<Far_ReturnToWorld>().ReturnToStartPos();

            }
        } 

    }
}
