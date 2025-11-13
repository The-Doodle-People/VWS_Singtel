using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour
{
	[SerializeField]
    public GameObject dialoguePanel;
    public Dialogue thisDialogue;

    private AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    //Runs when interacting with obj
    public void StartDialogue()
    {
        //Debug.Log("Debug dialoguePanel obj" + dialoguePanel);
		//Debug.Log("Debug dialoguePanel script: " + dialoguePanel.GetComponent<DialogueManager>());

        if(!ChoicesManager.choiceActive)
        {
			//activate or deactivate the panel
			

            /*
            if(audio != null)
            {
                audio.Play();
                Debug.Log("debug audio");
            }
            */

			//Debug.Log("Debug dialoguePanel script works");
			//dialoguePanel.SetActive(!dialoguePanel.activeSelf);
            if(!dialoguePanel.activeSelf)
            {
                dialoguePanel.SetActive(true);
            }
            else
            {
                CloseDialogue();
            }

			dialoguePanel.GetComponent<DialogueManager>().SetCurrentDialogue(thisDialogue);
		}
		
	}

    public void CloseDialogue()
    {
		dialoguePanel.GetComponent<DialogueManager>().CloseDialogue();
	}
}
