using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpatialSys.UnitySDK;

public class DrinkScript : MonoBehaviour
{
    public Drink drink;

    public void ClickDrink()
    {
        Debug.Log("Debug drink: " +  drink.drinkName + ", id: " + drink.itemId + ", this: " + this.gameObject.name);
		transform.parent.GetComponent<ChoicesManager>().SetDrink(drink);

        if(drink.itemId == "519gv88gkog3fvjdf1dgv")
        {
            QuestTask();
        }
	}

    public void QuestTask()
    {
        Debug.Log("debug quest task");
		SpatialBridge.questService.currentQuest.GetTaskByID(1).Complete();
	}
}
