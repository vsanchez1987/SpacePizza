using UnityEngine;
using System.Collections;

public class StartScreenUI : MonoBehaviour {

	private bool created = false;

	public Texture2D mainTitle;
	public Texture2D startButton;
	public Texture2D startButtonOver;

	public float hght;
	public float wdth;

	public float singleX = 0.0f;
	public float singleY = 0.0f;


	void OnGUI()
	{
		if (mainTitle != null)
		{
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), mainTitle);
		}
		if (!created)
		{
			if(GUI.Button(new Rect(Screen.width/2 - 350 + singleX, Screen.height/2 + singleY,wdth, hght),"Order Up"));
			{
				Application.LoadLevel("UserInterfaceInGame");
					created = true;
			}
		}
	}


}
