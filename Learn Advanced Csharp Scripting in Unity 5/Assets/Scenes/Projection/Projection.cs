using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projection : MonoBehaviour
{

    public Transform lineStart = null;
    public Transform lineEnd = null;

    void OnDrawGizmos() {

        if(lineStart == null || lineEnd == null) {
            return;
        }

        Gizmos.color = Color.green;
        Gizmos.DrawLine(lineStart.position, lineEnd.position);
    }
}
