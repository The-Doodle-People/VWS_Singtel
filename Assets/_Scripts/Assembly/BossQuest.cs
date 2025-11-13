using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpatialSys.UnitySDK;

public class BossQuest : MonoBehaviour
{
    public static string drinkChoice;
    public Dialogue newDialogue;
    public Dialogue[] choices;

    DialogueScript dialogueScript;
    bool questActive = false;

	// Start is called before the first frame update
	void Start()
    {
		dialogueScript = gameObject.GetComponent<DialogueScript>();
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckItem()
    {
        //if quest is running
        if(questActive)
        {

			UpdateConvo();
			SpatialBridge.questService.currentQuest.GetTaskByID(6).Complete();
			

		}
        else
        {
			
			dialogueScript.StartDialogue();
        }
    }

    public void UpdateConvo()
    {

		if (drinkChoice != null)
		{
			switch (drinkChoice)
			{
				case "Beer":

				case "Cocktail":

					SpatialBridge.questService.currentQuest.AddBadgeReward("egvh636c14ya33k1n43y9");
					//Debug.Log("Cocktail debug");
					dialogueScript.thisDialogue = choices[0];
					break;

				case "Mocha":

				case "Green Tea":

					SpatialBridge.questService.currentQuest.AddBadgeReward("0bwchngsxevxgt25eo7c9");
					dialogueScript.thisDialogue = choices[1];
					break;

				case "Milo":

					SpatialBridge.questService.currentQuest.AddBadgeReward("c7b74vh3iepyj9p7fr3uy");
					dialogueScript.thisDialogue = choices[2];
					break;

				case "Water":

					SpatialBridge.questService.currentQuest.AddBadgeReward("8159lwlqfp3nu0jb5qd74");
					dialogueScript.thisDialogue = choices[3];
					break;
			}
		}

		//dialogueScript.thisDialogue = newDialogue;
        dialogueScript.StartDialogue();
		dialogueScript.thisDialogue = newDialogue;
		questActive = false;
    }

    public void ActivateQuest()
    {
        questActive = true;
    }
}
