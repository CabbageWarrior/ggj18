using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI.Movement;

public enum State { NORMAL, ATTRACTED, POGGING, SCAZZED }

public class AgentStateMachine : MonoBehaviour
{

    public State currentState;

    public Transform streetCenter;
    public Transform defaultNormalTarget;
    public Transform meNeVadoDaStoPostoDiMerda;
   

    private float defaultSeek;
    private float defaultCohesion;
    private float defaultSeparation;

    public float SeekAmmount;
    public float CohesionAmmount;
    public float SeparationAmmount;


    Agent myAgent;


    private void Start()
    {
        currentState = 0;
        myAgent = GetComponent<Agent>();
        defaultSeek = myAgent.seek.weight;
        defaultCohesion = myAgent.cohesion.weight;
        defaultSeparation = myAgent.separation.weight;
       
    }

    private void Update()
    {
       
    }

    public void CheckState(State newState)
    {
        if (newState == 0 && currentState != State.NORMAL)
        {
            currentState = State.NORMAL;
            myAgent.myAnimator.SetBool("Attracted", false);
            myAgent.myAnimator.SetBool("Pogo", false);
            myAgent.myAnimator.SetBool("Scazzata", false);
            myAgent.ChangeDirection();
            myAgent.maximumLinearVelocity = myAgent.defaultLinearVelocity;
            myAgent.seek.weight = defaultSeek;
            myAgent.cohesion.weight = defaultCohesion;
            myAgent.separation.weight = defaultSeparation;

        }
        else if ((int)newState == 1 && currentState != State.ATTRACTED)
        {
            currentState = State.ATTRACTED;
            myAgent.myAnimator.SetBool("Attracted", false);
            myAgent.myAnimator.SetBool("Pogo", false);
            myAgent.myAnimator.SetBool("Scazzata", false);
            myAgent.seek.targetTransform = streetCenter;
            myAgent.ChangeDirection();
            myAgent.maximumLinearVelocity = myAgent.maximumLinearVelocityAttracted;
            

        }
        else if((int)newState == 2 && currentState != State.POGGING)
        {
            currentState = State.POGGING;
            myAgent.myAnimator.SetBool("Attracted", true);
            myAgent.myAnimator.SetBool("Pogo", true);
            myAgent.myAnimator.SetBool("Scazzata", false);
            myAgent.maximumLinearVelocity = 0.1f;
            myAgent.seek.weight = SeekAmmount;
            myAgent.cohesion.weight = CohesionAmmount;
            myAgent.separation.weight = SeparationAmmount;
        }
        else if ((int)newState == 3 && currentState != State.SCAZZED)
        {
            currentState = State.SCAZZED;
            myAgent.myAnimator.SetBool("Attracted", true);
            myAgent.myAnimator.SetBool("Pogo", true);
            myAgent.myAnimator.SetBool("Scazzata", true);
            myAgent.seek.targetTransform = streetCenter;
            myAgent.ChangeDirection();
            myAgent.maximumLinearVelocity = myAgent.defaultLinearVelocity;
            myAgent.seek.weight = defaultSeek;
            myAgent.cohesion.weight = defaultCohesion;
            myAgent.separation.weight = defaultSeparation;


        }

    }


}
