using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualBelt : MonoBehaviour {

	private Transform gears;
	private GameObject rotateArrow;
	private GameObject directionArrow;
	private ScoreKeeper keeperScript;
	private SpriteRenderer sr;

	private float MAX_SPEED = 6;
	private float speed = 2;
	private float torque = 1;
	private int direction = 1; // 1 == right, -1 == left

	public string startingDirection = "right";
	public bool disabledOnStart = false;

	void Start () {
		gears = transform.GetChild (1).transform;
		rotateArrow = transform.GetChild (2).gameObject;
		directionArrow = transform.GetChild (3).gameObject;
		keeperScript = GameObject.Find ("ScoreKeeper").GetComponent<ScoreKeeper> ();
		sr = gameObject.GetComponent<SpriteRenderer> ();

		if (startingDirection == "left") {
			flip();
		}
		if (disabledOnStart) {
			gameObject.tag = "Untagged";
		}
	}

	void Update() {
		if (keeperScript.getActiveBalls() > 0 || disabledOnStart) {
			rotateArrow.SetActive(false);
			directionArrow.SetActive(false);
		} else {
			rotateArrow.SetActive(true);
			directionArrow.SetActive(true);
		}
	}

	public void flip() {
		directionArrow.transform.GetChild(0).transform.Rotate (new Vector3 (0, 0, 180));
		gears.Rotate(new Vector3(0, 180, 0));
		direction = (direction > 0) ? -1 : 1;
		sr.flipX = !sr.flipX;
	}

	public void Recycle() {
		GameObject.Find("ConveyorBeltCreator").GetComponent<Create> ().Increment ();
	}


	void OnTriggerStay2D(Collider2D col) {
		Rigidbody2D rb = col.gameObject.GetComponent<Rigidbody2D> ();
		if (rb.velocity.magnitude < MAX_SPEED) {
			rb.AddForce (new Vector2 (direction * speed, 0));
			rb.AddTorque (direction * torque);
		}
	}
}
