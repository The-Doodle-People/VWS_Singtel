using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsDown : MonoBehaviour
{
	public GameObject door;
	public GameObject confetti;
	public bool useTriggerExit = true;

	Animator animator;
	GameObject gameObj ;
	
	// Start is called before the first frame update
	void Start()
    {                            
        animator = door.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {	
		if(gameObj)
		{
			animator.SetBool("Down", true);
			confetti.SetActive(true);
		}
		else
		{
			animator.SetBool("Down", false);
			confetti.SetActive(false);
		}
    }

	void OnTriggerEnter(Collider collider)
	{
		Debug.Log("trigger enter: " + collider.gameObject.name);
		if (collider.gameObject.GetComponent<Interactable>())
		{
			gameObj = collider.gameObject;
			AdditionalEnter();
		}
	}

	void OnTriggerExit(Collider collider)
	{
		if (useTriggerExit)
		{

			Debug.Log("trigger exit: " + collider.gameObject.name);
			if (collider.gameObject.GetComponent<Interactable>())
			{
				gameObj = null;
				Debug.Log("Trigger set obj null");
				AdditionalExit();
			}
		}
		
	}

	protected virtual void AdditionalEnter()
	{

	}

	protected virtual void AdditionalExit()
	{

	}

}
