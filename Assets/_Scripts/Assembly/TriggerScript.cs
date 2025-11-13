using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    Animator animator;
    bool up = false;
    bool entered = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }


    public void Trigger()
    {
        Debug.Log("DEBUG TRIGGER");
        if (!entered)
        {
			up = !up;
			animator.SetBool("Up", up);
			Debug.Log("Debug Up: " + up);
            entered = true;
		}
        
       
    }

    public void CallElevatorDown()
    {
        up = false;
        animator.SetBool("Up", up);
    }

    public void CallElevatorUp()
    {
        up = true;
        animator.SetBool("Up", up);
    }

    public void Exit()
    {
		Debug.Log("DEBUG TRIGGER EXIT");
		entered = false;
    }
	
}
