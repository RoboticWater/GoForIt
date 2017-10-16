using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour {

	public Vector2 posTarg;
	public Vector2 start;

	private bool show = false;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		GetComponent<RectTransform> ().anchoredPosition = Vector2.Lerp (GetComponent<RectTransform> ().anchoredPosition, show ? posTarg : start, 0.05f);
	}

	public void setShow(bool val) {
		show = val;
	}

	public void setText(string t) {
		GetComponent<Text> ().text = t;
	}
}
