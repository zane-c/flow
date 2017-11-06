using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gizmo : MonoBehaviour {

	public Image creator;

	public void Recycle() {
		creator.GetComponent<Create> ().Increment ();
	}

}
