using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public bool pressing;
    public GameObject input_timer;
    public GameObject tokillachild;
    public float velocitaScomparitoria = 0.008f;

    float opacità_nota = 1f;
    float x = 1f;

    string lettera;

    Transform nota_transform;
    Transform timer_transform;
    SpriteRenderer sprite_nota;
    SpriteRenderer sprite_timer;
    GameObject timer;
    Animator animation_reference;
    ScoreManager StoVincendo;
    
    TextMesh text;

    LyricsManager lyricsManager;

    public string Lettera
    {
        get
        {
            return lettera;
        }
    }

    void Start()
    {

        pressing = false;

        lettera = gameObject.GetComponentInChildren<TextMesh>().text;
        animation_reference = GetComponent<Animator>();

        lyricsManager = FindObjectOfType<LyricsManager>();
        StoVincendo = FindObjectOfType<ScoreManager>();
    }

    void Update()
    {
        if (!Input.GetKey(lettera.ToLower()))
        {
            sprite_nota = gameObject.GetComponent<SpriteRenderer>();
            sprite_nota.color = new Color(1f, 1f, 1f, opacità_nota);
            opacità_nota = opacità_nota - velocitaScomparitoria;

            if (opacità_nota <= 0F)
            {
                CallWrongButtonReleaseState();
                Destroy(gameObject.gameObject);
            }
        }
        else
        {

            if (sprite_nota)
            {
                opacità_nota = 1f;
                sprite_nota.color = new Color(1f, 1f, 1f, opacità_nota);
                pressing = true;

                animation_reference.SetBool("isPressed", true);
            }

        }
        if (Input.GetKeyUp(lettera.ToLower()))
        {
            if (animation_reference.GetCurrentAnimatorStateInfo(0).IsName("orange_state"))
            {
                // Più punteggio!!!
                StoVincendo.AddPoint();
                lyricsManager.SetNextValue(true);
            }
            else if (animation_reference.GetCurrentAnimatorStateInfo(0).IsName("green_state"))
            {
                CallWrongButtonReleaseState();
            }

            Destroy(gameObject);
            pressing = false;
        }
    }

    public void CallWrongButtonReleaseState()
    {
        KeyCode tastoGiusto = (KeyCode)System.Enum.Parse(typeof(KeyCode), lettera);

        AudioCoro pippottinoCoro = new List<AudioCoro>(FindObjectsOfType<AudioCoro>()).Find(x => new List<KeyCode>(x.triggerButtons).Contains(tastoGiusto));
        StoVincendo.SubtractPoints();
        lyricsManager.SetNextValue(false);
        pippottinoCoro.StartSfigatedAudio();

    }
}
