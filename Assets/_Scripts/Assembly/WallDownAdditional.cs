using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDownAdditional : WallsDown
{
	public GameObject particleObject;

	protected override void AdditionalEnter()
	{
		base.AdditionalEnter();
		Debug.Log("Debug override working");

		ParticleSystem particleSystem = particleObject.GetComponent<ParticleSystem>();
		if (particleSystem != null )
		{
			var main = particleSystem.main;
			main.startColor = Color.green;
		}
		else
		{
			Debug.LogError("Particle system null");
		}
		
	}

	protected override void AdditionalExit()
	{
		base.AdditionalExit();

		ParticleSystem particleSystem = particleObject.GetComponent<ParticleSystem>();
		if (particleSystem != null)
		{
			var main = particleSystem.main;
			Color newColor = new Color(254, 255, 114, 65);
			main.startColor = newColor;
		}
		else
		{
			Debug.LogError("Particle system null");
		}

	}
}
