using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Next : MonoBehaviour {

	//	public Vector3 dest;
	private Vector3[] destinations = new Vector3[4];
	public CameraController maincamera;
	public Sink[] greensinks;
	public Sink[] pinksinks;
	public int sinknum = 0;

	public int[] numconv = new int[4];
	public int[] numwall = new int[4];
	public Create conveyor;
	public Create wall;



	// Use this for initialization
	void Start () {
		destinations [0] = new Vector3 (0, -7, -10);
		destinations [1] = new Vector3 (0, -14, -10);
		destinations [2] = new Vector3 (0, -21, -10);
		destinations [3] = new Vector3 (0, -28, -10);

		Button nextBtn = gameObject.GetComponent<Button> ();
		nextBtn.onClick.AddListener(() => {
			maincamera.move = true;
			maincamera.dest = destinations[sinknum];
			greensinks[sinknum].flip = true;	
			pinksinks[sinknum].flip = true;
			GameObject.Find("DialogueModal").SetActive(false);
			GameObject.Find("ScoreKeeper").GetComponent<ScoreKeeper>().stage++;
			conveyor.setNewRemaining(numconv[sinknum]);
			wall.setNewRemaining(numwall[sinknum]);
			sinknum++;

		});
	}
}
