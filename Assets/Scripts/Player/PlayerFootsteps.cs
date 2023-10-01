using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    public List<AudioClip> footsteps;
    public Vector2 footstepPitch;
    public float distanceToPlayFootstep = 1f;
    public AudioSource audioSourceFootsteps;

    private Vector3 oldFootprintLocation;
    private Vector3 currentFootprintLocation;

    void Start() {
        oldFootprintLocation = new Vector3(transform.position.x, 0f, transform.position.z);
        currentFootprintLocation = new Vector3(transform.position.x, 0f, transform.position.z);

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // movement footsteps
        currentFootprintLocation = new Vector3(transform.position.x, 0f, transform.position.z);
        if (Vector3.Distance(currentFootprintLocation, oldFootprintLocation) > distanceToPlayFootstep) {
            oldFootprintLocation = currentFootprintLocation;
            PlayFootstep();
        }
        // reset footstep counter if paused
        //Vector2 horizontalVelocity = new Vector2(GameManager.playerTrans.GetComponent<CharacterController>().velocity.x, GameManager.playerTrans.GetComponent<CharacterController>().velocity.z);
        //if(horizontalVelocity.magnitude <= 0.5f) {
        //    oldFootprintLocation = currentFootprintLocation;
        //}
    }

    public void PlayFootstep() {

        int stepSound = Random.Range(0, footsteps.Count);
        float randPitch = Random.Range(footstepPitch.x, footstepPitch.y);
        audioSourceFootsteps.clip = footsteps[stepSound];
        audioSourceFootsteps.pitch = randPitch;

        audioSourceFootsteps.PlayWebGL();
    }
}
