using UnityEngine;
using System.Collections;

public class SharedBehaviour : MonoBehaviour {
	public static SharedBehaviour current;
	public int score;
	public string playerName;


	void Awake() {
		if(current != null && current != this) {
			Destroy(gameObject);
		}
		else {
			DontDestroyOnLoad(gameObject);
			current = this;
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
