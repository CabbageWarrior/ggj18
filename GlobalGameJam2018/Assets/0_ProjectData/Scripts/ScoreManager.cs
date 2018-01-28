using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI.Movement;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{

    public GameObject[] pippotti;
    public Transform[] spawnspots;
    public Transform sitysenter;
    public Transform defaultNormalTarget;
    public Transform meNeVadoTarget;

    public int maxPippottiniScazzati = 2;
    public int penalitaScarsezza;
    public int aumentoDiPunteggio;

    public bool isPlaying = true;

    public int score = 0;
    int minimoPunteggioVittoria = 0;
    public int[] milestones;
    int milestoneReached = 0;

    private LyricsSillaba[] sillabeattive;

    LyricsManager LM;

    private void Start()
    {
        LM = FindObjectOfType<LyricsManager>();
        sillabeattive = FindObjectsOfType<LyricsSillaba>();
        minimoPunteggioVittoria = sillabeattive.Length * aumentoDiPunteggio;
        Debug.Log(sillabeattive.Length.ToString() + " sillabe: max " + minimoPunteggioVittoria.ToString() + " punti.");
    }

    private void Update()
    {

        if (isPlaying)
        {
           
            if (milestoneReached < milestones.Length - 1 && score >= milestones[milestoneReached + 1])
            {
                milestoneReached++;
                SpawnNewBellissimPippottino(); SpawnNewBellissimPippottino(); SpawnNewBellissimPippottino(); SpawnNewBellissimPippottino(); SpawnNewBellissimPippottino();

            }
            else if (score < milestones[milestoneReached])
            {
                milestoneReached--;

                Scazzo();

            }
        }

        if (LM.isGameFinished)
        {

            if (score >= milestones[milestones.Length - 1])
            {
                isPlaying = false;
                SceneManager.LoadScene("Outro", LoadSceneMode.Additive);
            }
            else if (score > minimoPunteggioVittoria && score < milestones[milestones.Length - 1])
            {
                isPlaying = false;
                SceneManager.LoadScene("OutroMeh", LoadSceneMode.Additive);
            }
            else
            {
                isPlaying = false;
                SceneManager.LoadScene("OutroSega", LoadSceneMode.Additive);
            }

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
        pippottinoCultista.GetComponent<Agent>().updateList();
        yield return null;
        pippottinoCultista.GetComponent<AgentStateMachine>().CheckState(State.ATTRACTED);


    }

    public void SubtractPoints()
    {
        score -= penalitaScarsezza;
        if (score < 0)
            score = 0;
    }

    public void AddPoint()
    {
        score += aumentoDiPunteggio;
    }

    void Scazzo()
    {
        List<AgentStateMachine> pippottini = new List<AgentStateMachine>(FindObjectsOfType<AgentStateMachine>()).FindAll(x => x.currentState == State.POGGING);

        for (int i = 0; i < pippottini.Count && i < maxPippottiniScazzati; i++)
        {
            pippottini[i].CheckState(State.SCAZZED);
        }
    }
}
