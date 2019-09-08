using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTo : MonoBehaviour
{

    private Transform thisTransform;
    public float rotSpeed = 90f;

    public Transform target = null;

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
        thisTransform.rotation = Quaternion.LookRotation(target.position - thisTransform.position, Vector3.up);
    }
}
