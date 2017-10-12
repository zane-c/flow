using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggingScript : MonoBehaviour {

	public GameObject gameObjectToDrag;

	public Vector3 GOCenter;
	public Vector3 clickPosition;
	public Vector3 offset; // between clickPosition and GOCenter
	public Vector3 newGOCenter;//

	RaycastHit hit;
	public bool draggingMode = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {

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

		if (Input.GetMouseButton(0))
		{
			if (draggingMode) {
				clickPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				newGOCenter = clickPosition - offset;
				gameObjectToDrag.transform.position = new Vector3(newGOCenter.x, newGOCenter.y, GOCenter.z);

			}
		}

		if (Input.GetMouseButtonUp(0))
		{
			draggingMode = false;
		}
	}


}
