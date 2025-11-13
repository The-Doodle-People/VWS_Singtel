using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using SpatialSys.UnitySDK;


public class NPCMovement : MonoBehaviour
{
	public enum PatrolType
	{
		Patrol, PatrolLoop
	}

    //public variables
    [Header("Variables to Set")]
    public GameObject waypointSet;
	public PatrolType patrolType = PatrolType.Patrol;

    //patrol variables
    GameObject child;
    Vector3 newVector;
    bool descending = false;
    int index = 0;

    //private NavMeshPath path;
	private NavMeshAgent agent;
	Animator animator;

	bool isTalking = false;

    // Start is called before the first frame update
    void Start()
    {
		agent = gameObject.GetComponent<NavMeshAgent>();
		animator = gameObject.GetComponent<Animator>();

		//DialogueManager.DialogueStarted += StartTalking;
		DialogueManager.DialogueFinished += StopTalking;
	}

    // Update is called once per frame
    void Update()
    {
		//only patrol if not talking
		if(!isTalking)
		{
			//check the patrol type
			if (patrolType == PatrolType.Patrol)
			{
				Patrol();
			}
			else
			{
				PatrolLoop();
			}
		}
		else
		{
			LookAtPlayer();
		}
					      
    }

	void PatrolLoop()
    {
        //get the waypoint gameObject and distance
        child = waypointSet.gameObject.transform.GetChild(index).gameObject;
		newVector = new Vector3(child.transform.position.x, transform.position.y, child.transform.position.z);
		agent.SetDestination(newVector);

		//if (transform.position.x == newVector.x && transform.position.z == newVector.z)
		if (Vector3.Distance(transform.position, newVector) < 0.1f)
		{

			if (index == waypointSet.transform.childCount - 1)
                {                   
                    index = 0;
                }
                else
                {
                    index++;
                }
				
				//Debug.Log("NPC debug index: " + index);
				//Debug.Log("NPC debug childcount: " + waypointSet.transform.childCount);
		}
        else
        {
            //Debug.Log("NPC pos: " + transform.position + " , target pos: " + newVector);
        }
    }

    void Patrol()
    {
		//get the waypoint gameObject and distance
		child = waypointSet.gameObject.transform.GetChild(index).gameObject;
		newVector = new Vector3(child.transform.position.x, transform.position.y, child.transform.position.z);

		float distance = Vector3.Distance(child.transform.position, transform.position);

		agent.SetDestination(newVector);

		if(distance < 1.0)
		{
			if (descending)
			{
				//check if reached zero
				if (index == 0)
				{
					//change to ascending
					descending = false;
					index++;
				}
				else
				{
					//keep minusing 1
					index--;
				}
			}
			//if ascending
			else
			{
				if (index == waypointSet.transform.childCount - 1)
				{
					descending = true;
					index--;
				}
				else
				{
					index++;
				}
			}
		}
		else
		{
			//Debug.Log("NPC pos: " + transform.position + " , target pos: " + newVector);
		}
	}

	public void StartTalking()
	{
		
		//change the talking animation
		animator.SetBool("isTalking", true);
		agent.Stop();
		//LookAtPlayer();
		isTalking = true;
		//Debug.Log("Debug start talking: " + isTalking);
	}

	void StopTalking()
	{		
		
		animator.SetBool("isTalking", false);
		agent.Resume();
		isTalking = false;
		//Debug.Log("Debug stop talking: " + isTalking);
	}

	void LookAtPlayer()
	{
		//Debug.Log("Debug Look at player");

		/*
		// Calculate the direction from this object to the player
		Vector3 directionToPlayer = SpatialBridge.actorService.localActor.avatar.position - transform.position;

		// Calculate the rotation angle in radians
		float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;

		// Create a rotation based on the calculated angle
		Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		// Apply the rotation to this object
		transform.rotation = rotation;
		*/

		transform.LookAt(SpatialBridge.actorService.localActor.avatar.position);
	}

}


