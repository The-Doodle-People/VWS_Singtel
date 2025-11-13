using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpatialSys.UnitySDK;

public class ChoicesManager : MonoBehaviour
{
    public static bool choiceActive = false;
    public GameObject bartenderNPC;
    Bartending bartending;

    void OnEnable()
    {
        choiceActive = true;
    }

    void OnDisable()
    {
        choiceActive = false;
    }
	// Start is called before the first frame update
	void Start()
    {
		//DialogueManager.ShowChoicesStart += ShowChoices;
        bartending = bartenderNPC.GetComponent<Bartending>();
	}
    
    public void SetDrink(Drink drink)
    {
		//Debug.Log("Debug 1st set drink" + drink);
		bartending.SetDrink(drink.itemId);

        if(SpatialBridge.questService.currentQuest.id == 2)
        {
            BossQuest.drinkChoice = drink.drinkName;
			SpatialBridge.questService.currentQuest.GetTaskByID(1).Complete();
		}
        
    }

    
}
