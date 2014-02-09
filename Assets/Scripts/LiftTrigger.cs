using UnityEngine;
using System.Collections;

public class LiftTrigger : MonoBehaviour {

	private LiftPlatform liftPlatform;

	// Use this for initialization
	void Start () {
		liftPlatform = GameObject.Find ("LiftPlatform").GetComponent<LiftPlatform> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			Debug.Log ("enter");
			liftPlatform.inMotion = true;
		}
	}

	void OnTriggerStay (Collider other) {
		if (other.tag == "Player") {
			Debug.Log ("stay");
			liftPlatform.inMotion = true;
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.tag == "Player") {
			Debug.Log ("exit");
			liftPlatform.inMotion = false;
		}
	}
}
