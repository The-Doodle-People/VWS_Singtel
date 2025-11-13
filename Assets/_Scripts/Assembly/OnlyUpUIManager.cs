using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class OnlyUpUIManager : MonoBehaviour
{
	public Sprite defaultTimeImage;
	public Sprite stopTimeImage;
	public GameObject cooldownTimer;

	public GameObject abilitiesPanel;
	public Image[] images;

	Image jumpImg;
	Image runImg;
	Image timeImg;

	// Start is called before the first frame update
	void Start()
    {
		images = abilitiesPanel.GetComponentsInChildren<Image>();
		OnlyUpTimeManager.PauseTime += SetTimeStopImage;
		OnlyUpTimeManager.ResumeTime += SetTimeImage;

		foreach (Image image in images)
		{
			switch (image.name)
			{
				case "JumpImg":
					jumpImg = image;
					break;
				case "RunImg":
					runImg = image;
					break;
				case "TimeImg":
					timeImg = image;
					break;
			}
		}

	}

	private void Update()
	{
		if (Input.GetKey(KeyCode.Space))
		{
			jumpImg.color = Color.green;
		}
		else
		{
			jumpImg.color = Color.white;
		}

		if(Input.GetKey(KeyCode.LeftShift))
		{
			runImg.color = Color.green;
		}
		else
		{
			runImg.color = Color.white;
		}

	}

	void SetTimeImage()
	{
		timeImg.sprite = defaultTimeImage;
		timeImg.color = Color.white;
	}	

	void SetTimeStopImage()
	{
		timeImg.sprite = stopTimeImage;
		timeImg.color = Color.green;
	}

	public void SetCooldownTimer(string seconds)
	{
		cooldownTimer.GetComponent<TMP_Text>().text = seconds;
	}

}
