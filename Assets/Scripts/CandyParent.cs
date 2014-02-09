using UnityEngine;
using System.Collections;

public class CandyParent : MonoBehaviour {
	
	public	float		collectionSpeed;
	
	private	bool		collected = false;
	
	private	Transform	player;
	
	public	AudioClip	pickup;
	public int points = 10;
	public float collectTime;
	public float lifeTime;
	
	// Use this for initialization
	void Start () {
		
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (collected){
			SharedBehaviour.current.score += points;
			transform.position = Vector3.Lerp(transform.position, player.position, collectionSpeed *Time.deltaTime);
			if(Time.time >= collectTime + lifeTime) {
				if(pickup != null){
					AudioSource.PlayClipAtPoint(pickup, transform.position);
				}
				Destroy(gameObject);
			}
			
		}
		
	}
	
	void OnTriggerEnter (Collider other) {
		collectTime = Time.time;
		Debug.Log("candy triggered");
		if(other.transform.tag == "Player"){
			Debug.Log ("I have been collected by player!");
			
			
			collected = true;
			
		}
		
	}
}
