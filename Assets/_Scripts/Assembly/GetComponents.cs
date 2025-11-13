using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetComponents : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{

		Collider collider = GetComponent<Collider>();
		Debug.Log("collider position: " + collider.transform.position);
		Debug.Log("collider enabled: " + collider.enabled);
		Debug.Log("collider position: " + collider.isTrigger);
	}

	private void OnTriggerEnter(Collider collider)
	{
		
		Debug.Log("trigger enter");
		//this.gameObject.SetActive(false);
	}

	void Update()
	{
		Debug.Log("box: " + this.transform.position);
	}
}
