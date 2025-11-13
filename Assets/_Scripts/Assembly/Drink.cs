using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Drinks", menuName = "ScriptableObjects/Drinks")]
public class Drink : ScriptableObject
{
    public string drinkName;
    public string itemId;
}
