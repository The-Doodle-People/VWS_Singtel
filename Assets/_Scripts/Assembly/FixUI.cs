using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FixUI : MonoBehaviour
{
    public GameObject textPanel;
    public Text title;
    public Button fixButton; 
    bool inRange = false;

    // Start is called before the first frame update
    void Start()
    {

	}

    // Update is called once per frame
    void Update()
    {
        if(inRange && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("FixUI");
            textPanel.SetActive(!textPanel.activeSelf);
            title.text = "Fix the Bridge!";
            //fixButton.interactable = false;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        inRange = true;
    }

    void OnTriggerExit(Collider collider)
    {
        inRange = false;
    }
}
