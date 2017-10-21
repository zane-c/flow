using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DraggingScript : MonoBehaviour {

	public GameObject conveyerBelt;
	private GameObject gameObjectToDrag;
	private GameObject itemMenu;
	public Text conveyerBeltTxt;
	private bool isColliding = false;

	private Vector3 GOCenter;
	private Vector3 clickPosition;
	private Vector3 offset; // between clickPosition and GOCenter
	private Vector3 newGOCenter;//

	private RaycastHit hit;
	private bool draggingMode = false;
	private bool isPlaying = false;

	void Start () {
		Button playBtn = GameObject.Find ("Play").GetComponent<Button>();

		itemMenu = GameObject.Find ("ItemMenu").gameObject;

		playBtn.onClick.AddListener(() => {
			isPlaying = !isPlaying;
		});
	}

	void Update () {
		if (Input.GetMouseButtonDown (0) && !isPlaying) {

			RaycastHit2D hit2d = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);

			if (hit2d) {
				if (hit2d.collider.CompareTag("Draggable")) {
					gameObjectToDrag = hit2d.collider.gameObject;
					GOCenter = gameObjectToDrag.transform.position;
					clickPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
					offset = clickPosition - GOCenter;
					draggingMode = true;
				}
				if (gameObjectToDrag.transform.position.x > 6.5) {
					Debug.Log (gameObjectToDrag.transform.position);
					Text component = conveyerBeltTxt.GetComponent<Text> ();
					string numStr = component.text.Substring (1, component.text.Length - 1);
					int numRemaining = int.Parse(numStr);
					numRemaining--;
					component.text = "x" + numRemaining;

					if (numRemaining > 0) {
						GameObject createdConveyer = Instantiate (conveyerBelt);
						createdConveyer.transform.position = gameObjectToDrag.transform.position;
					}
				}

			}
		}

		if (Input.GetMouseButton(0) && !isPlaying && draggingMode)
		{
			clickPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			newGOCenter = clickPosition - offset;
			gameObjectToDrag.transform.position = new Vector3(newGOCenter.x, newGOCenter.y, GOCenter.z);
		}

		if (Input.GetMouseButtonUp(0))
		{
			if (draggingMode) {
				if (gameObjectToDrag.transform.position.x > 6.5) {
					Destroy (gameObjectToDrag);
					Debug.Log (gameObjectToDrag.transform.position.x);


					Text component = conveyerBeltTxt.GetComponent<Text> ();

					string numStr = component.text.Substring (1, component.text.Length - 1);
					int numRemaining = int.Parse(numStr);
					if (numRemaining == 0) {
						GameObject createdConveyer = Instantiate (conveyerBelt);
						createdConveyer.transform.position = new Vector3(7.7f, 4.0f, 0.0f);


					}
					numRemaining++;
					component.text = "x" + numRemaining;

				}
				draggingMode = false;
			}
			


		}
	}
}
