using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class NameRequest : MonoBehaviour
{

    public static string userName = "";

    public void SetName(TMP_InputField nameInput)
    {
        NameRequest.userName = nameInput.text;
    }
}
