using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    List<string> lettere = new List<string>(5);
    public int minDelay;
   
    public int maxDelay;
    Random random = new Random();
    float i = 0;
    public int impattoframerate;
    public int timer_cont;
    public GameObject nota;
    string lettera;
    public GameObject[] spawnPoints;
    GameObject new_instance;
    Vector3 offset;
    ScoreManager SM;
    void Start()
    {
        SM = FindObjectOfType<ScoreManager>();
        offset = new Vector3(0F, 0F, 0F);
        lettere.Add("QWASZ");
        lettere.Add("ERDXC");
        lettere.Add("TYFGV");
        lettere.Add("UHJBN");
        lettere.Add("IOPKLM");

    }

    // Update is called once per frame
    void Update()
    {
        if (SM.isPlaying)
        {
          
            i= i + impattoframerate* Time.deltaTime; 
            if (i >= timer_cont)
            {
                bool succes = false;
                while (!succes)
                {
                    int randomSection = (int)Random.Range(0F, 5F);
                    int randomChar = (int)Random.Range(0f, 5f);

                    lettera = lettere[randomSection][randomChar].ToString();
                    //Debug.Log(lettera);
                    if ("QWASZ".Contains(lettera))
                    {
                        succes = SpawnNewLetter(0);
                    }
                    if ("ERDXC".Contains(lettera))
                    {
                        succes = SpawnNewLetter(1);
                    }
                    if ("TYFGV".Contains(lettera))
                    {
                        succes = SpawnNewLetter(2);
                    }
                    if ("UHJBN".Contains(lettera))
                    {
                        succes = SpawnNewLetter(3);
                    }
                    if ("IOPKLM".Contains(lettera))
                    {
                        succes = SpawnNewLetter(4);
                    }
                }
                succes = false;

                i = 0;
            }
        }
    }

    bool SpawnNewLetter(int groupIndex)
    {
        if (spawnPoints[groupIndex].transform.childCount == 0)
        {

            new_instance = Instantiate(nota, spawnPoints[groupIndex].transform);
            new_instance.GetComponentInChildren<TextMesh>().text = lettera;
            return true;

        }
        return false;
    }


}
