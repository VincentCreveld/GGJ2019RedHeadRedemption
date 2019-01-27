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

    public void FinishLevel()
    {
        levelFinished[SceneManager.GetActiveScene().buildIndex] = true;
        SceneManager.LoadScene(kitchenSceneName);
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
