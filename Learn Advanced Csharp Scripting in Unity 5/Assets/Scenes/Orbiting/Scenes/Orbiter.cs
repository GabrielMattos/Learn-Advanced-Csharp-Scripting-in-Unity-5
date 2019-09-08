using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Orbiter : MonoBehaviour
{

    public Transform pivot = null;
    private Transform thisTransform = null;
    private Quaternion destRot = Quaternion.identity;
    public float pivotDistance = 5f;
    public float rotSpeed = 10f;
    private float rotX = 0f;
    private float rotY = 0f;

    private void Awake() {
        thisTransform = this.gameObject.GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horz = CrossPlatformInputManager.GetAxis("Horizontal");
        float vert = CrossPlatformInputManager.GetAxis("Vertical");

        rotX += vert * Time.deltaTime * rotSpeed;
        rotY += horz * Time.deltaTime * rotSpeed;

        Quaternion yRot = Quaternion.Euler(0f, rotY, 0f);
        destRot = yRot * Quaternion.Euler(rotX, 0f, 0f);

        thisTransform.rotation = destRot;

        //Adjust position
        thisTransform.position = pivot.position + thisTransform.rotation * Vector3.forward * -pivotDistance;
    }
}
