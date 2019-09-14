using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorFace : MonoBehaviour
{
    private Transform thisTranform = null;

    private void Awake() {
        
        thisTranform = GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));

        mousePosWorld = new Vector3(mousePosWorld.x, thisTranform.position.y, mousePosWorld.z);

        Vector3 lookDirection = mousePosWorld - thisTranform.position;

        thisTranform.localRotation = Quaternion.LookRotation(lookDirection.normalized, Vector3.up);
    }
}
