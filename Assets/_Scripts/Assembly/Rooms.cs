using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Room", menuName = "ScriptableObjects/Rooms")]
public class Rooms : ScriptableObject
{
    public string roomName;
    public string instructions;
}
