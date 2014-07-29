using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	/** 
	 * I have added the can grenade into this health bar script to keep it in one file
	 *
	 *
	*/

	public float playerHealth;
	public Texture3D SliceOfLife;
	public Texture2D RedBar;
	public Texture2D BackgroundBase;

	// Cans textures
	public Texture2D cans;
	public Texture2D cansCase;

	public float canPosX;
	public float canPosY;

	public float canWidth;
	public float canHeight;

	public float backCaseX;
	public float backCaseY;

	public Material mat;

	// sets the positions of the UI elements
	public float x = 0;
	public float y = 0;
	public float height = 60;
	public float healthy = 60;
	public float width;

	// I am using this to hold how many cans we have drawn on the screen.

	public heathpickup heathpickup;
	private shooting shooting;
//	public int HMCans = heathpickup.canPickUp;




	void Start()
	{
		playerHealth = 100;
	}

	void OnGUI()
	{
		// the rect will create the pizza pan that the slices of life are on
		Rect background = new Rect (x, y, width + 5, height + 5);
		// this will draw the texture of the background base.
		GUI.DrawTexture (background, BackgroundBase);

		Rect backCase = new Rect (backCaseX, backCaseY, width, height);
		Rect indiCan = new Rect (canPosX, canPosY, canWidth, canHeight);
		GUI.DrawTexture (backCase, cansCase);

		//HMCans += heathpickup.GetComponent<heathpickup> ().canPickUp;
		/*

		if(HMCans == 1 && HMCans <= 4)
		{
			Debug.Log("drawing a can texture");
			GUI.DrawTexture (indiCan, cans);
		}
*/

	//	GUI.DrawTexture (indiCan, cans);



		// condition to check for a repaint and it draws the rect and the helth bar material
		if (Event.current.type.Equals (EventType.Repaint)) 
		{
			Rect box = new Rect (x, y, width, height);
			Graphics.DrawTexture (box,SliceOfLife, mat);
		}

	}

	void Update()
	{
		// calculates the health of the player with the size of the health bar material. 
	  healthy = 0.99f - (playerHealth / 100);

		if (healthy <= 0) 
		{
			healthy = 0.1f;
		}

		// changes the size of the material using the Alpha cutoff
		mat.SetFloat ("_Cutoff", healthy);	


		// once the players health reaches 0 then a new scene will start. signifying the players death.	
	 	if (playerHealth <= 0) 
		{
			Application.LoadLevel("test_01");

		}
	}
	
}
