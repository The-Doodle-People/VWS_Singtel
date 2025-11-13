using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using SpatialSys.UnitySDK;



public class BrokenCollider : MonoBehaviour
{
	[Header("UI Components")]
	public GameObject textPanel;
	public Text title;
	public string titleText;
	public Button fixButton;
	public GameObject imageParent;

	[Header("GameObjects to Fix")]
	public GameObject brokenObj;
	public GameObject fixedObj;

	[Header("Arrays")]
	public Items[] itemsArray;
	//public string[] itemsNeeded;
	public Items[] itemsRequired;
	public int[] amtRequired;

	bool inRange = false;

	// Update is called once per frame
	void Update()
	{
		if (inRange && Input.GetKeyDown(KeyCode.F))
		{
			//set up UI
			SetIcons();
			textPanel.SetActive(!textPanel.activeSelf);
			title.text = titleText;

			//add fix function to button
			
			fixButton.onClick.AddListener(Fix);
		}
	}

	void SetIcons()
	{
		for(int i = 0; i < itemsRequired.Length; i++)
		{
			string currentItem = itemsRequired[i].itemName;

			switch (currentItem)
			{
				case "Battery":
					imageParent.transform.GetChild(i).GetChild(0).gameObject.GetComponent<Image>().sprite = itemsArray[0].icon;
					//Debug.Log("Battery");
					break;
				case "MetalPlank":
					imageParent.transform.GetChild(i).GetChild(0).gameObject.GetComponent<Image>().sprite = itemsArray[1].icon;
					//Debug.Log("MetalPlank");
					break;
				case "Glass":
					imageParent.transform.GetChild(i).GetChild(0).gameObject.GetComponent<Image>().sprite = itemsArray[2].icon;
					//Debug.Log("MetalPlank");
					break;
				case "Screw":
					imageParent.transform.GetChild(i).GetChild(0).gameObject.GetComponent<Image>().sprite = itemsArray[3].icon;
					//Debug.Log("MetalPlank");
					break;
				default:
					Debug.Log("Run default");
					break;
			}

		}
	}

	void OnTriggerEnter(Collider collider)
	{
		inRange = true;
	}

	void OnTriggerExit(Collider collider)
	{
		inRange = false;
	}

	public void Fix()
	{
		if(inRange)
		{
			Debug.Log("Fix Running Debug");
			//set the fixed object
			brokenObj.SetActive(false);
			fixedObj.SetActive(true);

			
			for (int i = 0; i< itemsRequired.Length; i++)
			{
				UseItem(itemsRequired[i].itemId, amtRequired[i]);
				
			}
			
		}
		fixButton.onClick.RemoveListener(Fix);
	}

	public void UseItem(string itemId, int amt)
	{
		Debug.Log("debug itemid: " + itemId);
		
		if (CheckForItem(itemId))
		{
			//Debug.Log("Fix ItemUse Debug: " );
			Debug.Log("button check runs debug");
			IInventoryItem item = SpatialBridge.inventoryService.items[itemId];

			
			for (int i = 0; i< amt; i++)
			{
				Debug.Log("USED RUN DEBUG: " + itemId);
				item.Use();
			}
			
			
		}
		
	}

	bool CheckForItem(string itemID)
	{
		Debug.Log("debug check item");
		// Check if the specified item ID exists in the backpack
		return SpatialBridge.inventoryService.items.ContainsKey(itemID);

	}
}
