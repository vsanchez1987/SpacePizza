using UnityEngine;
using System.Collections;


public class heathpickup : MonoBehaviour {

	HealthBar healthBar;
	public GameObject player;

	//HealthBar healthBar = (HealthBar)player.GetComponent(typeof(HealthBar));

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
		Debug.Log("trigger");
		if (other.gameObject.tag == "Player")
		{
			Destroy(this.gameObject);
			//TempDestroyObject(this.gameObject,1.0f);

			healthBar = (HealthBar)player.GetComponent(typeof(HealthBar));

			healthBar.playerHealth += 10;

			Debug.Log("picked up health");
		}
	}
		

}
