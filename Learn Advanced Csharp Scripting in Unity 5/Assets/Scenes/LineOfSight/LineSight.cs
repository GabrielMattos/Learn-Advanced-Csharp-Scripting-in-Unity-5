using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSight : MonoBehaviour
{

    public enum sightSensitivity {STRICT, LOOSE};

    public sightSensitivity sensitity = sightSensitivity.STRICT;

    public bool canSeeTarget = false;

    public float fieldOfView = 45f;
    public Transform target = null;

    public Transform eyePoint = null;

    private Transform thisTranform = null;

    private SphereCollider thisCollider = null;

    public Vector3 lastKnowSighting = Vector3.zero;

    private void Awake() {
        
        thisTranform = GetComponent<Transform>();
        thisCollider = GetComponent<SphereCollider>();
        lastKnowSighting = thisTranform.position;
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

    bool ClearLineOfSight() {

        RaycastHit info;

        if(Physics.Raycast(eyePoint.position, (target.position - eyePoint.position).normalized, out info, thisCollider.radius)) {
            if(info.transform.CompareTag("Player"))
                return true;

        }

        return false;

    }

    void UpdateSigth() {

        switch (sensitity)
        {
            case sightSensitivity.STRICT:
            canSeeTarget = InFOV() && ClearLineOfSight();
            break;

            case sightSensitivity.LOOSE:
            canSeeTarget = InFOV() || ClearLineOfSight();
            break;
        }
    }

    private void OnTriggerStay(Collider other) {
        
        UpdateSigth();

        if(canSeeTarget) {
            lastKnowSighting = target.position;
        }
    }
}
