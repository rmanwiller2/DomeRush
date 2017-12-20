using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScore : MonoBehaviour {
    public int points;
    public GameObject bling;
    public AudioSource SFX;

    void Start()
    {
        SFX = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Ball"))
        {
            print("Goal!");
            print("You scored " + points + " points");

            SFX.Play();
            Instantiate(bling, transform);

            gameObject.GetComponent<Renderer>().enabled = false;
            Destroy(gameObject, .3f);

        }
    }
}

