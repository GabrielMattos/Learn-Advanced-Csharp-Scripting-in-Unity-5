using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Enemy : MonoBehaviour
{

    private UnityEngine.AI.NavMeshAgent thisAgent = null;

    public Transform patrolDestination = null;

    private void Awake() {
        
        thisAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        thisAgent.SetDestination(patrolDestination.position);
    }
}
