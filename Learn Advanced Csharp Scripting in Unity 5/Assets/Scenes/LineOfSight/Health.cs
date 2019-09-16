using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public float HealthPoints {

        get { return healthPoints;}

        set {

            heathPoints = value;

            if(HealthPoints <= 0)
                Destroy(gameObject);
        }
    }

    [Serializefield]
    private float healthPoints = 100f;
}
