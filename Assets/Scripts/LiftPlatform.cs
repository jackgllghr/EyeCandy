using UnityEngine;
using System.Collections;

public class LiftPlatform : MonoBehaviour {

	public bool moveUp = true;
	public bool inMotion = false; 
	public Transform liftTop, liftBottom;
	public float speed;
	private Player player;

	// Use this for initialization
	void Start () {
		liftTop = GameObject.Find("LiftTrigger").transform;//Vector3(transform.position.x, GameObject.Find("LiftTrigger").transform.localScale.y, transform.position.z);
		liftBottom = transform;
	}


	// Update is called once per frame
	void Update () {
		if (inMotion) {
			float step = speed * Time.deltaTime;
			if(moveUp)
			{
				Debug.Log("up");
				player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
				player.transform.position += new Vector3(0.0f,0.1f,0.0f);
				transform.position += new Vector3(0.0f,0.1f,0.0f);

				//Vector3.Lerp(transform.position, liftTop.position, step);
				//transform.position = Vector3.MoveTowards(transform.position, liftTop.position, step);
				//Debug.Log(transform.position);
			}
		}
	}
}
