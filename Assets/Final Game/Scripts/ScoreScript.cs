using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {
    public int score;
    [Header("GUI Connections")]
    public Text scoreText;
	// Use this for initialization
	void Start () {
        scoreText.text = "POINTS: " + score;
    }
	
	// Update is called once per frame
	void Update () {

       
    }
    public void AddPoints(int points) {
        score += points;
        scoreText.text = "POINTS: " + score;
    }
}
