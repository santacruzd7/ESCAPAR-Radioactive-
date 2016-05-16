using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public int score = 0;
	public Text scoreText;

	private int incScore = 10;
	private int extra = 250;
	private int decScore = 5;
	
	// Use this for initialization
	void Start () {
		displayScore ();
	}
	
	// Update is called once per frame
	void Update () {
		displayScore ();
	}

	void displayScore(){
		scoreText.text = "SCORE: " + score + " pts";
	}

	public void increment(){
		score += incScore;
	}

	public void extraPoints(){
		score += extra;
	}

	public void decrement(){
		score -= decScore;
		if (score < 0) {
			score = 0;
		}
	}
}
