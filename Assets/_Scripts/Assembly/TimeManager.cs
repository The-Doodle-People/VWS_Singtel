using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
	private static bool timePaused = false;

	private static List<Rigidbody> pausedRigidbodies = new List<Rigidbody>();
	private static Dictionary<Rigidbody, Vector3> savedVelocities = new Dictionary<Rigidbody, Vector3>();
	private static Dictionary<Rigidbody, Vector3> savedAngularVelocities = new Dictionary<Rigidbody, Vector3>();

	void Start()
	{
		timePaused = false;
	}

	public static bool TimePaused
	{
		get { return timePaused; }
		set
		{
			if (timePaused != value)
			{
				timePaused = value;

				if (timePaused == true)
				{
					PausePhysics();
				}
				else
				{
					ResumePhysics();
				}

			}
		}
	}

	private static void PausePhysics()
	{
		pausedRigidbodies.Clear();
		savedVelocities.Clear();
		savedAngularVelocities.Clear();

		foreach (Rigidbody rb in FindObjectsOfType<Rigidbody>())
		{
			if (rb != null && !rb.isKinematic)
			{
				pausedRigidbodies.Add(rb);
				savedVelocities[rb] = rb.transform.InverseTransformDirection(rb.velocity);
				savedAngularVelocities[rb] = rb.transform.InverseTransformDirection(rb.angularVelocity);

				rb.isKinematic = true;
			}
		}
	}

	private static void ResumePhysics()
	{
		foreach (Rigidbody rb in pausedRigidbodies)
		{
			if (rb != null)
			{
				rb.isKinematic = false;
				rb.velocity = rb.transform.TransformDirection(savedVelocities[rb]);
				rb.angularVelocity = rb.transform.TransformDirection(savedAngularVelocities[rb]);
			}
		}
		
	}

	void OnDestroy()
	{
		pausedRigidbodies.Clear();
		savedVelocities.Clear();
		savedAngularVelocities.Clear();
	}
}
