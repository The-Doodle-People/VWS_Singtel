using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManagerNew : MonoBehaviour
{
	public static event Action DialogueStarted;
	public static event Action DialogueFinished;

	public GameObject choicesPanel;

	private DialogueNew currentDialogue;
	private int index = 0;

	private AudioSource audio;

	public void SetCurrentDialogue(DialogueNew dialogue)
	{
		//set current dialogue and reset index
		currentDialogue = dialogue;
		index = 0;

		//set UI
		transform.GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = currentDialogue.NPCName;
		transform.GetChild(0).GetComponent<TMP_Text>().text = currentDialogue.lines[index];

		//get audio source
		if (audio == null)
		{
			audio = GetComponent<AudioSource>();
		}

		//play audio
		if (audio != null)
		{
			Debug.Log("debug audio");
			audio.clip = currentDialogue.audioClips[index];
			audio.Play();

		}

		DialogueStarted?.Invoke();
	}

	public void NextLine()
	{
		if ((index + 1) < currentDialogue.lines.Length)
		{
			//increase index and change text and audio
			index++;
			transform.GetChild(0).GetComponent<TMP_Text>().text = currentDialogue.lines[index];

			//play audio
			if (audio != null)
			{
				audio.clip = currentDialogue.audioClips[index];
				audio.Play();
				Debug.Log("debug audio");
			}
		}
		else
		{
			//if there are choices, load the choices
			if (currentDialogue.choices != null)
			{
				//stop audio
				if (audio != null)
				{
					audio.Stop();
				}

				choicesPanel.SetActive(true);

			}

			//else just close
			CloseDialogue();
		}
	}

	public void CloseDialogue()
	{

		Debug.Log("Debug close dialogue");
		gameObject.SetActive(false);

		//stop audio
		if (audio != null)
		{
			audio.Stop();
		}

		DialogueFinished?.Invoke();
	}
}
