using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipObject : MonoBehaviour {

	void Update () {
		if (Input.GetMouseButtonDown (0)) {

			RaycastHit2D hit2d = Physics2D.Raycast(
				Camera.main.ScreenToWorldPoint(Input.mousePosition),
				Vector2.zero
			);

			if (hit2d && hit2d.collider.CompareTag("Flippable")) {
				hit2d.collider.gameObject.transform.parent
				.GetComponent<Conveyor> ().flip();
			}
		}
	}
}
