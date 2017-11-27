using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private ScoreKeeper keeperScript;
	private float initialSpeed = 5;
	public bool painted;
	public string color;
	public GameObject GhostBall;
	private Rigidbody2D rb;
	public bool isDead = false;



	void Start () {
		keeperScript = GameObject.Find("ScoreKeeper").GetComponent<ScoreKeeper>();
		rb = gameObject.GetComponent<Rigidbody2D> ();
//		gameObject.GetComponent<BoxCollider2D> ().enabled = false;
	}

	public void init(Vector2 direction) {
		GetComponent<Rigidbody2D>().velocity = direction * initialSpeed;
	}

	void Update () {
		if (rb.velocity.magnitude > 0.1f) {
			Instantiate (GhostBall, transform.position, transform.rotation);
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.CompareTag ("BallDeath") && !isDead) {
			keeperScript.ballDied ();
			Destroy (gameObject);
			isDead = true;
		} else if (color == collider.gameObject.tag && !isDead) {
			keeperScript.ballScored ();
			isDead = true;
			collider.transform.parent.gameObject.GetComponent<Sink> ().AddBall (this.gameObject);
		} else if (collider.gameObject.tag == "Painter") {

		} else if (collider.gameObject.layer == 8 && !isDead) {
			keeperScript.ballDied ();
			isDead = true;
		}
	}

	void onTriggerExit2D(Collider collider) {
	}
}
