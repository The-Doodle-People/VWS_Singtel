using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyUpDisappearing : MonoBehaviour
{
	public GameObject modelObj;
	public GameObject disappearVfx;

	public float delayTime = 0.0f;
	public float disappearTime = 5.0f;private float remainingTime;

	private Coroutine disappearCoroutine;
	AudioSource audioSource;

	// Start is called before the first frame update
	void Start()
	{
		audioSource = GetComponent<AudioSource>();

		OnlyUpTimeManager.PauseTime += PauseDisappear;
		OnlyUpTimeManager.ResumeTime += ResumeDisappear;
		//remainingTime = disappearTime;
		disappearCoroutine = StartCoroutine(DelayStart());

		
	}

	void PauseDisappear()
	{
		if (disappearCoroutine != null)
		{
			StopCoroutine(disappearCoroutine);
			disappearCoroutine = null;
		}
	}

	void ResumeDisappear()
	{
		if (disappearCoroutine == null)
		{
			disappearCoroutine = StartCoroutine(DelayStart());
		}
	}

	IEnumerator Deactivate()
	{
		
		while (remainingTime > 0)
		{

			
			remainingTime -= Time.deltaTime;
			//Debug.Log("Timer: " + remainingTime);

			if(remainingTime < disappearTime/4)
			{
				disappearVfx.SetActive(modelObj.activeSelf);
			}
			
			yield return null;
		}
	

		//yield return new WaitForSeconds(disappearTime/4*3);


		//disappearVfx.SetActive(modelObj.activeSelf);
		//yield return new WaitForSeconds(disappearTime / 4);
		modelObj.SetActive(!modelObj.activeSelf);
		audioSource.Play();
		disappearVfx.SetActive(false);

		remainingTime = disappearTime;

		disappearCoroutine = StartCoroutine(Deactivate());
	}

	IEnumerator DelayStart()
	{
		yield return new WaitForSeconds(delayTime);
		disappearCoroutine = StartCoroutine(Deactivate());
	}
}