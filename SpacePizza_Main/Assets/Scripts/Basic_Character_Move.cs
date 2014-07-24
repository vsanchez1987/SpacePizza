using UnityEngine;
using System.Collections;

public class Basic_Character_Move : MonoBehaviour {

	public float speed = 20.0f;

	private Vector3 moveDirection = Vector3.zero;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 x = Input.GetAxis ("Horizontal") * transform.right * Time.deltaTime * speed;
		Vector3 z = Input.GetAxis ("Vertical") * transform.forward * Time.deltaTime * speed;

		transform.Translate (x + z);
	
	}
}
