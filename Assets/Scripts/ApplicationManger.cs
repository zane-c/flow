﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplicationManger : MonoBehaviour {

	public void LoadScene(string scene) {
		SceneManager.LoadScene(scene);
	}

	public void Quit() {
		Application.Quit ();
	}
}
