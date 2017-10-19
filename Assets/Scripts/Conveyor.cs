using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conveyor : MonoBehaviour {

	private SurfaceEffector2D effector;
	private Transform gears;
	private GameObject rotateArrow;
	private GameObject directionArrow;
	private bool isPlaying = false;

	void Start () {
		effector = gameObject.GetComponent<SurfaceEffector2D> ();
		gears = gameObject.transform.GetChild (0).transform;
		rotateArrow = gameObject.transform.GetChild (1).gameObject;
		directionArrow = gameObject.transform.GetChild (2).gameObject;

		rotateArrow.SetActive(true);
		directionArrow.SetActive(true);

		Button playBtn = GameObject.Find ("Play").GetComponent<Button>();
		playBtn.onClick.AddListener(() => {
			isPlaying = !isPlaying;
			if (isPlaying) {
				rotateArrow.SetActive(false);
				directionArrow.SetActive(false);
			} else {
				rotateArrow.SetActive(true);
				directionArrow.SetActive(true);
			}
		});
	}

	public void flip() {
		gears.Rotate(new Vector3(0, 180, 0));
		effector.speed *= -1;
	}
}
