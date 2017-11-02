using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DraggingScript : MonoBehaviour {

	private GameObject gameObjectToDrag;
	private GameObject creator;

	private Vector3 GOCenter;
	private Vector3 clickPosition;
	private Vector3 offset; // between clickPosition and GOCenter
	private Vector3 newGOCenter;

	private RaycastHit hit;
	private bool draggingMode = false;
	private ScoreKeeper keeperScript;

	void Start () {
		keeperScript = GameObject.Find("ScoreKeeper").GetComponent<ScoreKeeper>();
	}

	void Update () {
		if (Input.GetMouseButtonDown (0) && keeperScript.getActiveBalls() == 0) {

			RaycastHit2D hit2d = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);

			if (hit2d) {
				if (hit2d.collider.CompareTag("Draggable")) {
					gameObjectToDrag = hit2d.collider.gameObject;
					GOCenter = gameObjectToDrag.transform.position;
					clickPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
					offset = clickPosition - GOCenter;
					draggingMode = true;
				}

			}
		}

		if (Input.GetMouseButton(0) && keeperScript.getActiveBalls() == 0 && draggingMode)
		{
			clickPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			newGOCenter = clickPosition - offset;
			gameObjectToDrag.transform.position = new Vector3(newGOCenter.x, newGOCenter.y, GOCenter.z);
			if (gameObjectToDrag.transform.position.x > 6.5) {

			}
		}

		if (Input.GetMouseButtonUp(0))
		{
			if (draggingMode) {
				if (gameObjectToDrag.transform.position.x > 7) {
					if (gameObjectToDrag.transform.GetChild (0).gameObject.CompareTag("ConveyorBelt")) {
						creator = GameObject.Find ("ConveyorBeltCreator");
						Text sup = creator.GetComponent<Text> ();
						creator.GetComponent<Drop>().Increment();
					}
					if (gameObjectToDrag.transform.GetChild (0).gameObject.CompareTag("Wall")) {
						creator = GameObject.Find ("WallCreator");
						Text sup = creator.GetComponent<Text> ();
						creator.GetComponent<Drop>().Increment();
					}
					Destroy (gameObjectToDrag);
				}
				draggingMode = false;
			}



		}
	}
}
