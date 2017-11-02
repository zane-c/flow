using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drop : MonoBehaviour {


	public Text countTxt;
	RectTransform m_RectTransform;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Increment() {
		Text component = countTxt.GetComponent<Text> ();
		string numStr = component.text.Substring (1, component.text.Length - 1);
		int numRemaining = int.Parse(numStr);

		numRemaining++;
		Debug.Log (numRemaining);
		component.text = "x" + numRemaining;
	}
}
