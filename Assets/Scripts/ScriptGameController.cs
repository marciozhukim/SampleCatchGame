using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScriptGameController : MonoBehaviour {

	private float maxWitdh;
	public Camera cam;
	public GameObject ball;
	public float timeLeft;
	public Text timerText;
	public GameObject gameOverText;
	public GameObject restartButton;

	// Use this for initialization
	void Start () 
	{
		if (cam == null) {
			cam = Camera.main;
		}
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWitdh = cam.ScreenToWorldPoint (upperCorner);
		float ballWidth = ball.GetComponent<Renderer>().bounds.extents.x;
		maxWitdh = targetWitdh.x - ballWidth;

		StartCoroutine (Spawn());
		UpdateText ();

	}
	void FixedUpdate(){
		timeLeft -= Time.deltaTime;
		UpdateText ();
	}
	IEnumerator Spawn (){

		yield return new WaitForSeconds (2.0f);

		while (timeLeft > 0) {
			Vector3 spawnPosition = new Vector3 (
			Random.Range (-maxWitdh, maxWitdh),
			transform.position.y,
			0.0f
			);
			Instantiate (ball, spawnPosition, Quaternion.identity);

			yield return new WaitForSeconds(Random.Range(1.0f, 2.0f));
		}
		yield return new WaitForSeconds (2.0f);
		gameOverText.SetActive(true);
		yield return new WaitForSeconds (2.0f);
		restartButton.SetActive(true);
	}

	void UpdateText(){
		if( timeLeft >= 0)
			timerText.text = "Time Left:" + Mathf.RoundToInt (timeLeft);
	}
}
