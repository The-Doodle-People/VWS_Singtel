using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using TMPro;
using SpatialSys.UnitySDK;


public class LogIn : MonoBehaviour
{
    [Header("UI Objects")]
    public GameObject loginScreen;
    public GameObject unlockedScreen;
    public GameObject incorrectText;

    [Header("Account Details")]
    public string username;
    public string password;

    bool unlocked = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            loginScreen.SetActive(false);
            unlockedScreen.SetActive(false);
        }
    }

    public void Interact()
    {
        if(!unlocked)
        {
			loginScreen.SetActive(true);
		}
        else
        {
            unlockedScreen.SetActive(true);
        }
        
    }

    public void Check()
    {
        Debug.Log("debug check runs");
        string inputUsername = loginScreen.transform.GetChild(0).GetComponent<TMP_InputField>().text;
        string inputPassword = loginScreen.transform.GetChild(1).GetComponent<TMP_InputField>().text;

        if(inputUsername == username && inputPassword == password)
        {
            loginScreen.SetActive(false);
            unlockedScreen.SetActive(true);
            unlocked = true;
		}
        else
        {
            incorrectText.SetActive(true);
		}
	}

    public void OpenFile()
    {
		//complete quest on opening file
		if (SpatialBridge.questService.currentQuest.id == 2)
        {
			SpatialBridge.questService.currentQuest.GetTaskByID(5).Complete();
		}
		
		//Debug.Log("debug check passes: " + SpatialBridge.questService.currentQuest.GetTaskByID(5).name);
	}
}
