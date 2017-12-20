using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour {
    public GameObject ScriptCache;
    public int points = 100;
    [Header("Effects")]
    public AudioClip goalSound;
    private AudioSource SFX;
    private ParticleSystem particles;
    private ScoreScript score;
    private ResetScript reset;
    private bool inGoal;
    // Use this for initialization
    void Start () {
        particles = GetComponent<ParticleSystem>();
        particles.Stop();
        SFX = GetComponent<AudioSource>();
        reset = ScriptCache.GetComponent<ResetScript>();
        score = ScriptCache.GetComponent<ScoreScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            
            if (!inGoal) {
                particles.Play();
                SFX.PlayOneShot(goalSound, .8f); 
                score.AddPoints(points);
                reset.NewRound();
                inGoal = true;
            }
        }
    }
}
