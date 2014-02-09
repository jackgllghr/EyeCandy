using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour
{

		GameObject player;
		// Use this for initialization
		void Start ()
		{
				player = GameObject.FindGameObjectWithTag ("Player");

		}
	
		// Update is called once per frame
		void Update ()
		{
				if (player.transform.position.y <= -2) {
						Application.LoadLevel ("WaterTest");
				}
		}
}
