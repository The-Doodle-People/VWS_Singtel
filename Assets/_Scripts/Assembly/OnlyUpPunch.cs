using SpatialSys.UnitySDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyUpPunch : MonoBehaviour
{
	Animator animator;
	public float delayTime = 0.0f;

	AudioSource audioSource;

	// Start is called before the first frame update
	void Start()
	{
		animator = GetComponent<Animator>();
		StartCoroutine(DelayStart());

		OnlyUpTimeManager.PauseTime += PauseAnimator;
		OnlyUpTimeManager.ResumeTime += ResumeAnimator;

		audioSource = GetComponent<AudioSource>();
	}

	void PauseAnimator()
	{
		animator.speed = 0f;
	}

	void ResumeAnimator()
	{
		animator.speed = 1f;
	}

	IEnumerator DelayStart()
	{
		yield return new WaitForSeconds(delayTime);
		animator.SetTrigger("start");
	}

	public void PlayAudio()
	{
		audioSource.Play();
	}

	public void TriggerEnter()
	{
		Vector3 force = -transform.forward * 10.0f;
		SpatialBridge.actorService.localActor.avatar.AddForce(force);
	}
}
