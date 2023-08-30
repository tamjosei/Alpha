using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Image[] m_SoundImages;
    public GameObject m_HomeScreen;
    public GameObject m_LevelSelectionScreen;





    public void OnSoundClick()
    {
        if (SoundManager.instance.isMusicOn)
        {
            m_SoundImages[0].enabled = false;
            m_SoundImages[1].enabled = true;
        }
        else
        {
            m_SoundImages[0].enabled = true;
            m_SoundImages[1].enabled = false;
        }

        SoundManager.instance.isMusicOn = !SoundManager.instance.isMusicOn;
        SoundManager.instance.PlayBackGroundSound(SoundManager.instance.isMusicOn);
    }

    public void OnPlayClick()
    {
        m_LevelSelectionScreen.SetActive(true);
        m_HomeScreen.SetActive(false);
    }


    public void OnLevelOneClick()
    {
        SceneManager.LoadScene("Level 0");
        GlobalVariables.s_CurrentLevel = "Level 0";
    }

    public void OnLevelTwoClick()
    {
       bool isUnlocked = (1  ==  PlayerPrefs.GetInt("LevelUnlocked",0));
       
       if (isUnlocked)
       {
           SceneManager.LoadScene("Level 1");
           GlobalVariables.s_CurrentLevel = "Level 1";
       }
    }

    public void OnBackClick()
    {
        m_LevelSelectionScreen.SetActive(false);
        m_HomeScreen.SetActive(true);
    }
}
