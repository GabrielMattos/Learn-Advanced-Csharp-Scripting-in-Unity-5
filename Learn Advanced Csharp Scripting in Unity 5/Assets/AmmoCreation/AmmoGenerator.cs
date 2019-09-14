using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoGenerator : MonoBehaviour
{

    //public GameObject ammoPrefab = null;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) {
            AmmoManager.SpawnAmmo(transform.position, transform.rotation);
            //Instantiate(ammoPrefab, transform.position, transform.rotation);
        }
    }
}
