using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conveyor : MonoBehaviour {

	private SurfaceEffector2D effector;
	private Transform gears;
	private GameObject rotateArrow;
	private GameObject directionArrow;
	private ScoreKeeper keeperScript;
	private SpriteRenderer sr;

	void Start () {
		effector = gameObject.GetComponent<SurfaceEffector2D> ();
		gears = transform.GetChild (1).transform;
		rotateArrow = transform.GetChild (2).gameObject;
		directionArrow = transform.GetChild (3).gameObject;
		keeperScript = GameObject.Find ("ScoreKeeper").GetComponent<ScoreKeeper> ();
		sr = gameObject.GetComponent<SpriteRenderer> ();
	}

	void Update() {
		if (keeperScript.getActiveBalls() > 0) {
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
		effector.speed *= -1;
		sr.flipX = !sr.flipX;
	}

	public void Recycle() {
		
		GameObject.Find("ConveyorBeltCreator").GetComponent<Create> ().Increment ();
	}

}
