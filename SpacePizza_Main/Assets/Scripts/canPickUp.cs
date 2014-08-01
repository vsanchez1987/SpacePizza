using UnityEngine;
using System.Collections;

public class canPickUp : MonoBehaviour {

	canInventory canInventory;
	GameObject player;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
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
		Debug.Log("Trigger");
		if (other.gameObject.tag == "Player")
		{
			Destroy(this.gameObject);
			//TempDestroyObject(this.gameObject,1.0f);

			canInventory = (canInventory)player.GetComponent(typeof(canInventory));

			canInventory.HMCans += 1;


			Debug.Log("picked up can");
		}
	}
}
