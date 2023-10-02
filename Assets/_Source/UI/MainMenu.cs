using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        [SerializeField] private AudioSource buttonAudio;

        private void Start()
        {
            startButton.onClick.AddListener(StartGame);
        }

        private void StartGame()
        {
            if(buttonAudio != null)buttonAudio.Play();
        
            Invoke("ManagerStartGame",0.07f);
        }
    
        private void ManagerStartGame()
        {
            GameManager.Instance.StartTutorial();
        }
    }
}
