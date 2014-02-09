using UnityEngine;
using System.Collections;

public class Fan : MonoBehaviour {

	// Use this for initialization
	public float power;
	private GameObject player;	
	void Start () {
		
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player) {
						if (player.GetComponent<SizeChange> ().currentState == 1) {
								other.gameObject.transform.position += new Vector3 (power, 0.0f, 0.0f);
						}
				}
		}
	void OnTriggerStay(Collider other)
	{
		if (other.gameObject == player) {
						if (player.GetComponent<SizeChange> ().currentState == 1) {
								other.gameObject.transform.position += new Vector3 (power, 0.0f, 0.0f);
						}
				}

	}
}
