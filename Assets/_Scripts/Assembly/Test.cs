using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpatialSys.UnitySDK;

public class Test : MonoBehaviour
{

	public void Delete()
	{
		SpatialBridge.inventoryService.DeleteItem("bkxxtpumahctbphojxffq");
	}
}
