using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosProject : MonoBehaviour
{

    public Transform target = null;
    public Transform thisTransform = null;

    public Transform lineStart = null;
    public Transform lineEnd = null;

    // Start is called before the first frame update
    void Start()
    {
        thisTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {   
        //calculate normal
        Vector3 normal = (lineEnd.position - lineStart.position).normalized;

        //Update position
        Vector3 pos = lineStart.position + Vector3.Project(target.position - lineStart.position, normal);

        //clamp position between min e max
        pos.x = Mathf.Clamp(pos.x, Mathf.Min(lineStart.position.x, lineEnd.position.x), Mathf.Max(lineStart.position.x, lineEnd.position.x));
        pos.y = Mathf.Clamp(pos.y, Mathf.Min(lineStart.position.y, lineEnd.position.y), Mathf.Max(lineStart.position.y, lineEnd.position.y));
        pos.z = Mathf.Clamp(pos.z, Mathf.Min(lineStart.position.z, lineEnd.position.z), Mathf.Max(lineStart.position.z, lineEnd.position.z));
    
        thisTransform.position = pos;
    }
}
