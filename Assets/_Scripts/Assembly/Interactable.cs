using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject collideVFX;
    public GameObject floatVFX;
    public GameObject trailVFX;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerEnter()
    {
        PlayerManager.SetTriggerObject(this.gameObject);
    }

    public void TriggerExit()
    {
		PlayerManager.SetTriggerObject(null);
	}

    public void Interact()
    {
        //if not holding object, set object
        if (PlayerManager.GetObject() == null)
        {
            PlayerManager.SetObject(this.gameObject);
            floatVFX.SetActive(true);
            trailVFX.SetActive(false);
		}
        //else put down object and set to normal
        else
        {
			PlayerManager.SetObject(null);
			floatVFX.SetActive(false);
			trailVFX.SetActive(true);
		}

    }

	private void OnCollisionEnter(Collision collision)
	{
        if(!collision.gameObject.name.Contains("Tile"))
        {
			ContactPoint contactPoint = collision.contacts[0];
			Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contactPoint.normal);
			Vector3 position = contactPoint.point;
			Instantiate(collideVFX, position, rotation);
		}
		

        //Debug.Log("debug collide: " + collision.gameObject);
	}
}
