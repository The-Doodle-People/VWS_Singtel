using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;

    // Start is called before the first frame update
    void Start()
    {
        if (object1 != null && object2 != null)
        {
            Collider collider1 = object1.GetComponent<Collider>();
            Collider collider2 = object2.GetComponent<Collider>();

            Physics.IgnoreCollision(collider1, collider2);

            Debug.Log("collider 1: " + collider1 + ", collider 2: " + collider2);
        }
        else
        {
            Debug.LogError("Null gameobject in IgnoreCollision");
        }
    }

}
