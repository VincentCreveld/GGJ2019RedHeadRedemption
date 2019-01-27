using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalGameManager : MonoBehaviour
{
    [SerializeField]
    private Scene kitchenScene;
    [SerializeField]
    private Scene[] levels;
    public bool[] levelFinished;

    public void FinishLevel()
    {
        levelFinished[SceneManager.GetActiveScene().buildIndex] = true;
        SceneManager.LoadScene(kitchenScene.name);
    }

    public void GoToNextLevel()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            if (levelFinished[i] == false)
            {
                SceneManager.LoadScene(i);
                break;
            }
        }
    }
}
