using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InfoPanel", menuName = "ScriptableObjects/InfoPanel")]
public class InfoPanel : ScriptableObject
{
	public string artworkName;

	[TextArea]
	public string description;
	public string artSize;
	public string creatorName;
}

