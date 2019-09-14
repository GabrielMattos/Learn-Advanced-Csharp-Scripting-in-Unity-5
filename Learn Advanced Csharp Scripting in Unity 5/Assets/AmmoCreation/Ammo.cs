using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{

    public float lifeTime = 2f;

    private void OnEnable() {
        
        Invoke("Die", lifeTime);
    }

    void Die() {

        CancelInvoke();
        gameObject.SetActive(false);
    }
}
