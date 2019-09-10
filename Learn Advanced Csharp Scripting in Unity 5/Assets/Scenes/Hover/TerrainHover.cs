using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class TerrainHover : MonoBehaviour
{

    private Transform thisTransform = null;
    public float maxSpeed = 10f;

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

        thisTransform.position = newPos;
    }
}
