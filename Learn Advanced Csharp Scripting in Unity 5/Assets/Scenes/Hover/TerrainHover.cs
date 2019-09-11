using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class TerrainHover : MonoBehaviour
{

    private Transform thisTransform = null;
    public float maxSpeed = 10f;
    public float distanceFronGround = 2f;
    private Vector3 destUp = Vector3.zero;
    public float angleSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        thisTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float horz = CrossPlatformInputManager.GetAxis("Horizontal");
        float vert = CrossPlatformInputManager.GetAxis("Vertical");

        Vector3 newPos = thisTransform.position;
        newPos += thisTransform.forward * vert * maxSpeed * Time.deltaTime;
        newPos += thisTransform.right * horz * maxSpeed * Time.deltaTime;

        RaycastHit hit;
        if(Physics.Raycast(thisTransform.position, -Vector3.up, out hit)) {
            newPos.y = (hit.point + Vector3.up * distanceFronGround).y;
            destUp = hit.normal;
        }


        thisTransform.position = newPos;
        thisTransform.up = Vector3.Slerp(thisTransform.up, destUp, angleSpeed * Time.deltaTime);
    }
}
