using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

	void Start () {
		Button playBtn = gameObject.GetComponent<Button> ();
		playBtn.onClick.AddListener(() => {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		});
	}
}
