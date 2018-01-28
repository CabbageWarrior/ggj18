using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI.Movement;
public class ScoreManager : MonoBehaviour {

    public GameObject[] pippotti;
    public Transform[] spawnspots;
    public Transform sitysenter;
    public Transform defaultNormalTarget;
    public Transform meNeVadoTarget;

    public int penalitaScarsezza;
    public int aumentoDiPunteggio;

    public int score = 0;
    public int[] milestones;
    bool ischecking = false;
    int milestoneReached = 0;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            SpawnNewBellissimPippottino();
        }

        if(milestoneReached < milestones.Length - 1 && score >= milestones[milestoneReached + 1])
        {
            milestoneReached++;
            SpawnNewBellissimPippottino(); SpawnNewBellissimPippottino(); SpawnNewBellissimPippottino(); SpawnNewBellissimPippottino(); SpawnNewBellissimPippottino();

        }
        else if(score < milestones[milestoneReached])
        {
            milestoneReached--;
        } 
    }

    void SpawnNewBellissimPippottino()
    {
        StartCoroutine(SpawnNewBellissimPippottinoCorutine());

    }

    IEnumerator SpawnNewBellissimPippottinoCorutine()
    {
        GameObject pippottinoCultista = Instantiate(pippotti[UnityEngine.Random.Range(0, pippotti.Length)], spawnspots[UnityEngine.Random.Range(0, spawnspots.Length)].position, Quaternion.identity);
        pippottinoCultista.GetComponent<AgentStateMachine>().streetCenter = sitysenter;
        pippottinoCultista.GetComponent<AgentStateMachine>().defaultNormalTarget = defaultNormalTarget;
        pippottinoCultista.GetComponent<AgentStateMachine>().meNeVadoDaStoPostoDiMerda = meNeVadoTarget;
        yield return null;
        pippottinoCultista.GetComponent<AgentStateMachine>().CheckState(State.ATTRACTED);
    

    }

    public void SubtractPoints()
    {
        score -= penalitaScarsezza;
        if (score > 0)
            score = 0;
    }

    public void AddPoint()
    {
        score += aumentoDiPunteggio;
    }
}
