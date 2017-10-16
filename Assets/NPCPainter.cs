using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPainter : MonoBehaviour {

	public GameObject player;
	public GameObject dialog;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.Equals (player)) {
			Dialog d = dialog.GetComponent<Dialog> ();
			d.setShow (true);
			d.setText ("Painting!");

		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.Equals (player)) {
			dialog.GetComponent<Dialog> ().setShow (false);
		}
	}
}
