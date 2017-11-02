using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplier : MonoBehaviour {
	public GameObject ball;
	public GameObject multiplier;

	// Use this for initialization
	void Start () {
		
	}
	// thing to consider, things can fall at an angle so get the velocity of whatever is contacted
	void OnTriggerEnter2D(Collider2D collider) {
		switch (collider.tag) {
		case "Ball": {
				var v = collider.GetComponent<Rigidbody2D> ().velocity;


				for (int i = 0; i < 5; i++) {
					var w = multiplier.GetComponent<BoxCollider2D> ().bounds.size.x;
					var rand = Random.Range (0, w);
					GameObject createdBall = Instantiate (ball);
					createdBall.GetComponent<Rigidbody2D> ().velocity = v * 0.5f;
					createdBall.transform.position = new Vector2(transform.position.x - (w / 2) + rand, transform.position.y - 0.5f);
				}
				Destroy (multiplier);

				break;
			}
		default: {
				break;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
