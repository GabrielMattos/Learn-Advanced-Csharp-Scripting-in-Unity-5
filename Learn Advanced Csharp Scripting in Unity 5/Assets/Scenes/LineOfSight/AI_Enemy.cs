using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Enemy : MonoBehaviour
{

    public enum ENEMY_STATE {PATROL, CHASE, ATTACK};
    private ENEMY_STATE currentState = ENEMY_STATE.PATROL;
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
