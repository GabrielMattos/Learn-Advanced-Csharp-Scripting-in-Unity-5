using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Enemy : MonoBehaviour
{

    public enum ENEMY_STATE {PATROL, CHASE, ATTACK};
    private ENEMY_STATE currentState = ENEMY_STATE.PATROL;
    private UnityEngine.AI.NavMeshAgent thisAgent = null;
    public Transform patrolDestination = null;

    public ENEMY_STATE CurrentState {

        get { 
            return currentState;
        }

        set {
            currentState = value;
            StopAllCoroutines();
            switch (currentState) {

                case ENEMY_STATE.PATROL:
                    StartCoroutine(AIPatrol());
                break;

                case ENEMY_STATE.CHASE:
                    StartCoroutine(AIChase());
                break;

                case ENEMY_STATE.ATTACK:
                    StartCoroutine(AIAttack());
                break;
            }
        }
    }


    public IEnumerator AIPatrol() {

        while(currentState == ENEMY_STATE.PATROL) {
            yield return null;
        }
    }

    
    public IEnumerator AIChase() {

        while(currentState == ENEMY_STATE.CHASE) {
            yield return null;
        }
        
    }


    
    public IEnumerator AIAttack() {

        while(currentState == ENEMY_STATE.ATTACK) {
            yield return null;
        }
    }

    private void Awake() {
        
        thisAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        thisAgent.SetDestination(patrolDestination.position);
    }
}
