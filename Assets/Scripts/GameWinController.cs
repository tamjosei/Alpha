using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinController : MonoBehaviour
{
    public void OnClickContinue()
    {
        if (GlobalVariables.s_CurrentLevel == "Level 0")
        {
            SceneManager.LoadScene("Level 1");
            PlayerPrefs.SetInt("LevelUnlocked", 1);
            GlobalVariables.s_CurrentLevel = "Level 1";
        }
        else
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}
