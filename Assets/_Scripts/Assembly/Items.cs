using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Items", menuName = "ScriptableObjects/Items")]
public class Items : ScriptableObject
{
	public string itemName;
	public string itemId;
	public Sprite icon;

}
