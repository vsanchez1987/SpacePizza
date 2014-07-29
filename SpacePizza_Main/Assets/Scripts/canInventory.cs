using UnityEngine;
using System.Collections;

public class canInventory : MonoBehaviour {


	public int HMCans;

	// Cans textures
	public Texture2D cans;
	public Texture2D cansCase;
	
	public float canPosX;
	public float canPosY;
	
	public float canWidth;
	public float canHeight;
	
	public float backCaseX;
	public float backCaseY;

	public float width;
	public float height;
	
	private shooting shooting;

	public canPickUp canPickUp;


	void Start()
	{
		HMCans = 0;

	}


	void OnGUI()
	{
		Rect backCase = new Rect (backCaseX, backCaseY, width, height);
		Rect indiCan = new Rect (canPosX, canPosY, canWidth, canHeight);
		GUI.DrawTexture (backCase, cansCase);


		if(HMCans == 1 && HMCans <= 4)
		{
			Debug.Log("drawing a can texture");
			GUI.DrawTexture (indiCan, cans);
		}
	
			
		GUI.DrawTexture (indiCan, cans);

	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
