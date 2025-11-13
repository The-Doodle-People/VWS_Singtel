using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedCollider : MonoBehaviour
{
    public GameObject instructionsPopUp;

    // Start is called before the first frame update
    void OnEnable()
    {
        instructionsPopUp.GetComponent<InstructionsPopUp>().IncreaseLevel();
    }
}
