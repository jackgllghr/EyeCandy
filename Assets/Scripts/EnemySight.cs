using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour {
	
//	public float fieldOfViewAngle = 110f;				// Number of degrees, centred on forward, for the enemy see.
//	public bool playerInSight;							// Whether or not the player is currently sighted.
//	public GameObject player;							// Reference to the player.
//
//	public NavMeshAgent	nav;
//	
//	public SphereCollider col;							// Reference to the sphere collider trigger component.
//
//	public int state = 0;
//
//	public	SizeChange	sc;
//	
//	// Use this for initialization
//	void Start () {
//
//		nav = GetComponent<NavMeshAgent>();
//
//		col = GetComponentInChildren<SphereCollider> ();
//		// col = GetComponent<SphereCollider>();
//		
//		player = GameObject.FindGameObjectWithTag("Player");
//		//state = (int)SizeChange.State.LARGE; // big
//
//		sc = player.GetComponent<SizeChange> ();
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		
//	}
//	
//	void OnTriggerStay (Collider other)
//	{
//		Debug.Log ("Triggering!");
//		
//		// If the player has entered the trigger sphere...
//		if(other.gameObject == player)
//		{
//			Debug.Log ("Player in radius");
//			
//			// By default the player is not in sight.
//			playerInSight = false;
//			
//			// Create a vector from the enemy to the player and store the angle between it and forward.
//			Vector3 direction = other.transform.position - transform.position;
//			float angle = Vector3.Angle(direction, transform.forward);
//			
//			// If the angle between forward and where the player is, is less than half the angle of view...
//			if(angle < fieldOfViewAngle * 0.5f)
//			{
//				
//				Debug.Log ("Player in FOV");
//				
//				RaycastHit hit;
//				
//				// ... and if a raycast towards the player hits something...
//				if(Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, col.radius))
//				{
//					// ... and if the raycast hits the player...
//					if(hit.collider.gameObject == player)
//					{
//						Debug.Log ("Have seen player!");
//						
//						// ... the player is in sight.
//						playerInSight = true;
//
//						sc.setState(state);
//						//not needed
//						// Set the last global sighting is the players current position.
//						//lastPlayerSighting.position = player.transform.position;
//					}
//				}
//			}
//		}
//	}
}
