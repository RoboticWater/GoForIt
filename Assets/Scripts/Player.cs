using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed = 3.0f;
	public float maxSpeed = 10.0f;
	public float lookSpeed = 3.0f;
	public float jumpMult = 2.0f;
	public GameObject[] splotchTypes = new GameObject[4];
	public int colorTickVal = 60;

	private float camVal;

	private Rigidbody rb;
	private GameObject cam;
	private GameObject rig;
	private bool jumping = false;
	private int colorVal = -1;
	private GameObject[] splotches = new GameObject[1000];
	private int arrayTicker = 0;
	private int colorTicker;
	private Quaternion splotchRot;
	private Collision currentOn;

	private Vector3 dropPos = new Vector3(1000,1000,1000);

	// Use this for initialization
	void Start () {
		colorTicker = colorTickVal;
		rb = GetComponent<Rigidbody> ();
		cam = GameObject.Find ("Player Camera");
		rig = GameObject.Find ("Player Camera Rig");

		//cam.transform.LookAt (transform.position);
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
		if (Input.GetKey ("space") && !jumping) {
			move.y = speed * jumpMult;
			jumping = true;
		}
		rb.AddForce (move);
		//print (move);
		//Debug.Log (rb.velocity);
		//if(rb.velocity.magnitude > maxSpeed){
		//	rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
		//}

		//Vector3 vect = new Vector3 (0, 0.98f, -0.519f);
		//camVal += Input.GetAxis ("Mouse Y") * -200 * Time.fixedDeltaTime;
		//vect = Quaternion.Euler (camVal, 0, 0) * vect;
		//cam.transform.localPosition = vect;
		//cam.transform.LookAt (transform.position);

		rig.transform.Rotate(0, Input.GetAxis ("Mouse X") * lookSpeed * Time.fixedDeltaTime, 0);
		rig.transform.position = transform.position;

		if (colorVal >= 0 && !jumping && Vector3.Distance(transform.position, dropPos) > 0.5f && colorTicker > 0) {
			dropPos = transform.position;
			splotches[arrayTicker] = GameObject.Instantiate(splotchTypes[colorVal]);
			splotches[arrayTicker].transform.position = transform.position;
			splotches[arrayTicker].transform.rotation = splotchRot;
			Vector3 newPos = splotches [arrayTicker].transform.position;
			newPos [1] -= 0.094f;
			splotches [arrayTicker].transform.position = newPos;
			arrayTicker = (arrayTicker++) % splotches.Length;
			colorTicker--;
		}
	}

	void OnCollisionEnter(Collision other) {
		jumping = false;
		splotchRot = Quaternion.LookRotation (other.contacts [0].normal);
		splotchRot *= Quaternion.Euler(90,0,0);
		currentOn = other;
	}

	void OnCollisionStay(Collision other) {
		if (!other.Equals (currentOn)) {
			splotchRot = Quaternion.LookRotation (other.contacts [0].normal);
			splotchRot *= Quaternion.Euler(90,0,0);
			currentOn = other;
		}
	}

	public void setColorVal(int val) {
		colorVal = val;
		colorTicker = colorTickVal;
	}
}
