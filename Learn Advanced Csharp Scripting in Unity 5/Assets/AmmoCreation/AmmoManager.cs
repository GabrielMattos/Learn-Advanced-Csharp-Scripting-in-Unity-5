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

    private void Start() {
        
        ammoArray = new GameObject[poolSize];

        for(int i = 0; i < poolSize; i++) {
            ammoArray[i] = Instantiate(ammoPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            Transform objTransform = ammoArray[i].GetComponent<Transform>();
            objTransform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
