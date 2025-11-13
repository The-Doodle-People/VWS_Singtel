using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "ScriptableObjects/Dialogue")]
public class Dialogue : ScriptableObject
{
    public string NPCName;
    [TextArea]
    public string[] lines;

    public AudioClip[] audioClips;

    public Choices choice;
}
