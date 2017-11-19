using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {


	public GameObject to;

	// Use this for initialization
	void Start () {

	}

	void OnTriggerEnter2D(Collider2D collider) {
		
		switch (collider.tag) {
		case "Ball": {
				if (collider.transform.gameObject.GetComponent<Ball> ().painted == false) {

					collider.transform.gameObject.GetComponent<Ball> ().painted = true;
					Vector3 newPosition = collider.transform.position;
					Vector2 velocity = collider.gameObject.GetComponent<Rigidbody2D>().velocity;
//					Vector2 direction = new Vector2 (Mathf.Sin (gameObject.transform.parent.eulerAngles.z), Mathf.Cos (gameObject.transform.parent.eulerAngles.z));

					Vector2 direction = new Vector2(0,0);

					if (velocity.x > 0) {
						direction = new Vector2 (-Mathf.Sin (gameObject.transform.parent.eulerAngles.z), Mathf.Cos (gameObject.transform.parent.eulerAngles.z));
					}

	
					Destroy (collider.gameObject);
					GameObject newBall = Instantiate (to);
					newBall.GetComponent<Ball> ().painted = true;

					newBall.GetComponent<Rigidbody2D> ().gravityScale = 1;
					newBall.GetComponent<CircleCollider2D> ().enabled = true;

					newBall.transform.position = newPosition;
					newBall.transform.GetComponent<Rigidbody2D>().velocity = velocity;
					newBall.transform.gameObject.GetComponent<Rigidbody2D>().AddForce(5 * direction * newBall.transform.gameObject.GetComponent<Rigidbody2D>().mass / Time.fixedDeltaTime, ForceMode2D.Force);

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
