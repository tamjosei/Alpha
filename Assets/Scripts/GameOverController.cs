using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
   public void OnRestartClick()
   {
      SceneManager.LoadScene(GlobalVariables.s_CurrentLevel);
   }

   public void OnMainMenuClick()
   {
      SceneManager.LoadScene("Main Menu");
   }
}
