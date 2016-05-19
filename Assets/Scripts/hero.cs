using UnityEngine;
using System.Collections;

public class hero : MonoBehaviour {

	public float heroSpeed = 1f;
	public bool Run;
	private Vector3 movement;

	private Rigidbody rb;
	Animator am;

	void Start(){
		rb = GetComponent<Rigidbody> ();
		am = GetComponent<Animator> ();
	}

	void Update(){
		float movementHorisontal = -Input.GetAxis ("Horizontal");
		float movementVertical = Input.GetAxis ("Vertical");

		movement = new Vector3 (movementVertical * heroSpeed, 0F, movementHorisontal * heroSpeed);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (movement != Vector3.zero) {
			Run = true;
			rb.AddForce (movement, ForceMode.Acceleration);
		} else {
			Run = false;
			rb.velocity = Vector3.zero;
		}

		am.SetBool ("Run", Run);
	}
}