using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI.Movement;

public class AgentStateMachine : MonoBehaviour
{
    public enum State { NORMAL, ATTRACTED, POGGING, SCAZZED}

    public State currentState;

    public Transform streetCenter;
   

    public Transform defaultNormalTarget;



    
    Agent myAgent;


    private void Start()
    {
        currentState = 0;
        myAgent = GetComponent<Agent>();
       
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CheckState(State.NORMAL);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CheckState(State.ATTRACTED);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CheckState(State.POGGING);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            CheckState(State.SCAZZED);
        }
    }

    void CheckState(State newState)
    {
        if (newState == 0 && currentState != State.NORMAL)
        {
            currentState = State.NORMAL;
            myAgent.seek.targetTransform = defaultNormalTarget;
        }
        else if ((int)newState == 1 && currentState != State.ATTRACTED)
        {
            currentState = State.ATTRACTED;
            myAgent.seek.targetTransform = streetCenter;

        }
        else if((int)newState == 2 && currentState != State.POGGING)
        {
            currentState = State.POGGING;
        }
        else if ((int)newState == 3 && currentState != State.SCAZZED)
        {
            currentState = State.SCAZZED;

        }

    }


}
