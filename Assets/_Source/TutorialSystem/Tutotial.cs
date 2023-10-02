using System;
using UnityEngine;
using UnityEngine.UI;

namespace TutorialSystem
{
    public class Tutotial : MonoBehaviour
    {
        [SerializeField] private Sprite[] images;
        [SerializeField] private Image image;
        [SerializeField] private Button startButton;
        [SerializeField] private Button nextButton;
        [SerializeField] private Button prevButton;
        [SerializeField] private AudioSource clickAudio;

        private int imageIndex;

        private void Awake()
        {
            startButton.onClick.AddListener(StartGame);
            nextButton.onClick.AddListener(NextImage);
            prevButton.onClick.AddListener(PrevImage);
            prevButton.gameObject.SetActive(false);
            startButton.gameObject.SetActive(false);
            image.sprite = images[0];
        }

        private void NextImage()
        {
            clickAudio.Play();
            imageIndex++;
            image.sprite = images[imageIndex];
            if (imageIndex == images.Length-1)
            {
                nextButton.gameObject.SetActive(false);
                startButton.gameObject.SetActive(true);
            }
            if(imageIndex != 0 && !prevButton.gameObject.activeSelf)
                prevButton.gameObject.SetActive(true);
        }
        
        private void PrevImage()
        {
            clickAudio.Play();
            if (imageIndex == images.Length-1)
            {
                startButton.gameObject.SetActive(false);
                nextButton.gameObject.SetActive(true);
            }
            imageIndex--;
            image.sprite = images[imageIndex];
            if (imageIndex == 0)
            {
                prevButton.gameObject.SetActive(false);
            }
        }

        private void StartGame()
        {
            clickAudio.Play();
            Invoke("ManagerStartGame",0.05f);
        }
    
        private void ManagerStartGame()
        {
            GameManager.Instance.StartGame();
        }
    }
}
