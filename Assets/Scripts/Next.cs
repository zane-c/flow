using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Next : MonoBehaviour {

	//	public Vector3 dest;
	public Vector3[] destinations;
	public CameraController maincamera;
	public Sink[] sinks;
	public int sinknum = 0;

	public GameObject dialogue;

	// Use this for initialization
	void Start () {
		Button nextBtn = gameObject.GetComponent<Button> ();
		nextBtn.onClick.AddListener(() => {
			maincamera.move = true;
			maincamera.dest = destinations[sinknum];
			sinks[sinknum].flip = true;	
			GameObject.Find("DialogueModal").SetActive(false);
			sinknum++;
		});
	}
}
