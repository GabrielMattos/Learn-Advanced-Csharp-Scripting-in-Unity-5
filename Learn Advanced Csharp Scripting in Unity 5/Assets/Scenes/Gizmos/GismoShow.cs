using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GismoShow : MonoBehaviour
{

    public bool showGizmos = true;

    public string myIcon = string.Empty;

    [Range(0f, 100f)]
    public float range = 10f;

    void OnDrawGizmos() {
        
        if(!showGizmos) {
            return;
        }

        Gizmos.DrawIcon(transform.position, myIcon, true);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * range);


    }
}
