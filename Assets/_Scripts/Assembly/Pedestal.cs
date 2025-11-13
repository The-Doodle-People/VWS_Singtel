using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestal : MonoBehaviour
{
	
	protected GameObject gameObj;

	// Start is called before the first frame update
	void Start()
	{
		//animator = gameObject.GetComponent<Animator>();
	}

	// Update is called once per frame
	protected virtual void Update()
	{
		
		if (gameObj)
		{
			Debug.Log("base gameobj");
		}
		
		
	}

	void OnTriggerEnter(Collider collider)
	{
		Debug.Log("trigger enter: " + collider.gameObject.name);
		if (collider.gameObject.GetComponent<Interactable>())
		{
			gameObj = collider.gameObject;
		}
	}

	void OnTriggerExit(Collider collider)
	{
		Debug.Log("trigger exit: " + collider.gameObject.name);
		if (collider.gameObject.GetComponent<Interactable>())
		{
			gameObj = null;
		}
	}




	protected virtual void Activated()
	{
	
	}

}
