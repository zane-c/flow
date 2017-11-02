using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Required when using Event data.

public class Create : MonoBehaviour, IPointerDownHandler // required interface when using the OnPointerDown method.
{

	public GameObject gizmo;
	public Text countTxt;
	private Text component;
	RectTransform m_RectTransform;

	void Start () {
		component = countTxt.GetComponent<Text> ();
	}

	public void OnPointerDown (PointerEventData eventData)
	{
		m_RectTransform = GetComponent<RectTransform>();

		Text component = countTxt.GetComponent<Text> ();
		string numStr = component.text.Substring (1, component.text.Length - 1);
		int numRemaining = int.Parse(numStr);

		if (numRemaining > 0) {
			GameObject createdConveyer = Instantiate (gizmo);
			createdConveyer.transform.position = m_RectTransform.position;
			RaycastHit2D hit2d = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
			numRemaining--;
			component.text = "x" + numRemaining;
		}
	}


}
