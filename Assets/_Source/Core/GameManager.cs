using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public enum Scenes : int
    {
        MainMenu,
        Game,
        Win,
        Lose,
        Tutorial,
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

    }
    public void ReturnToMainMenu()
    {
        LoadScene(Scenes.MainMenu);
    }

    public void StartGame()
    {
        LoadScene(Scenes.Game);
    }
    public void StartTutorial()
    {
        LoadScene(Scenes.Tutorial);
    }
    public void LoseGame()
    {
        LoadScene(Scenes.Lose);
    }

    public void WinGame()
    {
        LoadScene(Scenes.Win);
    }

    private void LoadScene(Scenes scene)
    {
        SceneManager.LoadScene((int)scene);
    }
}
