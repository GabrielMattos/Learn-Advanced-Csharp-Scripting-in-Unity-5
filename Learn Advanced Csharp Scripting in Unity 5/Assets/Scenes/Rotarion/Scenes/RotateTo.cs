using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTo : MonoBehaviour
{

    private Transform thisTransform;
    public float rotSpeed = 90f;
    public Transform target = null;
    public float damping = 55f;

    private void Awake() {
        
        thisTransform = this.gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //RotateTowards();
        RotateTowardsWithDamp();
    }

    void RotateTowards() {

        Quaternion destRot = Quaternion.LookRotation(target.position - transform.position, Vector3.up);

        thisTransform.rotation = Quaternion.RotateTowards(thisTransform.rotation, destRot, rotSpeed * Time.deltaTime);
    }

    void RotateTowardsWithDamp() {

        Quaternion destRot = Quaternion.LookRotation(target.position - transform.position, Vector3.up);

        Quaternion smoothRot = Quaternion.Slerp(transform.rotation, destRot, 1f - Time.deltaTime * damping);

        transform.rotation = smoothRot;
    }
}
