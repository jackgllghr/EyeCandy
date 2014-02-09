using UnityEngine;
using System.Collections;

public class MenuMouseOver : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter() {
		Debug.Log("Exit MouseOver");

		transform.guiText.color = Color.black;
		transform.guiText.fontStyle = FontStyle.Bold;
	}
	
	void OnMouseExit() {

		transform.guiText.color = Color.white;
		transform.guiText.fontStyle = FontStyle.Normal;
	}

}
