using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "DialogueNew", menuName = "ScriptableObjects/ChoiceSystem/Dialogue")]
public class DialogueNew : ScriptableObject
{
	public string NPCName;
	[TextArea]
	public string[] lines;

	public AudioClip[] audioClips;

	public ChoicesNew choices;
}
