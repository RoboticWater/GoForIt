using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlopeAccelerator : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.Equals (player)) {
			player.GetComponent<Rigidbody> ().AddForce (new Vector3 (0, 0, -100));
			Destroy (this);
		}
	}
}
