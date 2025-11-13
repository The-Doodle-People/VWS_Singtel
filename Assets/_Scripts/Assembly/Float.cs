using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{
	public float floatSpeed = 2f; // Speed at which the object will float upwards
	public float maxHeight = 10f; // Maximum height the object should reach

	enum FloatType {none, up, down};
	FloatType floatType = FloatType.none;
	FloatType storedType = FloatType.none;

	private Vector3 targetPosition;
	private Vector3 originalPosition;

	void Start()
	{
		// Set the target position to be directly above the starting position at maxHeight
		targetPosition = new Vector3(transform.position.x, transform.position.y + maxHeight, transform.position.z);
		originalPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
	}

	void Update()
	{
		if(!TimeManager.TimePaused)
		{
			switch (floatType)
			{
				case FloatType.none:
					break;
				case FloatType.up:
					FloatUp(); break;
				case FloatType.down:
					FloatDown(); break;
			}
		}
			
	}

	public void TriggerEnter()
    {
		floatType = FloatType.up;
	}

	void FloatUp()
	{
		// Move the object towards the target position
		transform.position = Vector3.MoveTowards(transform.position, targetPosition, floatSpeed * Time.deltaTime);

		//Go back down if hit target
		if (transform.position == targetPosition)
		{
			floatType = FloatType.down;
		}
	}

	void FloatDown()
	{
		transform.position = Vector3.MoveTowards(transform.position, originalPosition, floatSpeed * Time.deltaTime);

		//stop if hit target
		if(transform.position == originalPosition)
		{
			floatType = FloatType.none;
		}
	}
}
