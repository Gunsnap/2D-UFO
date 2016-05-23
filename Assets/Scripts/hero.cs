using UnityEngine;
using System.Collections;

public class hero : MonoBehaviour {

	static int SekTidGemt;

	private Rigidbody rb;
	Animator am;
	private Spawner sp;

	//Move
	public float heroSpeed = 1f;
	private Vector3 movement;
	private bool Run;

	//Bomb
	public bool PutBomb;
	public float BombRate = 0.5f;
	private bool AllowBomb;
	private float nextBomb = 0.0f;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		am = GetComponent<Animator> ();
		sp = gameObject.GetComponent<Spawner> ();
		SekTidGemt = 5;
	}

	void Update () {

		float Tid = Time.fixedTime;
		int SekTid = (int)Tid;

		// Movement
		float movementHorisontal = -Input.GetAxis ("Horizontal");
		float movementVertical = Input.GetAxis ("Vertical");
		movement = new Vector3 (movementVertical * heroSpeed, 0F, movementHorisontal * heroSpeed);

		if (movement != Vector3.zero) {
			Run = true;
			rb.AddForce (movement, ForceMode.Acceleration);
		} else {
			Run = false;
			rb.velocity = Vector3.zero;
		}

		var PlayerObject = GameObject.Find ("Player1");
		Vector3 PlayerPos = PlayerObject.transform.position;
		Debug.Log (PlayerPos);

		// Bomb
		if (SekTidGemt < SekTid) {
			AllowBomb = true;
			SekTidGemt = SekTid;
		} else {
			//AllowBomb = false;
		}

		if (AllowBomb) {
			if (Input.GetKeyDown (KeyCode.Space) && Tid > nextBomb) {
				nextBomb = Tid + BombRate;
				PutBomb = true;
				sp.SpawnSomethingAwesome (PlayerPos);
				AllowBomb = false;
			} else {
				// Der er ikke trykket
				PutBomb = false;
				Debug.Log ("Der må smides - Men der er ikke trykket");
			}
		} else {
			//PutBomb = false;
			Debug.Log ("Du må IKKE smide en bombe");
		}

		// Rotate
		if (movement != Vector3.zero) {
			string moveStr = movement.x + "," + movement.y + "," + movement.z;

			switch (moveStr) {
			case "0,0,1"://Venstre
				rb.MoveRotation (Quaternion.Euler (0f, 0f, 0f));
				break;
			case "1,0,0"://op
				rb.MoveRotation (Quaternion.Euler (0f, 90f, 0f));
				break;
			case "0,0,-1"://Højre
				rb.MoveRotation (Quaternion.Euler (0f, 180f, 0f));
				break;
			case "-1,0,0"://ned
				rb.MoveRotation (Quaternion.Euler (0f, 270f, 0f));
				break;
			default:
				//FIXME sæt rotation som en kombi af ovenstående
				break;
			}
		}

	}
	// Lukker update
	
	// FixedUpdate is called once per frame
	void FixedUpdate () {
		am.SetBool ("Run", Run);
		am.SetBool ("PutBomb", PutBomb);
	}
	// Lukker FixedUpdate
}
// Lukker class