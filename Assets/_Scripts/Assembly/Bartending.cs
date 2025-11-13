using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpatialSys.UnitySDK;

public class Bartending : MonoBehaviour
{
    public GameObject choicesPanel;
    string itemId;

    //public string drinkId;

    Animator animator;



    // Start is called before the first frame update
    void Start()
    {
		//DialogueManager.DialogueStarted += Talking;
		//DialogueManager.DialogueFinished += Mixing;
		//DialogueManager.DialogueFinished += ShowChoices;

		animator = gameObject.GetComponent<Animator>();
        Debug.Log("Debug animator: " + animator);
    }

    void ShowChoices()
    {
        choicesPanel.SetActive(true);
    }

	public void CloseChoices()
	{
		if (choicesPanel.activeSelf)
		{
			choicesPanel.SetActive(false);
		}
	}

	public void SetDrink(string drink)
    {
		Debug.Log("Debug 2nd set drink" + drink);
		choicesPanel.SetActive(false);
        itemId = drink;
        Mixing();
    }

    public void Talking()
    {
        //start talking animation
        animator.SetBool("talking", true);

        Debug.Log("Debug talking runs");
    }

    void Mixing()
    {
        //start mixing animation
        animator.SetBool("mixing", true);
        animator.SetBool("talking",  false);

		Debug.Log("Debug Mixing runs");
		//start timer
		StartCoroutine(Timer(5));
    }

    void StopMixing()
    {
		//stop animation
		animator.SetBool("mixing", false);
        Debug.Log("Debug Stopped mixing");

		//add item to inventory
		SpatialBridge.inventoryService.AddItem(itemId);
		Debug.Log("Debug added item: " + itemId);
	}

    IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);
        StopMixing();

    }
}
