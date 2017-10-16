using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roller : MonoBehaviour {

	public Vector3 start;
	public Vector3 end;
	public float speed;
	public float rollSpeed;

	private float move;
	private bool dir;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		move = Mathf.Sin(Time.time * speed) / 2 + 0.5f;
		transform.position = Vector3.Lerp (start, end, move);
		transform.Rotate (new Vector3(0,rollSpeed * Time.fixedDeltaTime, 0));
	}
}
