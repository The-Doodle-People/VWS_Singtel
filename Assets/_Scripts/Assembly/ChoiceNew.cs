using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "ChoiceNew", menuName = "ScriptableObjects/ChoiceSystem/Choice")]
public class ChoiceNew : ScriptableObject
{
    public Dialogue choice;

    public Dialogue nextLine;
}
