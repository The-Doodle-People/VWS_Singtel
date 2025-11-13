using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Debug test time: " + System.DateTime.Now);
        Debug.Log("Debug test day: " + System.DateTime.Now.ToString("dddd"));
	}

}
