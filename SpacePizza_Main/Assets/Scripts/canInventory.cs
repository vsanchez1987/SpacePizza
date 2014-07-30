using UnityEngine;
using System.Collections;

public class canInventory : MonoBehaviour {


	public int HMCans;

	// Cans textures
	public Texture2D cans;
	public Texture2D cansCase;
	
	//public float canPosX = 143f;
	//public float canPosY = 23f;
	
	//public float canWidth = 42f;
	//public float canHeight = 42f;
	
	public float backCaseX = 131.5f;
	public float backCaseY = 14f;

	public float backWidth = 128f;
	public float backHeight = 128f;

	//public float canPosX, canPosY, canWidth, canHeight;

	private shooting shooting;

	// public canPickUp canPickUp;


	void Start()
	{
		HMCans = 0;

	}

	public void indiCan(float canPosX, float canPosY, float canWidth, float canHeight, Texture2D cans)
	{
		Rect sodaCan = new Rect(canPosX, canPosY, canWidth, canHeight);
		GUI.DrawTexture (sodaCan, cans);
	}

	void OnGUI()
	{
		Rect backCase = new Rect (backCaseX, backCaseY, backWidth, backHeight);
		//Rect indiCan = new Rect (canPosX, canPosY, canWidth, canHeight);

		GUI.DrawTexture (backCase, cansCase);

		//for (int i = HMCans; i <= 6; i++){
			//indiCan(143f, 23f, 42f, 42f, cans);

			if(HMCans == 1 && HMCans <= 6)
			{
				Debug.Log("drawing a can texture");
				indiCan(143f, 23f, 42f, 42f, cans);
			}
		
			else if(HMCans > 1 && HMCans == 2)
			{

			 	indiCan(143f, 23f, 42f, 42f, cans);
				indiCan(183f, 23f, 42f, 42f, cans);
				// GUI.DrawTexture(indiCan(backCaseX + 2), cans);
			}

			else if(HMCans > 1 && HMCans == 3)
			{
				
				indiCan(143f, 23f, 42f, 42f, cans);
				indiCan(143f, 53f, 42f, 42f, cans);
				indiCan(183f, 23f, 42f, 42f, cans);
				// GUI.DrawTexture(indiCan(backCaseX + 2), cans);
			}
			else if(HMCans > 1 && HMCans == 4)
			{
				
				indiCan(143f, 23f, 42f, 42f, cans);
				indiCan(143f, 53f, 42f, 42f, cans);
				indiCan(183f, 23f, 42f, 42f, cans);
				indiCan(183f, 53f, 42f, 42f, cans);
				// GUI.DrawTexture(indiCan(backCaseX + 2), cans);
			}
			else if(HMCans > 1 && HMCans == 5)
			{
				
				indiCan(143f, 23f, 42f, 42f, cans);
				indiCan(143f, 53f, 42f, 42f, cans);
				indiCan(143f, 80f, 42f, 42f, cans);
				indiCan(183f, 23f, 42f, 42f, cans);
				indiCan(183f, 53f, 42f, 42f, cans);
				// GUI.DrawTexture(indiCan(backCaseX + 2), cans);
			}
			else if(HMCans > 1 && HMCans == 6)
			{
				indiCan(143f, 23f, 42f, 42f, cans);
				indiCan(143f, 53f, 42f, 42f, cans);
				indiCan(143f, 80f, 42f, 42f, cans);
				indiCan(183f, 23f, 42f, 42f, cans);
				indiCan(183f, 53f, 42f, 42f, cans);
				indiCan(183f, 80f, 42f, 42f, cans);


				// GUI.DrawTexture(indiCan(backCaseX + 2), cans);
			}
			else if(HMCans < 1)
			{
				HMCans = 0;
			}

	//	}
			
		// GUI.DrawTexture (indiCan, cans);

	}

}
