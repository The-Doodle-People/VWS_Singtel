using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    public GameObject sceneManager;
    Reloader reloaderScript;

    public int areaNumber;

    // Start is called before the first frame update
    void Start()
    {
        if (sceneManager)
        {
			reloaderScript = sceneManager.GetComponent<Reloader>();
		}
        else
        {
            Debug.LogError("SceneManager null in AreaManager");
        }
		
    }

    public void SetArea()
    {
        if (reloaderScript)
        {
			reloaderScript.SetCurrentArea(areaNumber);
		}
        else
        {
			Debug.LogError("Reloader Script null in AreaManager");
		}
        
    }
}
