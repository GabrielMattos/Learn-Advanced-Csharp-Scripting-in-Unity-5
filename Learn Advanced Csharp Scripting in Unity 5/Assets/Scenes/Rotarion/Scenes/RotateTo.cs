using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTo : MonoBehaviour
{

    private Transform thisTransform;
    public float rotSpeed = 90f;

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
        //thisTransform.rotation = Quaternion.Euler(0f, 90f, 0f);
        
        thisTransform.rotation *= Quaternion.AngleAxis(rotSpeed * Time.deltaTime, Vector3.up);
    }
}
