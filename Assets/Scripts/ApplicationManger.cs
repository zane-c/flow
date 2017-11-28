using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ApplicationManger : MonoBehaviour {

	private GameObject music;
	private bool isMusicOn = true;
	public GameObject pauseMenu;
	private bool isPauseOpen = false;

	void Start() {
		music = GameObject.Find("Music");
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			TogglePauseMenu ();
		}
	}

	public void TogglePauseMenu() {
		if (pauseMenu) {
			isPauseOpen = !isPauseOpen;
			Time.timeScale = isPauseOpen ? 0 : 1;
			pauseMenu.SetActive (isPauseOpen);
		}
	}

	public void ToggleVolumne() {
		isMusicOn = !isMusicOn;
		music.GetComponent<AudioSource> ().volume = isMusicOn ? 0.4f : 0f;
		pauseMenu.transform.GetChild (2).GetComponentInChildren<Text> ().text = isMusicOn ? "Music: On" : "Music: Off";
	}

	public void LoadScene(string scene) {
		Time.timeScale = 1;
		SceneManager.LoadScene(scene);
	}

	public void RestartLevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void Quit() {
		Application.Quit ();
	}
}
