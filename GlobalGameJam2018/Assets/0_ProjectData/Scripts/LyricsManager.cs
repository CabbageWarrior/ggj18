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

    public bool isGameFinished = false;

    // Use this for initialization
    void Start()
    {
        righe = new List<LyricsRiga>(GetComponentsInChildren<LyricsRiga>());
        currentRiga = righe.Find(x => !x.isCompleted);

        previousTextPosition = previousText.transform.position;
    }

    public void SetNextValue(bool isCorrect)
    {
        if (isGameFinished)
        {
            return;
        }

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
                GetComponent<AudioSource>().Stop();
            }
        }
    }

    private IEnumerator MovePreviousText()
    {
        float deltaY = .45f;

        //while (currentTime < startTime + deltaTime)
        while (previousText.transform.position.y < previousTextPosition.y + deltaY)
        {
            previousText.transform.position += new Vector3(0, deltaY * Time.deltaTime / 2, 0);
            yield return null;
        }
        previousText.transform.position = previousTextPosition + new Vector3(0, deltaY, 0);

    }
}
