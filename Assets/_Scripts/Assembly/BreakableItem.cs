
using UnityEngine;

public class BreakableItem : MonoBehaviour
{
    public GameObject prefab;
    //public GameObject[] spawnedItems;
    bool inRange = false;

    [Header("Randomize")]
    public float spawnRadius = 3f;
    public int minNumber = 1;
    public int maxNumber = 3;


	// Update is called once per frame
	void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.F))
        {			
            // Generate a random number of prefabs to spawn
            int count = Random.Range(minNumber, maxNumber + 1);
            Debug.Log("count: " + count);

            //randomly choose which prefab to spawn
            //int prefabIndex = Random.Range(0, spawnedItems.Length);

            // Spawn prefabs in a circle
            for (int i = 0; i < count; i++)
            {
	            // Calculate random angle within a circle (in radians)
	            float angle = Random.Range(0f, Mathf.PI * 2f);

	            // Calculate random position within the circle
	            Vector3 spawnPosition = transform.position + new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle)) * spawnRadius;

	            // Instantiate prefab at the calculated position
                GameObject instantiatedPrefab = Instantiate(prefab, spawnPosition, Quaternion.identity);
				instantiatedPrefab.transform.parent = gameObject.transform.parent;

			}

			Destroy(gameObject);
        }
	}

    void OnTriggerEnter(Collider collider)
    {
		Debug.Log("break tag :" + collider.tag);

		if (collider.name == "LocalAvatarView")
        {
			Debug.Log("break name :" + collider.name);
			inRange = true;
		}		
    }

    void OnTriggerExit(Collider collider)
    {
		if (collider.name == "LocalAvatarView")
		{
			//Debug.Log("break name :" + collider.name);
			inRange = false;
		}
	}
}
