using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{   
    public GameObject ammoPrefab = null;

    public int poolSize = 100;

    private GameObject[] ammoArray;

    public static AmmoManager ammoManagerSingleton = null;

    private void Awake() {
        
        if(ammoManagerSingleton != null) {
            Destroy(this.gameObject);
            return;
        }

        ammoManagerSingleton = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
