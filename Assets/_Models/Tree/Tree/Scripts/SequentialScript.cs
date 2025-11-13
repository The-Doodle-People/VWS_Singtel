using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequentialScript : MonoBehaviour
{
    private GameObject[] trails = new GameObject[4];
    private int count = 0;
    public float offset = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < trails.Length; i++)
        {
            trails[i] = transform.GetChild(i).gameObject;
        }

        InvokeRepeating("EnableTrail", 0, offset);
    }

    private void Update()
    {
        
    }

    void EnableTrail()
    {
        transform.GetChild(count % 4).gameObject.SetActive(true);
        count++;
    }
}
