using UnityEngine;
using System.Collections;

public class hero : MonoBehaviour {

	public float heroSpeed = 1f;

	public bool Run;
	public bool PutBomb;
	public float BombRate = 0.5f;

	private Vector3 movement;
	private float nextBomb = 0.0f;


	private Rigidbody rb;
	Animator am;

	void Start(){
		rb = GetComponent<Rigidbody> ();
		am = GetComponent<Animator> ();
	}

	void Update(){

		float Tid = Time.fixedTime;

		float movementHorisontal = -Input.GetAxis ("Horizontal");
		float movementVertical = Input.GetAxis ("Vertical");

		movement = new Vector3 (movementVertical * heroSpeed, 0F, movementHorisontal * heroSpeed);

		if (Input.GetKey(KeyCode.Space) && Time.time > nextBomb) {
			nextBomb = Time.time + BombRate;
			//GameObject clone = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
			Debug.Log("Space trykkes");
			PutBomb = true;
		}

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		// Movement
		if (movement != Vector3.zero) {
			Run = true;
			rb.AddForce (movement, ForceMode.Acceleration);
		} else {
			Run = false;
			rb.velocity = Vector3.zero;
		}

		am.SetBool ("Run", Run);
		am.SetBool ("PutBomb", PutBomb);
	}
}