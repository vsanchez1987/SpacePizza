/*
using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {
	
	float health;
	Texture2D texture1;
	Material mat;
	Texture2D texture2;
	Material mat2;
	float x = 0;
	float y = 0;
	float w;
	float h;
	void  Start (){
		health = 100;
	}
	void  OnGUI (){
		if(Event.current.type.Equals(EventType.Repaint)){ //Is the game being drawn?
			Rect box = new Rect(x, y, w, h);
			Graphics.DrawTexture(box, texture1, mat);
			
		}
		
	}
	void  Update (){
		float healthy = 0.9 -(health/100);
		if(healthy <= 0){
			healthy = 0.1f;
		}
		mat.SetFloat("_Cutoff", healthy);
	}
	
}
*/