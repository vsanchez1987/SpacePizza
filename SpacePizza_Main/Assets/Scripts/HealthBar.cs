using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	public float playerHealth;
	public Texture2D SliceOfLife;
	public Texture2D BackgroundBase;
	public Material mat;


	public float x = 0;
	public float y = 0;
	public float height;
	public float healthy;
	public float width;

	void Start()
	{
		playerHealth = 100;
	}

	void OnGUI()
	{

		Rect background = new Rect (x, y, width + 5, height + 5);
		GUI.DrawTexture (background, BackgroundBase);

		if (Event.current.type.Equals (EventType.Repaint)) 
		{
			Rect box = new Rect (x, y, width, height);
			Graphics.DrawTexture (box,SliceOfLife, mat);
		}

	}

	void Update()
	{
	  healthy = 0.99f - (playerHealth / 100);

		if (healthy <= 0) 
		{
			healthy = 0.1f;
		}

		mat.SetFloat ("_Cutoff",healthy);



	 	if (playerHealth <= 0) 
		{
			Application.LoadLevel("test_01");

		}
	}
	
}
