using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}

	void OnTriggerEnter2D(Collider2D collider) {
		switch (collider.tag) {
		case "Ball": {
				print ("collide");
				var v = collider.GetComponent<Rigidbody2D> ().velocity;
				var diffX = Mathf.Abs (collider.transform.position.x - transform.position.x);
				var diffY = Mathf.Abs (collider.transform.position.y - transform.position.y);

				if (collider.transform.position.x < transform.position.x) {
					collider.GetComponent<Rigidbody2D> ().AddForce (new Vector2(75, 0));
				} else {
					collider.GetComponent<Rigidbody2D> ().AddForce (new Vector2(-75, 0));
				}

				if (collider.transform.position.y < transform.position.y) {
					collider.GetComponent<Rigidbody2D> ().AddForce (new Vector2(0, 75));
				} else {
					collider.GetComponent<Rigidbody2D> ().AddForce (new Vector2(0, -75));
				}
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
