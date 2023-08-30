using System;
using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]  private ThirdPersonController m_Controller;
    [SerializeField] private GamePlayUIController m_UIController;
    [SerializeField] private int m_TotalKeys;

    private int m_CollectedKeys = 0;

    public static GameManager Instance;
    public static Action<string> a_OnKeyCollection;
    public static Action a_DoorEnter;

    
    
    private void Awake()
    {
        Instance = this;
        GamePlayUIController.OnPause += SetCharacterSpeed;
    }

    private void Start()
    {
        a_OnKeyCollection?.Invoke($"{m_CollectedKeys}/{m_TotalKeys}");
    }

    private void SetCharacterSpeed(float speed)
    {
        m_Controller.MoveSpeed = speed;
    }

    public void OnKeyCollection()
    {
        m_CollectedKeys++;
        a_OnKeyCollection?.Invoke($"{m_CollectedKeys}/{m_TotalKeys}");
        
    }


    public void OnDoorEnter()
    {
        if (m_CollectedKeys == m_TotalKeys)
        {
            m_UIController.EndGame(true);
        }
        else
        {
            a_DoorEnter?.Invoke();
        }
    }
    
}


public class GlobalVariables
{
    public static string s_CurrentLevel = "Level 0";
}