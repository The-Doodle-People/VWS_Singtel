using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

using SpatialSys.UnitySDK;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Items thisItem;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("pick up spawned: " + thisItem);
		/*
        UnityEngine.Component[] components = this.GetComponents<UnityEngine.Component>();

        foreach (var component in components)
        {
            Debug.Log(component);   
        }
        */

		Collider[] colliders = GetComponents<Collider>();

        foreach(var collider in colliders)
        {
			Debug.Log("collider position: " + collider.transform.position);
			Debug.Log("collider enabled: " + collider.enabled);
			Debug.Log("collider position: " + collider.isTrigger);
		}
		
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("pick up on trigger enter" + collider.gameObject.name);
        if(collider.gameObject.name == "LocalAvatarView")
        {
            //Debug.Log("pick up runs " + thisItem);
            SpatialBridge.inventoryService.AddItem(thisItem.itemId);
            Debug.Log("Picked up: " + thisItem.itemName + ", id: " + thisItem.itemId);
			Destroy(gameObject);

		}
    }
}
