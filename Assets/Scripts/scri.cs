using UnityEngine;
using System.Collections;

public class scri : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onTriggerEnter(Collider other)
	{
		Debug.Log (other.tag);
				if (other.tag.Equals ("Player")) {
					Debug.Log("Pool restart");
					//Application.LoadLevel (0);
				}
		}
}
