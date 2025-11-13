using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using TMPro;
using SpatialSys.UnitySDK;

public class DialogueManagerBasic : MonoBehaviour, IPointerClickHandler
{
	public static event Action DialogueStarted;
	public static event Action DialogueFinished;

	public static event Action ShowChoicesStart;

	private Dialogue currentDialogue;
	private int index = 0;

	private AudioSource audio;

	public void SetCurrentDialogue(Dialogue dialogue)
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

	public void OnPointerClick(PointerEventData eventData)
	{
		Vector3 mousePos = new Vector3(eventData.position.x, eventData.position.y, 0);

		int linkTaggedText = TMP_TextUtilities.FindIntersectingLink(transform.GetChild(0).GetComponent<TMP_Text>(), mousePos, null);

		//if it is the text tagged with the link
		if (linkTaggedText != -1)
		{
			TMP_LinkInfo linkInfo = transform.GetChild(0).GetComponent<TMP_Text>().textInfo.linkInfo[linkTaggedText];
			string linkID = linkInfo.GetLinkID();

			if (linkID.Contains("www"))
			{
				Debug.Log("Debug link clicked: " + linkID);
				//Application.OpenURL(linkID);
				SpatialBridge.spaceService.OpenURL(linkID);
				return;
			}
		}
		else
		{
			Debug.Log("Debug no link tagged text");
		}
	}
}
