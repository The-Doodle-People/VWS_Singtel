using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpatialSys.UnitySDK;

public class FloatDoor : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = transform.parent.GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerEnter(Collider collider)
    {
		//if (collider.gameObject == SpatialBridge.actorService.localActor.avatar.gameObject)
		//if (collider.gameObject.name == "LocalAvatarView")
        //{
            Debug.Log("Debug collider entered" + collider.gameObject.name);
			animator.SetBool("Open", true);
		//}
        //else
        //{
        //    Debug.LogError("Debug collider problem: " +  collider.gameObject.name);
        //}
        
    }

    public void TriggerExit(Collider collider)
    {
		//if (collider.gameObject == SpatialBridge.actorService.localActor.avatar)
		//if (collider.gameObject.name == "LocalAvatarView")
		//{
			Debug.Log("Debug collider exited");
			animator.SetBool("Open", false);
		//}
			
    }
}
