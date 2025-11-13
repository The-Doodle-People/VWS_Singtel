using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnlyUpLevelBar : MonoBehaviour
{
    public Slider slider;

    public void SetProgress(float progress)
    {
        slider.value = progress;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
