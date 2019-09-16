using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Enemy : MonoBehaviour
{
    public enum ENEMY_STATE {PATROL, CHASE, ATTACK};
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

    public ENEMY_STATE currentState = ENEMY_STATE.PATROL;

    private LineSight thisLineSight = null;
    public UnityEngine.AI.NavMeshAgent thisAgent = null;

    private Transform thisTransform = null;

    public Health playerHealth = null;

    private Transform playerTranform = null;
    public Transform patrolDestination = null;
    public float maxDamage = 100f;

    private void Awake() {
        
        thisLineSight = GetComponent<LineSight>();
        thisAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        thisTransform = GetComponent<Transform>();
        playerTranform = playerHealth.GetComponent<Transform>();
    }

    private void Start() {
        
        CurrentState = ENEMY_STATE.PATROL;
    }

    public IEnumerator AIPatrol() {

        while(currentState == ENEMY_STATE.PATROL) {

            thisLineSight.sensitity = LineSight.sightSensitivity.STRICT;

            thisAgent.Resume();
            thisAgent.SetDestination(patrolDestination.position);

            while(thisAgent.pathPending)
                yield return null;

            if(thisLineSight.canSeeTarget) {
                thisAgent.Stop();
                CurrentState = ENEMY_STATE.CHASE;
                yield break;
            }

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

    // Update is called once per frame
    void Update()
    {
        thisAgent.SetDestination(patrolDestination.position);
    }
}
