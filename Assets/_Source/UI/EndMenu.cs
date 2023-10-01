using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    [SerializeField] private Button mainMenuButton, restartButton;

    private void Start()
    {
        restartButton.onClick.AddListener(() => { GameManager.Instance.StartGame(); });
        mainMenuButton.onClick.AddListener(() => { GameManager.Instance.ReturnToMainMenu(); });
    }
}
