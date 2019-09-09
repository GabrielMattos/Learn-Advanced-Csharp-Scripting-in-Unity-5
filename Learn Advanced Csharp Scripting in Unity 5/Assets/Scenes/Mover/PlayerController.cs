using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{

    public float maxSpeed = 10f;
    public float rotSpeed = 5f;
    private Transform thisTranform = null;

    // Start is called before the first frame update
    void Start()
    {
        thisTranform = this.gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float horz = CrossPlatformInputManager.GetAxis("Horizontal");
        float vert = CrossPlatformInputManager.GetAxis("Vertical");

        thisTranform.rotation *= Quaternion.Euler(0f, rotSpeed * horz * Time.deltaTime, 0f);

        thisTranform.position += thisTranform.forward * maxSpeed * vert * Time.deltaTime;
    }
}
