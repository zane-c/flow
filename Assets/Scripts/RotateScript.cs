using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour {

	private Transform gameObjectToRotate;

	float deltaRotation;
	public float deltaLimit;
	public float deltaReduce;
	Quaternion savedRotation;
	float previousRotation;
	float currentRotation;
	private AudioSource placeSound;
	private AudioSource errorSound;

	RaycastHit hit;
	public bool rotatingMode = false;


	void Start () {
		placeSound = GameObject.Find ("GizmoPlaceSound").GetComponent<AudioSource> ();
		errorSound = GameObject.Find ("GizmoPlaceSoundError").GetComponent<AudioSource> ();
	}

	float angleBetweenPoints (Vector2 position1, Vector2 position2)
	{
		Vector2 fromLine = position2 - position1;
		Vector2 toLine = new Vector2 (1, 0);

		float angle = Vector2.Angle (fromLine, toLine);

		Vector3 cross = Vector3.Cross (fromLine, toLine);

		if (cross.z > 0) {
			angle = 360f - angle;
		}

		return angle;
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {

			Vector3 screenToWorldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit2d = Physics2D.Raycast (screenToWorldPoint, Vector2.zero);
			deltaRotation = 0f;
			if (hit2d) {
				if (hit2d.collider.CompareTag ("Rotatable")) {
					gameObjectToRotate = hit2d.collider.gameObject.transform.parent;
					rotatingMode = true;
					savedRotation = gameObjectToRotate.rotation;
					previousRotation = angleBetweenPoints (gameObjectToRotate.position, screenToWorldPoint);
				}
			}

		}
		if (Input.GetMouseButton (0)) {
			if (rotatingMode) {

				currentRotation = angleBetweenPoints (gameObjectToRotate.position, Camera.main.ScreenToWorldPoint (Input.mousePosition));
				deltaRotation = Mathf.DeltaAngle (currentRotation, previousRotation);
				if (Mathf.Abs (deltaRotation) > deltaLimit) {
					deltaRotation = deltaLimit * Mathf.Sign (deltaRotation);
				}
				previousRotation = currentRotation;
				gameObjectToRotate.Rotate (Vector3.back * Time.deltaTime, deltaRotation);
			}
		}
		if (Input.GetMouseButtonUp (0)) {
			if (gameObjectToRotate && rotatingMode) {
				ManualBelt belt = gameObjectToRotate.gameObject.GetComponent<ManualBelt> ();
				Wall wall = gameObjectToRotate.gameObject.GetComponent<Wall> ();
				if (belt && !belt.getPlaceable () && gameObjectToRotate.transform.position.x < 7) {
					gameObjectToRotate.rotation = savedRotation;
					errorSound.Play ();
				} else if (wall && !wall.getPlaceable () && gameObjectToRotate.transform.position.x < 7) {
					gameObjectToRotate.rotation = savedRotation;
					errorSound.Play ();
				} else {
					deltaRotation = Mathf.Lerp (deltaRotation, 0, deltaReduce * Time.deltaTime);
					placeSound.Play ();
				}
				rotatingMode = false;
			}
		}
	}
}
