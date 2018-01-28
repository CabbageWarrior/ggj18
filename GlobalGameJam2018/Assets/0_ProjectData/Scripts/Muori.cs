using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI.Movement;
public class Muori : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<Agent>().toglidalista();
        //Destroy(collision.gameObject);
        collision.gameObject.SetActive(false);
    }
}
