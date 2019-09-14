using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSight : MonoBehaviour
{
    private void OnTriggerStay(Collider target) {
        
        print(target.name);
    }
}
