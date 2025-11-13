using SpatialSys.UnitySDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyUpFinish : MonoBehaviour
{
    public GameObject finishVfx;
    
    AudioSource audioSource;

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}
	public void TriggerEnter()
    {
        finishVfx.SetActive(true);
        audioSource.Play();

		if(SpatialBridge.questService.currentQuest != null)
		{
			if (OnlyUpTimeManager.stoppedTimeBefore)
			{
				//normal badge
				SpatialBridge.questService.currentQuest.AddBadgeReward("mkgoou7w8bhf6wup5lagr");
			}
			else
			{
				//non time stop badge
				SpatialBridge.questService.currentQuest.AddBadgeReward("igg4tgh78798w7idkzhhm");
			}

			SpatialBridge.questService.currentQuest.Complete();
		}
		
		

	}
}
