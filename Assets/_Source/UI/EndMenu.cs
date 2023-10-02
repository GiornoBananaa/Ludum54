using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    [SerializeField] private Button mainMenuButton, restartButton;
    [SerializeField] private AudioSource buttonAudio;
    [SerializeField] private TMP_Text timeText;

    private void Start()
    {
        restartButton.onClick.AddListener(StartGame);
        mainMenuButton.onClick.AddListener(ReturnToMenu);

        timeText.text = GameManager.Instance.TimeElapsed.ToString("F2",CultureInfo.InvariantCulture);
    }
    
    private void StartGame()
    {
        if(buttonAudio != null)buttonAudio.Play();
        Invoke("ManagerStartGame",0.07f);
    }
    
    private void ManagerStartGame()
    {
        GameManager.Instance.StartGame();
    }
    
    private void ReturnToMenu()
    {
        if(buttonAudio != null)buttonAudio.Play();
        Invoke("ManagerReturnToMainMenu",0.07f);
    }
    
    private void ManagerReturnToMainMenu()
    {
        GameManager.Instance.ReturnToMainMenu();
    }
}
