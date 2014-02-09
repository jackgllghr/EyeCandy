using UnityEngine;
using System.Collections;

public class MenuControls : MonoBehaviour {
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
		Debug.Log("Controls MouseOver");
		MouseOver = true;
	}
	
	void OnMouseExit() {
		MouseOver = false;
	}
	
	void OnMouseDown() {
		if(MouseOver) {
			Debug.Log ("Click Controls");
			menu.controls = true;

		}
	}
}
