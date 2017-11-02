using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drop : MonoBehaviour {


	public Text conveyerBeltTxt;
	RectTransform m_RectTransform;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Increment() {
		Text component = conveyerBeltTxt.GetComponent<Text> ();
		string numStr = component.text.Substring (1, component.text.Length - 1);
		int numRemaining = int.Parse(numStr);

		numRemaining++;
		Debug.Log (numRemaining);
		component.text = "x" + numRemaining;
	}
}
