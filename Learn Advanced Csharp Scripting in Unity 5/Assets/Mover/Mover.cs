using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float maxSpeed = 1f;
    private Transform thisTranform = null;

    void Awake() {

        thisTranform = this.gameObject.GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        thisTranform.position += thisTranform.forward * (maxSpeed * Time.deltaTime);
    }
}
