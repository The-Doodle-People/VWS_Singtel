using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyUpPlatforms : MonoBehaviour
{
    Animator animator;
    public float delayTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
		animator = GetComponent<Animator>();
        StartCoroutine(DelayStart());

		OnlyUpTimeManager.PauseTime += PauseAnimator;
        OnlyUpTimeManager.ResumeTime += ResumeAnimator;
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

}
