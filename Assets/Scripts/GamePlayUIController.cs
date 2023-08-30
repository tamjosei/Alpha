using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayUIController : MonoBehaviour
{
    [SerializeField] private GameObject m_PauseScreen;
    [SerializeField] private GameObject m_GameplayScreen;
    [SerializeField] private GameObject m_RedScreen;
    [SerializeField] private GameObject m_Toast;
    [SerializeField] private TextMeshProUGUI m_TimerText;
    [SerializeField] private TextMeshProUGUI m_KeysText;


    public static Action<float> OnPause;


    public void OnPauseClick()
    {
        m_PauseScreen.SetActive(true);
        m_GameplayScreen.SetActive(false);
        isTimerRunning = false;
        OnPause?.Invoke(0f);
    }

    public void OnResumeClick()
    {
        m_PauseScreen.SetActive(false);
        m_GameplayScreen.SetActive(true);
        isTimerRunning = true;
        OnPause?.Invoke(4f);
    }

    public void OnMainMenuClicked()
    {
        SceneManager.LoadScene("Main Menu");
    }


    public float totalTimeInSeconds = 120f; // Total time in seconds (2 minutes)
    private float currentTime;
    private bool isTimerRunning = true;

    private void Awake()
    {
        GameManager.a_OnKeyCollection += OnKeyCollection;
        GameManager.a_DoorEnter += ShowToast;
    }

    private void Start()
    {
        currentTime = totalTimeInSeconds;
    }


    private void OnKeyCollection(string text)
    {
        m_KeysText.text = text;
    }

    private void Update()
    {
        if (!isTimerRunning) return;


        currentTime -= Time.deltaTime;

        //Check for Red Screen
        if (currentTime <= 15f && !m_RedScreen.activeInHierarchy)
            m_RedScreen.SetActive(true);

        // Check if time is up
        if (currentTime <= 0f)
        {
            currentTime = 0f;
            EndGame();
        }

        UpdateTimerDisplay();
    }

    private void UpdateTimerDisplay()
    {
        var minutes = Mathf.FloorToInt(currentTime / 60f);
        var seconds = Mathf.FloorToInt(currentTime % 60f);
        m_TimerText.text = $"{minutes:00}:{seconds:00}";
    }

    public void EndGame(bool isWin = false)
    {
        isTimerRunning = false;
        OnPause?.Invoke(0f);
        m_GameplayScreen.SetActive(false);
        SceneManager.LoadScene(isWin ? "Game Win" : "Game Over", LoadSceneMode.Additive);
    }

    private void ShowToast()
    {
        m_Toast.SetActive(true);
        Invoke(nameof(HideToast), 0.5f);
    }

    private void HideToast()
    {
        m_Toast.SetActive(false);
    }
}