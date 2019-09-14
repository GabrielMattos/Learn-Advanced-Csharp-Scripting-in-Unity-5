using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSight : MonoBehaviour
{

    public float fieldOfView = 45f;

    public Transform target = null;
    public Transform eyePoint = null;

    public bool canSeeTarget = false;

    private void OnTriggerStay(Collider target) {

        canSeeTarget = InFOV();
    }

    bool InFOV() {

        //Get direction to target
        Vector3 dirToTarget = target.position - eyePoint.position;

        //get angles between forward and look direction
        float angle = Vector3.Angle(eyePoint.forward, dirToTarget);

        //are we within field of view?
        if(angle <= fieldOfView)
            return true;
        
        //not within field
        return false;
    }
}
