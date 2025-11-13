using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject vfx;
    public Transform parent;
    public float spawnTime = 5f;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        SpawnObj();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > spawnTime)
        {
            timer = 0;
            SpawnObj();
        }
    }
    void SpawnObj()
    {
        Instantiate(vfx, parent);
    }
}
