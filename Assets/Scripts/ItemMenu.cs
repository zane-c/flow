using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMenu : MonoBehaviour {


	// Buttons
	public Button conveyerBeltBtn;

	// Game Objects
	public GameObject conveyerBelt;

	// Labels
	public Text conveyerBeltTxt;

	// Use this for initialization
	void Start () {
		Button conveyerBeltComp = conveyerBeltBtn.GetComponent<Button>();
		conveyerBeltComp.onClick.AddListener(AddConveyer);
	}

	// Update is called once per frame
	void Update () {

	}

	// Add a gizmo onto the screen so it can be placed by user
	void AddConveyer() {
		Text component = conveyerBeltTxt.GetComponent<Text> ();
		string numStr = component.text.Substring (1, component.text.Length - 1);
		int numRemaining = int.Parse(numStr);

		if (numRemaining > 0) {
			GameObject createdConveyer = Instantiate (conveyerBelt);
			createdConveyer.transform.position = new Vector3 (-3, 0, 0);

			numRemaining--;
			component.text = "x" + numRemaining;
		}
	}
}