using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using SpatialSys.UnitySDK;

public class OnlyUpLevelManager : MonoBehaviour
{
    [Header("Progress Bar UI")]
    public Sprite[] levelBordersSprites;
    public Image levelBoarder;
    public TMP_Text levelText;
    public GameObject starParent;
    public Slider slider;
    public GameObject entrancePoint;

	public static int _level;
    public static event Action<int> OnLevelChange;
    public static event Action OnGameReset;

    // Start is called before the first frame update
    void Start()
    {
        OnlyUpLevelManager.OnLevelChange += SetLevel;
        OnlyUpCheckpoint.OnCheckpointActivated += SetProgress;

	}

    public static int level
    {

        get { return _level; } 
        set 
        { 
            if (_level != value)
            {
                Debug.Log("Debug level change: " + value);
				_level = value;
				OnLevelChange?.Invoke(_level);
			}
        }
    }

    void SetLevel(int level)
    {
        if (_level < 3)
        {
            //bronze
            levelBoarder.sprite = levelBordersSprites[0];
        }
        else if (_level < 5)
        {
			//silver
			levelBoarder.sprite = levelBordersSprites[1];
		}
        else
        {
			//gold
			levelBoarder.sprite = levelBordersSprites[2];
		}

        if (level != 1)
        {
			starParent.transform.GetChild(level - 2).GetChild(0).gameObject.SetActive(true);
			levelText.text = level.ToString();
		}
        else
        {
            levelText.text = level.ToString();
        }
        
	}

    void SetProgress(int checkpointNumber)
    {
		slider.value = checkpointNumber; 

	}

    public void ResetGame()
    {     
        for(int i = 0; i < starParent.transform.childCount; i++)
        {
            starParent.transform.GetChild (i).GetChild(0).gameObject.SetActive(false);
        }

		OnlyUpLevelManager.level = 1;
        slider.value = 0;

        //create new quest
		SpatialBridge.questService.CreateQuest("Reach the top", "Climb all the way to the top", true, false, false, true).Start();
        GameObject[] taskMarkers = {};
        Debug.Log("Debug quest: " + SpatialBridge.questService.currentQuest.status);
        SpatialBridge.questService.currentQuest.AddTask("Climb to the top", QuestTaskType.Check, 0, taskMarkers).Start();
        
		SpatialBridge.actorService.localActor.avatar.Respawn();
        Debug.Log("Debug reset game runs");
		OnlyUpSceneManager.lastCheckpoint = entrancePoint;
        
		OnGameReset?.Invoke();
	}
}
