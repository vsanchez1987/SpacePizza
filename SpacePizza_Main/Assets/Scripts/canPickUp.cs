using UnityEngine;
using System.Collections;

public class canPickUp : MonoBehaviour {


	
	IEnumerator TempDestroyObject(GameObject obj,float respawnTime)
	{
		Debug.Log("pausing");
		obj.renderer.enabled=false;
		obj.collider.enabled=false;
		yield return new WaitForSeconds(respawnTime);
		obj.renderer.enabled=true;
		obj.collider.enabled=true;
		Debug.Log("reappear");
		
	}
	
	/*void OnCollisionEnter(Collision collision) {
		
		if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "enemy")
		{
			TempDestroyObject(this.gameObject,1.0f);
			Debug.Log("picked up health");
		}
	}*/
	
	
	void OnTriggerEnter(Collider other) {
		Debug.Log("trigger");
		if (other.gameObject.tag == "Player")
		{
			Destroy(this.gameObject);
			//TempDestroyObject(this.gameObject,1.0f);
			
			//+= 1;
			Debug.Log("picked up health");
		}
	}
}
