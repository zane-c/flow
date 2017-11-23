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
	private AudioSource placeSound;
	private AudioSource errorSound;

	void Start () {
		keeperScript = GameObject.Find("ScoreKeeper").GetComponent<ScoreKeeper>();
		placeSound = GameObject.Find ("GizmoPlaceSound").GetComponent<AudioSource> ();
		errorSound = GameObject.Find ("GizmoPlaceSoundError").GetComponent<AudioSource> ();
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
		}

		if (Input.GetMouseButtonUp(0))
		{
			if (draggingMode) {
				ManualBelt belt = gameObjectToDrag.GetComponent<ManualBelt> ();
				Wall wall = gameObjectToDrag.GetComponent<Wall> ();
				if (belt && !belt.getPlaceable () && gameObjectToDrag.transform.position.x < 7) {
					gameObjectToDrag.transform.position = GOCenter;
					errorSound.Play ();
				} else if (wall && !wall.getPlaceable () && gameObjectToDrag.transform.position.x < 7) {
					gameObjectToDrag.transform.position = GOCenter;
					errorSound.Play ();
				} else {
					placeSound.Play ();
				}
				if (gameObjectToDrag.transform.position.x > 7) {
					if (gameObjectToDrag.transform.GetChild (0).gameObject.CompareTag ("ConveyorBelt")) {
						creator = GameObject.Find ("ConveyorBeltCreator");
						creator.GetComponent<Create> ().Increment ();
					}
					if (gameObjectToDrag.transform.GetChild (0).gameObject.CompareTag ("Wall")) {
						creator = GameObject.Find ("WallCreator");
						creator.GetComponent<Create> ().Increment ();
					}
					Destroy (gameObjectToDrag);
					errorSound.Play ();
				}
				draggingMode = false;
			}
		}
	}
}
