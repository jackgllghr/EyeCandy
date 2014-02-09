using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

		//

		public float speed = 6.0F;
		public float jumpSpeed = 8.0F;
		public float gravity = 20.0F;
		public float rotateSpeed = 15.0f;

		private Vector3 moveDirection = Vector3.zero;
		private CharacterController controller;
		private	NavMeshAgent	navAgent;

		void Start ()
		{
				controller = GetComponent<CharacterController> ();
				navAgent = GetComponent<NavMeshAgent> ();
				navAgent.updatePosition = false;
				navAgent.updateRotation = false;
		}
		void Update ()
		{
				if (controller.isGrounded) {
						moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
						//moveDirection = transform.TransformDirection(moveDirection);
						moveDirection *= speed;
						if (Input.GetButton ("Jump")) {
								//If "heavy" don't jump
								if (GetComponent<SizeChange> ().currentState != 0) {
										moveDirection.y = jumpSpeed;
								}
						}
				}
				/*
		if(moveDirection.sqrMagnitude > 0.01f ){
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection),Time.deltaTime * rotateSpeed);
		}
		*/
				moveDirection.y -= gravity * Time.deltaTime;
				controller.Move (moveDirection * Time.deltaTime);

				//

				//
		}

}