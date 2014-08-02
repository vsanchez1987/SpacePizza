using UnityEngine;
using System.Collections;

public class item_rotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float rotateY = 6.0f * 10.0f * Time.deltaTime;
		transform.Rotate (0, rotateY, 0);
	
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log("trigger");
		if (other.gameObject.tag == "Player")
		{
			Destroy(this.gameObject);
			//TempDestroyObject(this.gameObject,1.0f);
			Debug.Log("picked up health");
		}
	}
}
