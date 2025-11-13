using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OnlyUpCheckpoint : MonoBehaviour
{
	Material activatedMat;
	protected bool activated = false;
	AudioSource audioSource;


	public GameObject tutorialPanel;
	public int checkpointNumber;
	public static event Action <int> OnCheckpointActivated;

	public GameObject deactivatedObj;
	public GameObject activatedObj;
	public GameObject vfx;

	

	protected void Start()
	{
		audioSource = GetComponent<AudioSource>();
		OnlyUpLevelManager.OnGameReset += ResetCheckpoint;
	}
	public void SetCheckpoint()
	{
		if (!activated)
		{
			if (activatedObj != null)
			{
				activatedObj.SetActive(true);
				deactivatedObj.SetActive(false);
				vfx.SetActive(true);
			}
			

			OnlyUpSceneManager.lastCheckpoint = this.gameObject;
			activated = true;
			audioSource.Play();
			OnCheckpointActivated?.Invoke(checkpointNumber);
		}
		
	}

	void ResetCheckpoint()
	{
		Debug.Log("Debug reset checkpoint");

		if (activatedObj != null)
		{
			activatedObj.SetActive(false);
			deactivatedObj.SetActive(true);
			vfx.SetActive(false);
		}
		activated = false;
		
	}


}
