using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DraggingScript : MonoBehaviour {

	public GameObject conveyerBelt;
	private GameObject gameObjectToDrag;
	private GameObject creator;
	private GameObject itemMenu;
	public Text conveyerBeltTxt;

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
				if (hit2d.collider.CompareTag("Creator")) {
					Text component = conveyerBeltTxt.GetComponent<Text> ();
					string numStr = component.text.Substring (1, component.text.Length - 1);
					int numRemaining = int.Parse(numStr);

					creator = hit2d.collider.gameObject;
					if (numRemaining > 0) {
						GameObject createdConveyer = Instantiate (conveyerBelt);
						createdConveyer.transform.position = creator.transform.position;
						gameObjectToDrag = createdConveyer;
						GOCenter = gameObjectToDrag.transform.position;
						clickPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
						offset = clickPosition - GOCenter;
						draggingMode = true;
						numRemaining--;
						component.text = "x" + numRemaining;
					}
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
				if (gameObjectToDrag.transform.position.x > 6.5) {
					Destroy (gameObjectToDrag);


					Text component = conveyerBeltTxt.GetComponent<Text> ();

					string numStr = component.text.Substring (1, component.text.Length - 1);
					int numRemaining = int.Parse(numStr);
					numRemaining++;
					component.text = "x" + numRemaining;

				}
				draggingMode = false;
			}



		}
	}
}
