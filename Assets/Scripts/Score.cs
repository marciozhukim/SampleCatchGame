using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Text scoreText;
	public int ballValue;

	private int score;
	// Use this for initialization
	void Start () {
		score = 0;
		UpdateScore ();
	}

	void OnTriggerEnter2D ()
	{
		score += ballValue;
		UpdateScore ();
	}

	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}
}
