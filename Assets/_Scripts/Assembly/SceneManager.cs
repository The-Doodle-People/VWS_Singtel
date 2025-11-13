using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpatialSys.UnitySDK;


public class SceneManager : MonoBehaviour
{
    public GameObject activeScene;
    private GameObject sceneObjectPrefab;
    private static SceneManager instance;

    public GameObject entrancePoint;
    private IInventoryItem inventoryItem;

    public Items[] items;

    // Start is called before the first frame update
    void Start()
    {
		if (instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;
        activeScene.SetActive(false);
        sceneObjectPrefab = Instantiate(activeScene);
        activeScene.SetActive(true);
    }

    public void Restart()
    {
        //reset inventory instance
        if(instance == null)
        {
            Debug.LogError("Scene instance is null");
            return;
        }

        Destroy(instance.activeScene);
        instance.activeScene = Instantiate(instance.sceneObjectPrefab);
        instance.activeScene.SetActive(true);

        //reset others
        ResetAvatar();
        ResetInventory();
        
	}

    void ResetAvatar()
    {
		//reset avatar position
		SpatialBridge.actorService.localActor.avatar.SetPositionRotation(entrancePoint.transform.position, entrancePoint.transform.rotation);
		Debug.Log(SpatialBridge.actorService.localActor.avatar.position);
	}

    void ResetInventory()
    {
		//SpatialBridge.inventoryService.DeleteInventoryItemRequest("xxh4io7d5nhdb27ydszkv");		
		//inventoryItem.Use();

        foreach(Items item in items)
        {
			Debug.Log("SM item: " + item.itemName);

			//bool isOwned = SpatialBridge.inventoryService.items.ContainsKey(itemId);
			if (SpatialBridge.inventoryService.items.ContainsKey(item.itemId))
            {
                Debug.Log("SM found item: " + item.itemName);
				SpatialBridge.inventoryService.DeleteItem(item.itemId);
			}
            else
            {
				Debug.Log("SM item not found: " + item.itemName + ", " + item.itemId);
			}
        }
	}
}
