using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpatialSys.UnitySDK;
using UnityEngine.UI;


public class PlayerManager : MonoBehaviour
{

	public float kickForce;

	static float displaceForward = 1.0f;
	static float displaceUp = 1.25f;

    static GameObject gameObjectHold;
	static GameObject gameObjectTrigger;
	IAvatar localAvatar;
	Vector3 avatarForward;
	Vector3 avatarVelocity;

	static bool holding = false;

	// Start is called before the first frame update
	void Start()
    {
		localAvatar = SpatialBridge.actorService.localActor.avatar;
		localAvatar.onColliderHit += HandleColliderHit;
		localAvatar.onLanded += JumpVFX;
		localAvatar.onAvatarLoadComplete += RespawnVFX;

	}

    // Update is called once per frame
    void Update()
    {
		avatarForward = localAvatar.rotation * Vector3.forward;
		avatarVelocity = localAvatar.velocity;

		//pause time
		/*
		if (Input.GetKeyDown(KeyCode.E))
		{
			if (TimeManager.TimePaused)
			{
				TimeManager.TimePaused = false;
				abilitiesPanel.transform.GetChild(0).GetComponent<Image>().color = Color.white;
			}
			else
			{

				TimeManager.TimePaused = true;
				abilitiesPanel.transform.GetChild(0).GetComponent<Image>().color = Color.green;
			}

		}
		*/

		//kick
		if (gameObjectTrigger != null)
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				//Debug.Log("debug press r");
				Kick(avatarForward);
			}

		}
	
		//pickup
		if(holding)
		{
			PickUp();
		}

		ManageVFX();
		
    }

    public static void SetObject(GameObject newGameObjectHold)
    {
		//pick up
		if (gameObjectHold == null)
		{
			gameObjectHold = newGameObjectHold;
			holding = true;
			gameObjectHold.GetComponent<Rigidbody>().isKinematic = true;

			displaceUp = newGameObjectHold.GetComponent<Collider>().bounds.size.y * 1.5f;
			displaceForward = newGameObjectHold.GetComponent<Collider>().bounds.size.x * 1.25f;
			//Debug.Log("displace debug: " + gameObjectHold.GetComponent<Collider>().bounds.size);

			//pickupImg.GetComponent<Image>().sprite.color = Color.green;
		}
		else
		{
			//setting to null / put down
			if(newGameObjectHold == null)
			{
				

				if(!TimeManager.TimePaused)
				{
					gameObjectHold.GetComponent<Rigidbody>().isKinematic = false;
				}

				gameObjectHold = null;
				holding = false;
			}
		}
    }

	public static GameObject GetObject()
	{ 
		return gameObjectHold;
	}

	public static void SetTriggerObject(GameObject newGameObjectTrigger)
	{
		gameObjectTrigger = newGameObjectTrigger;
		//Debug.Log("debug gameObject trigger: " + this.gameObjectTrigger);
	}

	void HandleColliderHit(ControllerColliderHit hit, Vector3 avatarVelocity)
	{
		// Calculate force based on avatar velocity

		if (hit.rigidbody != null)
		{
			float forceMagnitude = avatarVelocity.magnitude * 20.0f; // Adjust the multiplier as needed
			Vector3 forceDirection = hit.moveDirection.normalized;
			Vector3 force = forceDirection * forceMagnitude;
			//Debug.Log("debug force: " +  force);
			hit.rigidbody.AddForce(force);
		}
			
	}


	void PickUp()
	{
		
		//if player is holding the cube
		if(holding)
		{
			//put in front of player
			gameObjectHold.transform.position = localAvatar.position + displaceForward * avatarForward + displaceUp * (localAvatar.rotation * Vector3.up);
			gameObjectHold.transform.rotation = localAvatar.rotation;

		}	
	}

	void Kick(Vector3 avatarForward)
	{
		Debug.Log("debug kick run");
		Vector3 force = avatarForward * kickForce;
		gameObjectTrigger.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
		
	}

	void ManageVFX()
	{
		//Debug.Log("debug walkspeed: " + SpatialBridge.actorService.localActor.avatar.walkSpeed + ", velocity: " + SpatialBridge.actorService.localActor.avatar.velocity);

		//if avatar walks
		if(avatarVelocity.x != 0 || avatarVelocity.z != 0)
		{
			//Debug.Log("debug walk");
			WalkVFX();
		}
		else
		{
			if(localAvatar.IsAttachmentEquipped("WalkVFX"))
			{
				localAvatar.ClearAttachments();
			}
		}

	}
	void WalkVFX()
	{
		localAvatar.EquipAttachment(AssetType.EmbeddedAsset, "WalkVFX");
	}
	void JumpVFX()
	{
		Debug.Log("debug jumpvfx");
		if (localAvatar != null)
		{
			localAvatar.EquipAttachment(AssetType.EmbeddedAsset, "JumpVFX");

			StartCoroutine(WaitForSeconds(1.0f));
		}
		else
		{
			Debug.LogError("No local avatar assigned");
		}
		
	}

	void RespawnVFX()
	{
		//Debug.Log("Debug respawnVFX");
		localAvatar.EquipAttachment(AssetType.EmbeddedAsset, "RespawnVFX");
	}

	IEnumerator WaitForSeconds(float seconds)
	{
		yield return new WaitForSeconds(seconds);

		if (localAvatar.IsAttachmentEquipped("JumpVFX"))
		{
			localAvatar.ClearAttachments();
		}

	}

	void OnDestroy()
	{
		//Debug.Log("debug player manager destroyed");
		localAvatar.onColliderHit -= HandleColliderHit;
		localAvatar.onLanded -= JumpVFX;
	}

}
