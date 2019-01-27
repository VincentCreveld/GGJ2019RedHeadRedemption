using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalGameManager : MonoBehaviour
{
    [SerializeField]
    private string kitchenSceneName;
    [SerializeField]
    private string[] levelNames;
    [HideInInspector]
    public bool[] levelFinished;
    [SerializeField]
    private KitchenManager kitchenManager;
    public bool[] narrationClipsPlayed;

    public void FinishLevel()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        levelFinished[SceneManager.GetActiveScene().buildIndex] = true;
        SceneManager.LoadScene(kitchenSceneName);
        kitchenManager.PlayNarration(index);
    }

    public void GoToNextLevel()
    {
        for (int i = 0; i < levelNames.Length; i++)
        {
            if (levelFinished[i] == false)
            {
                SceneManager.LoadScene(i);
                break;
            }
        }
    }
}
