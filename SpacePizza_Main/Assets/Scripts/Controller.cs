using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	
	
	
	
	
	public float speed = 10.0F;
	public float jumpSpeed = 25.0F;
	public float gravity = 60.0F;
	private Vector3 moveDirection = Vector3.zero;

	private bool grounded = true;


	void Update() {
		CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded) {

			grounded = true;

			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0/*Input.GetAxis("Vertical")*/);
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;
			
		}


		else{

			if(Input.GetKeyDown("d"))
			{

				moveDirection = transform.TransformDirection(new Vector3(5,0,0));

			}


			if(Input.GetKeyDown("a"))
			{
				
				moveDirection = transform.TransformDirection(new Vector3(-5,0,0));
				
			}


		}

		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
	
	
	
	
	
	
}