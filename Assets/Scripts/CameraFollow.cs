using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    //Target camera will look at
    public Transform targetToFollow;

    //Distance from camera to target
    private int distance = -10;

    //Time until camera searches for target
    private float nextTimeToSearchForTarget = 0f;

    //Update is called once per frame
    void Update() {

        //If the target is null (died), search to find it
        if(targetToFollow == null) {
            SearchForTarget();
        } else {
            transform.position = targetToFollow.position + new Vector3(0, 0, distance);     //If target != null, set camera's position to target's position with a 10 space distance
        }

    }


    //Method to search for the target for the camera
    private void SearchForTarget() {

        //If time allotted to search is less than or equal to the current time in the game, then find the target
        if(nextTimeToSearchForTarget <= Time.time) {
            targetToFollow = GameObject.FindGameObjectWithTag("Player").transform;      //Sets target equal to the player's transform
        }

        nextTimeToSearchForTarget = Time.time + 0.5f;                           //Set the time to search for target to .5 + the current time

    }


}
