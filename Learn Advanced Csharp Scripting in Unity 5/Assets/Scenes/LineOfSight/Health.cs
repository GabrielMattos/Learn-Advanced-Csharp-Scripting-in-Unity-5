using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public float HealthPoints {

        get { return healthPoints;}

        set {

            healthPoints = value;

            if(HealthPoints <= 0)
                Destroy(gameObject);
        }
    }

    public float healthPoints = 100f;
}
