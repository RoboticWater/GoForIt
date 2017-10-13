using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

	public Vector2 posTarg = new Vector2(0, 40);

	private float startTime;
	private bool run = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<RectTransform> ().anchoredPosition = Vector2.Lerp (GetComponent<RectTransform> ().anchoredPosition, posTarg, 0.05f);
		if (run) {
			float t = Time.time - startTime;
			string min = ((int) t / 60).ToString ();
			string sec = (t % 60).ToString ("F2");
			GetComponent<Text> ().text = min + ":" + sec;
		}
	}

	public void startTimer () {
		startTime = Time.time;
		posTarg = new Vector2 (0, -35);
		run = true;
	}
}
