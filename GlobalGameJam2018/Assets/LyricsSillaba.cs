using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SillabaState
{
    InAttesa,
    Corretta,
    Sbagliata
}

public class LyricsSillaba : MonoBehaviour
{
    public SillabaState statoSillaba = SillabaState.InAttesa;

    public string correctText = "pi";
    public string wrongText = "-";

    private LyricsManager manager;

    private void Start()
    {
        manager = FindObjectOfType<LyricsManager>();
    }

    public string SetSillabaState(bool isCorrect)
    {
        statoSillaba = isCorrect ? SillabaState.Corretta : SillabaState.Sbagliata;
        return isCorrect ? correctText : wrongText;
    }
}
