using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpatialSys.UnitySDK;
using UnityEngine.UI;
using TMPro;

public class OnlyUpSceneManager : MonoBehaviour
{
	public GameObject startPoint;
	public GameObject tutorialPanel;
	public static GameObject lastCheckpoint;

	public GameObject timerText;
	public GameObject timerTextFinal;
	Coroutine timerCoroutine;
	float timer;

	// Start is called before the first frame update
	void Start()
	{
		OnlyUpLevelManager.OnGameReset += StartTimer;
		lastCheckpoint = startPoint;
		
	}

	// Update is called once per frame
	void Update()
	{
		if (SpatialBridge.actorService.localActor.avatar.position.y < 0)
		{
			Debug.Log("Avatar fallen");
			ReloadLastCheckpoint();
		}

		if(Input.GetKeyDown(KeyCode.F))
		{
			Tutorial();
		}
	}

	private void FixedUpdate()
	{
		Timer();
	}

	void ReloadLastCheckpoint()
	{
		Vector3 offset = lastCheckpoint.transform.forward * -0.5f + lastCheckpoint.transform.right * 0.5f;
		SpatialBridge.actorService.localActor.avatar.SetPositionRotation(lastCheckpoint.transform.position + offset, lastCheckpoint.transform.rotation);
		SpatialBridge.actorService.localActor.avatar.velocity = Vector3.zero;
		//SpatialBridge.actorService.localActor.avatar.an = Vector3.zero;
	}

	public void Tutorial()
	{
		tutorialPanel.SetActive(!tutorialPanel.activeSelf);
		if (tutorialPanel.activeSelf)
		{
			SpatialBridge.coreGUIService.DisplayToastMessage("Press F to open the tutorial again");
		}
	}

	
	public void StartTimer()
	{
		timer = 0.0f;
		timerCoroutine = StartCoroutine(Timer());

	}

	public void StopTimer()
	{
		StopCoroutine(timerCoroutine);
		timerCoroutine = null;
		int minutes = Mathf.FloorToInt(timer / 60F);
		int seconds = Mathf.FloorToInt(timer % 60F);

		timerTextFinal.GetComponent<TMP_Text>().text = string.Format("{00:00}:{1:00}", minutes, seconds);
	}
	

	IEnumerator Timer()
	{
		while (true) 
		{
			timer += Time.deltaTime;
			Debug.Log("Timer: " + timer);

			int minutes = Mathf.FloorToInt(timer / 60F);
			int seconds = Mathf.FloorToInt(timer % 60F);

			timerText.GetComponent<TMP_Text>().text = string.Format("{00:00}:{1:00}", minutes, seconds);
			yield return null;
		}
		
	}


}
