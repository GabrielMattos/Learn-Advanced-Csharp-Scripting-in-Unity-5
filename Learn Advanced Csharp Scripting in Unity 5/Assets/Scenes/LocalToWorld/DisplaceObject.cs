using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaceObject : MonoBehaviour
{

    public float displaceSpeed = 2f;
    private Transform thisTransform = null;

    [SerializeField]
    private Vector3 localForward;
    [SerializeField]
    private Vector3 transformForward;

    // Start is called before the first frame update
    void Start()
    {
        thisTransform = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        localForward = Vector3.forward;
        transformForward = thisTransform.forward;

        //thisTransform.position += thisTransform.forward * displaceSpeed * Time.deltaTime;
        
        //1 way
        //Vector3 localSpaceDisplacement = Vector3.forward * displaceSpeed * Time.deltaTime;
        //Vector3 worldSpaceDisplacement = thisTransform.TransformDirection(localSpaceDisplacement);
        //thisTransform.position += worldSpaceDisplacement;

        //2 way
        Vector3 localSpaceDisplacement = Vector3.forward * displaceSpeed * Time.deltaTime;
        Vector3 worldSpaceDisplacement = thisTransform.rotation * localSpaceDisplacement;
        thisTransform.position += worldSpaceDisplacement;

    }
}
