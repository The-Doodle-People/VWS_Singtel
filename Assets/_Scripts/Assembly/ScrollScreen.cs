using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScreen : MonoBehaviour
{
    public GameObject backButton;
    public GameObject nextButton;
    public GameObject parentObject;
    GameObject[] images;
    int currentPage;

	private void Start()
	{
        int size = parentObject.transform.childCount;
        images = new GameObject[size];

		for (int i = 0; i < size; i++)
        {
            images[i] = parentObject.transform.GetChild(i).gameObject;
        }

        currentPage = 0;
	}

	public void NextPage()
    {
        if (currentPage + 1 < images.Length)
        {
            if (!backButton.activeSelf)
            {
                backButton.SetActive(true);
            }

			parentObject.transform.GetChild(currentPage).gameObject.SetActive(false);
			currentPage++;
			parentObject.transform.GetChild(currentPage).gameObject.SetActive(true);

            if(currentPage == images.Length - 1)
            {
                nextButton.SetActive(false);
            }
		}
        
    }

    public void PreviousPage()
    {
        if(currentPage != 0)
        {
            if (!nextButton.activeSelf)
            {
                nextButton.SetActive(true);
            }

			parentObject.transform.GetChild(currentPage).gameObject.SetActive(false);
			currentPage--;
			parentObject.transform.GetChild(currentPage).gameObject.SetActive(true);
			
            if(currentPage == 0)
            {
                backButton.SetActive(false);
            }
		}


	} 
}
