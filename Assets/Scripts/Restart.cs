using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

	void Start () {
		Button rstBtn = gameObject.GetComponent<Button> ();
		rstBtn.onClick.AddListener(() => {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		});
	}
}
