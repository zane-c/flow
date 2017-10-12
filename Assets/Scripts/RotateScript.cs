using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour {

	public Transform gameObjectToRotate;

	float deltaRotation;
	public float deltaLimit;
	public float deltaReduce ;
	float previousRotation;
	float currentRotation;

	RaycastHit hit;
	public bool rotatingMode = false;


	void Start () {
	}

	float angleBetweenPoints (Vector2 position1, Vector2 position2)
	{
		Vector2 fromLine = position2 - position1;
		Vector2 toLine = new Vector2 (1, 0);

		float angle = Vector2.Angle (fromLine, toLine);

		Vector3 cross = Vector3.Cross (fromLine, toLine);

		// did we wrap around?
		if (cross.z > 0) {
			angle = 360f - angle;
		}

		return angle;
	}

	void Update () {
		// this is how you rotate the conveyor belt
		// parent.Rotate(0,0, 20 * Time.deltaTime);



		if (Input.GetMouseButtonDown (0)) {

			Vector3 screenToWorldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit2d = Physics2D.Raycast (screenToWorldPoint, Vector2.zero);
			deltaRotation = 0f;
			if (hit2d) {
				if (hit2d.collider.CompareTag ("Rotatable")) {
					gameObjectToRotate = hit2d.collider.gameObject.transform.parent;
					Debug.Log ("hit rotator");
					rotatingMode = true;
				}
			}
				
			previousRotation = angleBetweenPoints (gameObjectToRotate.position, screenToWorldPoint);
		} 
		if (Input.GetMouseButton (0)) {
			if (rotatingMode == true) {

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

			rotatingMode = false;
			gameObjectToRotate.Rotate (Vector3.back * Time.deltaTime, deltaRotation);
			deltaRotation = Mathf.Lerp (deltaRotation, 0, deltaReduce * Time.deltaTime);
		}

	}
}
