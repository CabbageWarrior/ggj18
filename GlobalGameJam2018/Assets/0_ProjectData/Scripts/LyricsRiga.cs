using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LyricsRiga : MonoBehaviour
{
    private List<LyricsSillaba> sillabe;

    public bool isCompleted = false;

    private LyricsManager manager;

    private void Start()
    {
        manager = FindObjectOfType<LyricsManager>();
        sillabe = new List<LyricsSillaba>(GetComponentsInChildren<LyricsSillaba>());
    }

    public string SetNextValue(bool isCorrect)
    {
        LyricsSillaba sillabaToSet = sillabe.Find(x => x.statoSillaba == SillabaState.InAttesa);
        string valueToRender = sillabaToSet.SetSillabaState(isCorrect);

        StartCoroutine(CheckIfRimangonoSillabe());
        return valueToRender;
    }
    IEnumerator CheckIfRimangonoSillabe()
    {
        yield return null;
        if (!sillabe.Find(x => x.statoSillaba == SillabaState.InAttesa))
        {
            isCompleted = true;
        }
    }
}
