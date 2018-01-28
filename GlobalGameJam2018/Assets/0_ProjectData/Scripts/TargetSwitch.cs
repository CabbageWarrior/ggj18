using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI.Movement;

public class TargetSwitch : MonoBehaviour
{
    public Transform otherTarget;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<AgentStateMachine>().currentState == State.NORMAL)
        {
            collision.GetComponent<SeekBehaviour>().targetTransform = otherTarget;
            collision.GetComponent<Agent>().ChangeDirection();

        }

    }

}
