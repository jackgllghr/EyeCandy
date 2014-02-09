using UnityEngine;
using System.Collections;

public class PlayerRotation : MonoBehaviour {
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	public float rotateSpeed = 15.0f;
	
	private Vector3 moveDirection = Vector3.zero;
	public CharacterController controller;

	void Start() {
		controller = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
	}
	void Update() {
		//CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 90, Input.GetAxis("Vertical"));
			//moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			//if (Input.GetButton("Jump"))
			//	moveDirection.y = jumpSpeed;
			
		}
		if(moveDirection.sqrMagnitude > 0.01f ){
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection),Time.deltaTime * rotateSpeed);
		}
		//moveDirection.y -= gravity * Time.deltaTime;
		//controller.Move(moveDirection * Time.deltaTime);
		
	}
}