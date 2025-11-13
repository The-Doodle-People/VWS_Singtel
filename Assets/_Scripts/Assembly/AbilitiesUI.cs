using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitiesUI : MonoBehaviour
{
	public GameObject pickupImg;
	public GameObject kickImg;
	public GameObject jumpImg;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerManager.GetObject())
        {
			pickupImg.GetComponent<Image>().color = Color.green;
		}
        else
        {
			pickupImg.GetComponent<Image>().color = Color.white;
		}

        if (Input.GetKey(KeyCode.E))
        {
            kickImg.GetComponent<Image>().color = Color.green;
		}
        else
        {
			kickImg.GetComponent<Image>().color = Color.white;
		}

		if (Input.GetKey(KeyCode.Space))
		{
			jumpImg.GetComponent<Image>().color = Color.green;
		}
		else
		{
			jumpImg.GetComponent<Image>().color = Color.white;
		}
	}

    void ChangeColour(GameObject gameObj)
    {

    }
}
