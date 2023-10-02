using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    [SerializeField] private Button mainMenuButton, restartButton;
    [SerializeField] private AudioSource buttonAudio;

    private void Start()
    {
        restartButton.onClick.AddListener(StartGame);
        mainMenuButton.onClick.AddListener(ReturnToMenu);
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
