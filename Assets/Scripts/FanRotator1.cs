using UnityEngine;
using System.Collections;

public class FanRotator1 : MonoBehaviour {

	public	float	rotationSpeed = 50.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Rotate(Vector3.back * Time.deltaTime * rotationSpeed);

	}
}
