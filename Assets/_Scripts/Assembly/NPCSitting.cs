using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSitting : MonoBehaviour
{
    Animator animator;

    public enum SitType
    {
        TalkL, TalkR, Cross, Idle
    }

    public SitType sitType;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator> ();
        animator.SetTrigger(sitType.ToString());
        Debug.Log("Debug sittype: " +  sitType);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
