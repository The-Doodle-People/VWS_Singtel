using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class InstructionsPopUp : MonoBehaviour
{
    public GameObject[] popUps;
    int level = 0;
    //public static GameObject player;

    void Start()
    {
        Debug.Log("popup runs debug");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
			Debug.Log("keypressed runs debug");
			PopUp(level);
			Debug.Log("level debug: " + level);
		}
    }

    void PopUp(int level)
    {
        popUps[level].gameObject.SetActive(!popUps[level].gameObject.activeSelf);
    }

    public void IncreaseLevel()
    {
        if(level <= 2)
        {
			level++;

            //disable the rest and force a popup
            foreach(GameObject popUp in popUps)
            {
                popUp.SetActive(false);
            }
            PopUp(level);
            
		}
        
    }
}
