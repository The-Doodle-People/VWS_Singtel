using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizerScript : MonoBehaviour
{
    private GameObject[] trails = new GameObject[4];
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < trails.Length; i++)
        {
            trails[i] = transform.GetChild(i).gameObject;
        }  

        int ites = Random.Range(1, trails.Length);
        for (int i = 0; i < ites; i++)
        {
            int index = Random.Range(0, trails.Length-1);
            trails[index].SetActive(true);
        }
    }
}
