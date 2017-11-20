using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlaceableArea : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.layer == 10) {
			ManualBelt belt = collider.gameObject.GetComponent<ManualBelt> ();
			if (belt) {
				belt.setPlaceable (false);
			}
			Wall wall = collider.gameObject.GetComponent<Wall> ();
			if (wall) {
				wall.setPlaceable (false);
			}
		}
	}
	void OnTriggerExit2D(Collider2D collider) {
		if (collider.gameObject.layer == 10) {
			ManualBelt belt = collider.gameObject.GetComponent<ManualBelt> ();
			if (belt) {
				belt.setPlaceable (true);
			}
			Wall wall = collider.gameObject.GetComponent<Wall> ();
			if (wall) {
				wall.setPlaceable (true);
			}
		}
	}
}
