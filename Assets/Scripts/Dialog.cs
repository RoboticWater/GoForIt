using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour {

	public GameObject timer;
	public Vector2 posTarg;

	// Use this for initialization
	void Start () {
		GameTimer gt = timer.GetComponent<GameTimer> ();
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<RectTransform> ().anchoredPosition = Vector2.Lerp (GetComponent<RectTransform> ().anchoredPosition, posTarg, 0.05f);
		if (Input.GetMouseButtonDown (0)) {
			GameTimer gt = timer.GetComponent<GameTimer> ();
			gt.startTimer ();
		}
	}
}
