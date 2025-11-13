using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueScriptBasic : MonoBehaviour
{
	[SerializeField]
	public GameObject dialoguePanel;
	public Dialogue thisDialogue;
	public Animator animator;

	//private AudioSource audio;

	void Start()
	{
		//audio = GetComponent<AudioSource>();
		DialogueManagerBasic.DialogueFinished += StopAnimation;
	}

	//Runs when interacting with obj
	public void StartDialogue()
	{
		if (!dialoguePanel.activeSelf)
		{
			dialoguePanel.SetActive(true);

			if (animator != null)
			{
				animator.SetBool("talking", true);
			}
			else
			{
				Debug.LogError("Animator null");
			}
		}
		else
		{
			CloseDialogue();

			if (animator != null)
			{
				animator.SetBool("talking", false);
			}
			else
			{
				Debug.LogError("Animator null");
			}
		}

		dialoguePanel.GetComponent<DialogueManagerBasic>().SetCurrentDialogue(thisDialogue);


		
		

	}

	public void CloseDialogue()
	{
		dialoguePanel.GetComponent<DialogueManagerBasic>().CloseDialogue();
		
	}

	void StopAnimation()
	{
		if (animator != null)
		{
			animator.SetBool("talking", false);
		}
		else
		{
			Debug.LogError("Animator null");
		}
	}

}
