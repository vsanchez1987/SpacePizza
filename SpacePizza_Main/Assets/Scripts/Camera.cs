using UnityEngine;
using System.Collections;

/*
 * screen resolution is 800 x 600
 */

public class Camera : MonoBehaviour {

	// how far the camera can follow the character on the x and y axis
	public float xMargin = 1f;  // Distance the player can move before the camera follows on the x
	public float yMargin = 1f;  // Distance the player can move before the camera follows on the y

	// how fast the camera catches up to the character
	public float xSmooth = 8f;  // how smooth the camera catches up with the player on the x axis
	public float ySmooth = 8f;  // how smooth the camera catches up with the player on the y axis

	public Vector3 maxXAndY;  // max x and y co-ordinates that the camera can have
	public Vector3 minXAndY; // min x and y co-ordinates that the camera can have

	private Transform player;  // Reference to the player's transform

	void Awake()
	{
		// setting up the reference for the player object
		player = GameObject.FindGameObjectWithTag("Player").transform;	

	}

	bool CheckXMargin()
	{
		// Returns true if the distance between the camera and the player in the x axis is greater than the x margin
		return Mathf.Abs (transform.position.x - player.position.x) > xMargin;
	}

	bool CheckYMargin()
	{
		// Returns true if the distance between the camera and the player in the y axis is greater than the x margin
		return Mathf.Abs(transform.position.y - player.position.y) > yMargin;
	}

	void FixedUpdate()
	{
		 TrackPlayer ();
	}

	void TrackPlayer()
	{
		// By default the target x and y coordinates of the camera are it's current x and y co-ordiantes 
		float targetX = transform.position.x;
		float targetY = transform.position.y; 

		// if the player has moved beyond the X margin....
		if(CheckXMargin())
		{
			targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.deltaTime); 
		}

		if (CheckYMargin()) 
		{
			targetY = Mathf.Lerp(transform.position.y, player.position.y, ySmooth * Time.deltaTime);
		}

		targetX = Mathf.Clamp (targetX, minXAndY.x, maxXAndY.x);
		targetY = Mathf.Clamp (targetY, minXAndY.y, maxXAndY.y);


		transform.position = new Vector3 (targetX, targetY, transform.position.z);



	}


}