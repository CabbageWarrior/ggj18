using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI.Movement;

public class attractTrigger : MonoBehaviour {

    public Transform coro;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((int)collision.GetComponent<AgentStateMachine>().currentState == 1)
        {
            collision.GetComponent<SeekBehaviour>().targetTransform = coro;
            collision.GetComponent<Agent>().myAnimator.SetBool("Attracted", true);
            collision.GetComponent<Agent>().ChangeDirection();
        }
        if((int)collision.GetComponent<AgentStateMachine>().currentState == 3)
        {
            collision.GetComponent<AgentStateMachine>().currentState = State.NORMAL;
            collision.GetComponent<Agent>().seek.targetTransform = collision.GetComponent<AgentStateMachine>().defaultNormalTarget;
            collision.GetComponent<Agent>().ChangeDirection();


        }
    }

}
