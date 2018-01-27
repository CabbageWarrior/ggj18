using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LyricsManager : MonoBehaviour
{
    public TextMesh textToFill;
    public TextMesh previousText;

    private List<LyricsRiga> righe;
    private LyricsRiga currentRiga;

    private Vector3 previousTextPosition;

    private bool isGameFinished = false;

    // Use this for initialization
    void Start()
    {
        righe = new List<LyricsRiga>(GetComponentsInChildren<LyricsRiga>());
        currentRiga = righe.Find(x => !x.isCompleted);

        previousTextPosition = previousText.transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SetNextValue(true);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            SetNextValue(false);
        }
    }

    public void SetNextValue(bool isCorrect)
    {
        if (isGameFinished) return;

        string valueToRender = currentRiga.SetNextValue(isCorrect);

        textToFill.text += valueToRender;

        StartCoroutine(CheckIfRimangonoRighe());
    }
    IEnumerator CheckIfRimangonoRighe()
    {
        yield return null;
        if (currentRiga.isCompleted)
        {
            previousText.transform.position = previousTextPosition;
            previousText.text = textToFill.text;
            textToFill.text = "";

            StartCoroutine(MovePreviousText());

            currentRiga = righe.Find(x => !x.isCompleted);

            if (!currentRiga)
            {
                isGameFinished = true;
            }
        }
    }

    private IEnumerator MovePreviousText()
    {
        float deltaTime = 2f;
        float deltaY = .01f;
        float startTime = Time.time;
        float currentTime = startTime;

        while (currentTime < startTime + deltaTime)
        {
            currentTime += Time.deltaTime;
            previousText.transform.position += new Vector3(0, deltaY, 0);
            yield return null;
        }
        
    }
}
