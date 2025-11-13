using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyUpCheckpointLevel : OnlyUpCheckpoint
{
	public GameObject starfill;
	public int level;
	public void LevelCheckpoint()
	{
		Debug.Log("Level checkpoint");
		if (tutorialPanel != null && !activated)
		{
			
			tutorialPanel.SetActive(true);
			
		}

		if (starfill != null)
		{
			starfill.SetActive(true);
			OnlyUpLevelManager.level = level;
			SetCheckpoint();
		}
	}
}
