using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{   
    public GameObject ammoPrefab = null;

    public int poolSize = 100;

    private GameObject[] ammoArray;

    public static AmmoManager ammoManagerSingleton = null;

    public Queue<Transform> ammoQueue = new Queue<Transform>;

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
            ammoQueue.Enqueue(objTransform);
            ammoArray[i].SetActive(false);
        }
    }

    public static Transform SpawnAmmo(Vector3 position, Quaternion rotation) {


    }
}
