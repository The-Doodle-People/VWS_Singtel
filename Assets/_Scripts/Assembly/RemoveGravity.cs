using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveGravity : MonoBehaviour
{
    public GameObject[] gameObjects;
	public GameObject particleObject;
    public GameObject environmentVFX;
	bool gravity = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    { 
        if(gravity)
        {
            Remove();
        }
        else
        {
            Add();
        }


    }

    void Remove()
    {
        foreach (GameObject obj in gameObjects)
        {
            obj.GetComponent<Rigidbody>().useGravity = false;
            gravity = false;
        }

		ParticleSystem particleSystem = particleObject.GetComponent<ParticleSystem>();
		if (particleSystem != null)
		{
			var main = particleSystem.main;
			main.startColor = Color.green;
		}
		else
		{
			Debug.LogError("Particle system null");
		}

        environmentVFX.SetActive(true);
	}

    void Add()
    {
        Debug.Log("Debug add");
		foreach (GameObject obj in gameObjects)
		{
			obj.GetComponent<Rigidbody>().useGravity = true;
            gravity = true;
		}

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

		environmentVFX.SetActive(false);
	}
}
