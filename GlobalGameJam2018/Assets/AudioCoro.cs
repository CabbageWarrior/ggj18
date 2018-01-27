using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCoro : MonoBehaviour
{
    public AudioSource audioGiusto;
    public AudioSource audioSbagliato;

    public AudioClip[] audioClips;

    public KeyCode[] triggerButtons;

    [Space]
    public bool canPressNow = false;

    private bool correctButtonPressed;

    // Update is called once per frame
    void Update()
    {
        foreach (KeyCode keyCode in triggerButtons)
        {
            if (Input.GetKeyDown(keyCode))
            {
                if (canPressNow)
                {
                    StartCorrectAudio();
                }
                else
                {
                    StartSfigatedAudio();
                }
            }

            if (Input.GetKeyUp(keyCode))
            {
                StopCorrectAudio();
            }
        }


    }

    private void StartCorrectAudio()
    {
        if (!audioGiusto.isPlaying)
        {
            if (audioSbagliato.isPlaying)
            {
                audioSbagliato.Stop();
            }

            audioGiusto.Play();
        }
    }

    private void StopCorrectAudio()
    {
        if (audioGiusto.isPlaying)
        {
            audioGiusto.Stop();
        }
    }

    private void StartSfigatedAudio()
    {
        if (true)// (!audioSbagliato.isPlaying)
        {
            StopCorrectAudio();

            audioSbagliato.clip = audioClips[UnityEngine.Random.Range(0, audioClips.Length)];
            audioSbagliato.Play();
        }
    }
}
