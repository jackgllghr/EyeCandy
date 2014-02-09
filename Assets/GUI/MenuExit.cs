using UnityEngine;
using System.Collections;

public class MenuExit : MonoBehaviour {
	public bool MouseOver = false;
	//public Color on;
	//public Color off;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnMouseDown() {
		if(MouseOver) {
			Debug.Log ("Exit");
		}
	}
}
