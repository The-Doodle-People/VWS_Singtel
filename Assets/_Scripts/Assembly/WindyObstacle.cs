using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpatialSys.UnitySDK;

public class WindyObstacle : MonoBehaviour
{
    public float delayTime = 0.0f;
    public float intervalTime = 5.0f;
    public float blowingTime = 5.0f;
    public float blowForce = 10f;
    float remainingTime;

    public GameObject vfx;
    bool isBlowing = false;
    bool isEntered = false;
    bool paused = false;

    Coroutine blowCoroutine;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
		//StartCoroutine(StartBlowing(intervalTime));
		OnlyUpTimeManager.PauseTime += PauseBlowing;
		OnlyUpTimeManager.ResumeTime += ResumeBlowing;
		remainingTime = intervalTime;
		blowCoroutine = StartCoroutine(Blowing());

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isEntered && isBlowing && !paused)
        {
            TriggerWind();
        }
    }

    public void TriggerEnter()
    {
        isEntered = true;
    }

    public void TriggerExit()
    {
        isEntered = false;
        //Debug.Log("Debug wind trigger false");
    }

	void PauseBlowing()
	{
		if (blowCoroutine != null)
		{
			StopCoroutine(blowCoroutine);
			blowCoroutine = null;
            paused = true;
		}
	}

	void ResumeBlowing()
	{
		if (blowCoroutine == null)
		{
			blowCoroutine = StartCoroutine(DelayStart());
            paused = false;
		}
	}
	IEnumerator Blowing()
    {
        //run the time
        while(remainingTime > 0)
        {

            remainingTime -= Time.deltaTime;
			//Debug.Log("Timer: " + remainingTime);
			

            yield return null;
        }

        //blowing func
        if (isBlowing)
        {
			//stop blowing
			//Debug.Log("Debug: Stop blowing");
			isBlowing = false;
			vfx.SetActive(false);
            remainingTime = intervalTime;
            audioSource.Stop();
		}
        else
        {
			//start blowing
			//Debug.Log("Debug: Start blowing");
			isBlowing = true;
			vfx.SetActive(true);
            remainingTime = blowingTime;
            audioSource.Play();
		}
        //reset remaining time
        blowCoroutine = StartCoroutine(Blowing());

    }

    IEnumerator DelayStart()
    {
        yield return new WaitForSeconds (delayTime);
        blowCoroutine = StartCoroutine (Blowing());
    }

    void TriggerWind()
    {
		Debug.Log("Debug: TriggerWind");
		Vector3 force = transform.up * blowForce;
		SpatialBridge.actorService.localActor.avatar.AddForce(force);

		//StartCoroutine(Timer(time));
	}
}
