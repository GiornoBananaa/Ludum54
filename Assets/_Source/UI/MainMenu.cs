using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button startButton;

    private void Start()
    {
        startButton.onClick.AddListener(() => GameManager.Instance.StartGame());
    }
}
