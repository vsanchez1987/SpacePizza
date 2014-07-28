using UnityEngine;
using System.Collections;


public class heathpickup : MonoBehaviour {

	public int canPickUp = 0;



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
		if (other.gameObject.tag == "player" || other.gameObject.tag == "enemy")
		{
			//Destroy(this.gameObject);
			//TempDestroyObject(this.gameObject,1.0f);

			canPickUp += 1;
			Debug.Log("picked up health");
		}
	}
		
		// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
