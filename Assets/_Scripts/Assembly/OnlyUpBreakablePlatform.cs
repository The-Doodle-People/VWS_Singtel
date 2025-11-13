using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyUpBreakablePlatform : MonoBehaviour
{
    public float breakTime = 5.0f;
    public float respawnTime = 5.0f;

    public GameObject modelObj;

    public Material normalMat;
    public Material halfwayMat;
    public Material almostMat;

    Coroutine timerCoroutine;
    Renderer objRenderer;

    // Start is called before the first frame update
    void Start()
    {
        objRenderer = modelObj.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerEnter()
    {
		Debug.Log("debug triggerenter timer");
		if (timerCoroutine == null)
        {
            timerCoroutine = StartCoroutine(Timer());
		}
        
    }

    IEnumerator Timer()
    {
        Debug.Log("debug ienumerator timer");
        yield return new WaitForSeconds(breakTime / 2);
        objRenderer.material = halfwayMat;
		yield return new WaitForSeconds(breakTime / 4);
		objRenderer.material = almostMat;
		yield return new WaitForSeconds(breakTime / 4);
		//break
		modelObj.SetActive(false);

        yield return new WaitForSeconds(respawnTime);
		//respawn
		objRenderer.material = normalMat;
		modelObj.SetActive(true);
        timerCoroutine = null;
    }
}
