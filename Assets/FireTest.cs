using UnityEngine;
using System.Collections;

public class FireTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetButtonDown("Fire1")){

			Debug.Log ("Fire1");

		}

		if(Input.GetButtonDown("Fire2")){
			
			Debug.Log ("Fire2");
			
		}

		if(Input.GetButtonDown("Fire3")){
			
			Debug.Log ("Fire3");
			
		}

		if(Input.GetButtonDown("Jump")){
			
			Debug.Log ("Jump");
			
		}

	}
}
