using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpatialSys.UnitySDK;
using System;

public class OnlyUpTimeManager : MonoBehaviour
{
	public float abilityTime = 5.0f;
	public float cooldownTime = 5.0f;

	private static bool timePaused = false;
	bool onCooldown = false;

	public static event Action PauseTime;
	public static event Action ResumeTime;
	public static bool stoppedTimeBefore = false;

	public GameObject UITimeManager;

	Coroutine abilityTimer;
	Coroutine cooldownTimer;

	IAvatar avatar;


	void Start()
	{
		avatar = SpatialBridge.actorService.localActor.avatar;
		timePaused = false;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{		
			//if time is not paused
			if (!timePaused && !onCooldown)
			{
				Pause();
				Debug.Log("ON COOLDOWN SHOULD BE FALSE: " + onCooldown);
			}
			else
			{
				Resume();
			}

			Debug.Log("Debug keydown E");
		}
	}

	IEnumerator AbilityTimer()
	{
		Debug.Log("Debug ability start");
		yield return new WaitForSeconds(abilityTime);
		Debug.Log("Debug ability timer: " + abilityTime);

		//resume time
		Resume();
	}

	
	IEnumerator CooldownTimer()
	{
		/*
		Debug.Log("Debug cooldown start");
		yield return new WaitForSeconds(cooldownTime);
		Debug.Log("Debug cooldown over");
		onCooldown = false;
		*/
		onCooldown = true;
		Debug.Log("ON COOLDOWN SET TRUE: " + onCooldown);

		float remainingTime = cooldownTime;
		UITimeManager.GetComponent<OnlyUpUIManager>().SetCooldownTimer(((int)Math.Round(remainingTime)).ToString());

		while (remainingTime > 0)
		{
			
			yield return new WaitForSeconds(1f);
			
			remainingTime -= 1f;
			UITimeManager.GetComponent<OnlyUpUIManager>().SetCooldownTimer(((int)Math.Round(remainingTime)).ToString());
		}

		onCooldown = false;
		Debug.Log("ON COOLDOWN SET FALSE: " + onCooldown);
		UITimeManager.GetComponent<OnlyUpUIManager>().SetCooldownTimer("");

	}
	

	void Pause()
	{
		timePaused = true;

		//start the ability timer and the cooldown timer
		abilityTimer = StartCoroutine(AbilityTimer());

		avatar.EquipAttachment(AssetType.EmbeddedAsset, "Aura");
		OnlyUpTimeManager.stoppedTimeBefore = true;
		PauseTime?.Invoke();
	}

	void Resume()
	{
		timePaused = false;
		

		//stop ability timer
		StopCoroutine(abilityTimer);
		
		if(!onCooldown)
		{
			cooldownTimer = StartCoroutine(CooldownTimer());
		}

		avatar.ClearAttachments();
		ResumeTime?.Invoke();
	}
}
