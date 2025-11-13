using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpatialSys.UnitySDK;
using UnityEngine.UI;
using TMPro;

public class Reloader : MonoBehaviour
{
    public GameObject activeScene;


    [Header("Level Settings")]
	public GameObject levelText;
    public GameObject instructionText;
    public Rooms[] rooms;
	public static int currentArea = 1;
   

    private GameObject levelParent;
    private GameObject levelPrefab;

	private GameObject sceneObjectPrefab;
	private static Reloader instance;


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

        ResetAvatar();
		ResetRigidbodies();

		currentArea = 1;

	}

    public void ResetArea()
    {
        Debug.Log("Debug reset area");

        instance.levelParent = activeScene.transform.GetChild(0).gameObject;
        instance.levelPrefab = sceneObjectPrefab.transform.GetChild(0).gameObject;


		Destroy(instance.levelParent.transform.GetChild(currentArea - 1).gameObject);
		GameObject levelChild = Instantiate(levelPrefab.transform.GetChild(currentArea - 1).gameObject, instance.levelParent.transform);
		levelChild.transform.SetSiblingIndex(currentArea - 1);

		Debug.Log("Level child: " +  levelChild);
        
	}


    void ResetAvatar()
    {
		SpatialBridge.actorService.localActor.avatar.Respawn();
		SpatialBridge.actorService.localActor.avatar.EquipAttachment(AssetType.EmbeddedAsset, "RespawnVFX");
	}

    void ResetRigidbodies()
    {
        Rigidbody[] rigidbodies = instance.activeScene.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rb in rigidbodies)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = false;
        }

    }

    public void SetCurrentArea(int areaNumber)
    {
        Debug.Log("debug set current area: " + areaNumber);
        currentArea = areaNumber;
        //levelText.GetComponent<TMP_Text>().text = "Room " + areaNumber.ToString();
        //instructionText.GetComponent<TMP_Text>().text = levelInstructions[areaNumber - 1];

        if (rooms.Length > 0)
        {
			levelText.GetComponent<TMP_Text>().text = rooms[areaNumber - 1].roomName;
			instructionText.GetComponent<TMP_Text>().text = rooms[areaNumber - 1].instructions;
		}
        else
        {
            Debug.LogError("No rooms assigned in reloader");
        }
		
	}
}
