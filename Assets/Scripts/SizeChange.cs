using UnityEngine;
using System.Collections;

public class SizeChange : MonoBehaviour
{

		public enum State
		{
				LARGE,
				SMALL,
				NORMAL
		}
	
		public int currentState;
		public int newState;

		public	CharacterController charCont;

		public	Transform			modelTransform;

		public	Vector3				small;

		public	Vector3				large;
	
		public	bool				canChangeWall = true;
		public	bool				canChangeEnemy = true;


		public SizeChange ()
		{
		}
		// Use this for initialization
		void Start ()
		{
	
				charCont = GetComponent<CharacterController> ();

				modelTransform = GameObject.Find ("PlayerModel").GetComponent<Transform> ();

				currentState = (int)State.NORMAL;
				newState = -1;

				//setState ((int)State.LARGE);

		}
		void Awake ()
		{

		}
	
		// Update is called once per frame
		void Update ()
		{
	
				if (Input.GetKeyDown (KeyCode.K)) {

						//Debug.Log ("Small input...");
						setState ((int)State.SMALL);

				}
				if (Input.GetKeyDown (KeyCode.L)) {
			
						//Debug.Log ("Big input...");
						setState ((int)State.LARGE);
			
				}
		}

		public void setState (int s)
		{
				if (canChangeWall && canChangeEnemy) {
						newState = s;
						changeSize ();
						currentState = s;
				}
		}


		//changes size of the player 
		void changeSize ()
		{
				modelTransform = GameObject.Find ("PlayerModel").GetComponent<Transform> ();
				if (newState == (int)State.LARGE && currentState != newState) {
						//modelTransform = GameObject.Find ("PlayerModel").GetComponent<Transform> ();
						modelTransform.localScale = large;

						transform.position += new Vector3 (0, 0.99f, 0);

						charCont.radius = 1.0f;
						charCont.height = 2.0f;

				}
				if (newState == (int)State.SMALL && currentState != newState) {
						//modelTransform = GameObject.Find ("PlayerModel").GetComponent<Transform> ();
						modelTransform.localScale = small;

						//transform.position += new Vector3(0,0.99f,0);


						charCont.radius = 0.25f;
						charCont.height = 0.5f;

				}
				if (newState == (int)State.NORMAL && currentState != newState) {
						modelTransform.localScale = new Vector3 (1f, 1f, 1f);

						charCont.radius = 0.5f;
						charCont.height = 0.5f;
				}
		}

//	void OnTriggerEnter (Collider other) {
//		//Debug.Log (other.transform.tag);
//		//int length = other.transform.GetComponent<SphereCollider> ();
//		if (other.transform.tag != "Floor" && other.transform.tag != "Player" && other.transform.tag != "EnemyVisionCollider") {
//			Debug.Log (other.transform.tag);
//			canChange = false;
//
//		} 
////		else {
////
////			canChange = false;
////
////		}
//	}
//	void OnTriggerExit (Collider other) {
//		if (other.transform.tag != "Floor" && other.transform.tag != "Player" && other.transform.tag != "EnemyVisionCollider") {
//						Debug.Log ("Chevck");
//						canChange = true;
//				}
//	}

		void OnTriggerEnter (Collider other)
		{
//		if (other.transform.tag != "Floor" && other.transform.tag != "Player" && other.transform.tag != "EnemyVisionCollider") {
//
//			Debug.Log ("1 " + other.transform.tag);

				if (other.transform.tag == "Wall" && other.transform.tag != "EnemyVisionCollider") {
						canChangeWall = false;
						Debug.Log ("Wall - " + other.transform.tag + " - " + canChangeWall);
				}
				if (other.transform.tag == "Enemy" && other.transform.tag != "EnemyVisionCollider") {
						canChangeEnemy = false;
						Debug.Log ("Enemy - " + other.transform.tag + " - " + canChangeEnemy);
				}

		}

		void OnTriggerExit (Collider other)
		{

				if (other.transform.tag == "Wall" && other.transform.tag != "EnemyVisionCollider") {
						canChangeWall = true;
						Debug.Log ("Wall - " + other.transform.tag + " - " + canChangeWall);
				}
				if (other.transform.tag == "Enemy" && other.transform.tag != "EnemyVisionCollider") {
						canChangeEnemy = true;
						Debug.Log ("Enemy - " + other.transform.tag + " - " + canChangeEnemy);
				}
		}
}