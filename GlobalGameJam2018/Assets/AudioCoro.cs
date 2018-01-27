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

    private Animator anim;
    private Coroutine audioSbagliatoCoroutine;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

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
                if (audioSbagliatoCoroutine != null)
                {
                    StopCoroutine(audioSbagliatoCoroutine);
                }
            }

            anim.SetBool("Lettera", true);
            anim.SetBool("Sbaglio", false);
            audioGiusto.Play();
        }
    }

    private void StopCorrectAudio()
    {
        if (audioGiusto.isPlaying)
        {
            anim.SetBool("Lettera", false);
            anim.SetBool("Sbaglio", false);
            audioGiusto.Stop();
        }
    }

    private void StartSfigatedAudio()
    {
        StopCorrectAudio();

        audioSbagliato.clip = audioClips[UnityEngine.Random.Range(0, audioClips.Length)];
        anim.SetBool("Lettera", true);
        anim.SetBool("Sbaglio", true);
        audioSbagliato.Play();

        audioSbagliatoCoroutine = StartCoroutine(ResetAudioSbagliatoAnimation());
    }

    private IEnumerator ResetAudioSbagliatoAnimation()
    {
        while (audioSbagliato.isPlaying)
        {
            yield return null;
        }

        anim.SetBool("Lettera", false);
        anim.SetBool("Sbaglio", false);
    }
}
