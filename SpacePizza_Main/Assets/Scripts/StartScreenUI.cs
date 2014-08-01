using UnityEngine;
using System.Collections;

public class StartScreenUI : MonoBehaviour 
{

	//private bool created = false;

	public Texture2D mainTitle, 
					 startButton,
					 startButtonOver;

	// private string levelToLoadWhenClickedPlay = "Order UP";

	private string clicked = "";

	public float WidthScale = 1.0f;
	public float HeightScale = 1.0f;
	public float OffsetX = 0.0f;
	public float OffsetY = 0.0f;

	private float Width;
	private float Height;

	public float singleX = 0.0f;
	public float singleY = 0.0f;

	private Rect WindowRect;

	void OnGUI()
	{

		Debug.Log ("Width: " + Width);
		Debug.Log ("Height: " + Height);

	//	GUI.BeginGroup(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 300, 800, 600), mainTitle);
		
		WindowRect = new Rect (Screen.width/2 + OffsetX, Screen.height/2 + OffsetY, Width, Height);

		if (mainTitle != null)
		{
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), mainTitle);
		}

		if(clicked == "")
		{
			WindowRect = GUI.Window(0,WindowRect, menuFunc, "Main Menu");


		}
		else if (clicked == "Order Up")
		{
			GUI.Button (new Rect(Screen.width/2 - 350 + singleX, 
			                     Screen.height/2 + singleY,Width, Height),"Order Up");
			            
		}
		/*
		else if (clicked == "Quit Game")
		{
			GUI.Button (new Rect(Screen.width/2 - 350 + singleX, 
			                     Screen.height/2 + singleY,Width, Height),"Quit Game");
			
		}
		*/
		
		//	GUI.EndGroup ();
	}

		private void menuFunc(int id)
		{
			if(GUILayout.Button("Order Up"))
			   {
				 Application.LoadLevel("UserInterfaceInGame");
			   }
			if (GUILayout.Button("Quit Game")) 
			   {
			Application.Quit();
			   }
			
		}


	
	private void Update()
	{
		Width = Screen.width / 2 * 0.2f * WidthScale;
		Height = Screen.height / 2 * 0.5f * HeightScale;



	}
}
