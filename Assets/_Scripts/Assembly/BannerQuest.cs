using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpatialSys.UnitySDK;

public class BannerQuest : MonoBehaviour
{


    public void OnTriggerEnter(Collider collider)
    {
        if(SpatialBridge.questService.currentQuest.id == 2)
        {
			SpatialBridge.questService.currentQuest.GetTaskByID(2).Complete();
		}
    }
}
