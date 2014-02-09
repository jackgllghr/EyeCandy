using UnityEngine;
using System.Collections;

public class MenuNewGame : MonoBehaviour {
	public bool MouseOver = false;
	public GUI menu;
	// Use this for initialization
	void Start () {
		menu = GameObject.FindGameObjectWithTag("menuRoot").GetComponent<GUI>() as GUI;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter() {
		Debug.Log("NewGame MouseOver");
		MouseOver = true;
	}

	void OnMouseExit() {
		MouseOver = false;
	}

	void OnMouseDown() {
		if(MouseOver) {
			Debug.Log ("Click Play");
			menu.state = "playing";
			Application.LoadLevel(1);
			// load level	

		}
	}
}
