using UnityEngine;
using System.Collections;

public class scored : MonoBehaviour {
	public GUI menu;
	// Use this for initialization
	void Start () {
		Debug.Log("start scored");
		SharedBehaviour.current.score = 115;
		menu = GameObject.FindGameObjectWithTag("menuRoot").GetComponent<GUI>();
		menu.state = "highscores";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
