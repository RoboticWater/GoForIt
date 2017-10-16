using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBucket : MonoBehaviour {

	public GameObject player;
	public Color color;
	public int colorVal;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.Equals (player)) {
			player.GetComponent<Renderer> ().material.color = color;
			player.GetComponent<Player> ().setColorVal (colorVal);
		}
	}
}