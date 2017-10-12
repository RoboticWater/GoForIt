﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed = 3.0f;
	public float maxSpeed = 10.0f;
	public float lookSpeed = 3.0f;

	private Rigidbody rb;
	private GameObject cam;
	private GameObject rig;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		cam = GameObject.Find ("Player Camera");
		rig = GameObject.Find ("Player Camera Rig");

		cam.transform.LookAt (transform.position);
	}

	// Update is called once per frame
	void Update () {

		Vector3 move = new Vector3 (Input.GetAxis ("Vertical"), 0, -Input.GetAxis ("Horizontal"));
		Quaternion rot = Quaternion.LookRotation (transform.position - cam.transform.position);
		rot.x = 0;
		rot.z = 0;
		move = rot * Quaternion.Euler(0, -90, 0) * move;
		move.Normalize();
		move *= Time.fixedDeltaTime * speed;
		rb.AddForce (move);

		if(rb.velocity.magnitude > maxSpeed){
			rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
		}

		rig.transform.Rotate(new Vector3(0, Input.GetAxis ("Mouse X") * lookSpeed * Time.fixedDeltaTime, 0));
		rig.transform.position = transform.position;
	}
}
