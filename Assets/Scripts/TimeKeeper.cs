using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeKeeper : MonoBehaviour {

	private string state = "build"; // build - play - menu

	void Start () {

	}

	void Update () {

	}

	public void setState(string s) {
		state = s;
	}

	public string getState() {
		return state;
	}
}
