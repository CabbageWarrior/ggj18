using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poga : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<AgentStateMachine>().currentState == State.ATTRACTED)
        {
            collision.GetComponent<AgentStateMachine>().CheckState(State.POGGING);
        }
    }
}
