using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoPanelScript : MonoBehaviour
{
    public InfoPanel infoPanel;
    public GameObject panel;
    public GameObject panelMore;

	// Start is called before the first frame update
	void Start()
    {
		//panel = GameObject.Find("Canvas").transform.GetChild(2).gameObject;
    }

    public void OnTrigger()
    {
        if (panel != null)
        {
			panel.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TMP_Text>().text = infoPanel.artworkName;
			//panel.transform.GetChild(1).GetChild(0).gameObject.GetComponent<TMP_Text>().text = infoPanel.description;
			//panel.transform.GetChild(2).GetChild(0).gameObject.GetComponent<TMP_Text>().text = "by " + infoPanel.creatorName;

			panelMore.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TMP_Text>().text = infoPanel.artworkName;
			panelMore.transform.GetChild(1).GetChild(0).GetChild(0).gameObject.GetComponent<TMP_Text>().text = infoPanel.description;
			panelMore.transform.GetChild(2).GetChild(0).gameObject.GetComponent<TMP_Text>().text = "by " + infoPanel.creatorName;
			panelMore.transform.GetChild(3).GetChild(0).gameObject.GetComponent<TMP_Text>().text = infoPanel.artSize;

			panel.SetActive(true);
		}
        else
        {
            Debug.LogError("Panel not found");
        }

    }

    public void OnExit()
    {
        if (panel != null)
        {
			panel.SetActive(false);
		}
        else
        {
            Debug.LogError("Panel still not found");
        }
		
    }
}
