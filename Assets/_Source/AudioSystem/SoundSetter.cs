using UnityEngine;

namespace AudioSystem
{
    public class SoundSetter : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        private float _maxSound;

        private void Start()
        {
            if (_audioSource != null && Audio.Instance != null)
            {
                _audioSource = GetComponent<AudioSource>();
                _maxSound = _audioSource.volume;
                _audioSource.volume *= Audio.Instance.SoundVolume;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }

        private void OnSoundVolumeChange()
        {
            _audioSource.volume = Audio.Instance.SoundVolume * _maxSound;
        }

        private void OnEnable()
        {
            Audio.OnSoundVolumeChange += OnSoundVolumeChange;
        }

        private void OnDisable()
        {
            Audio.OnSoundVolumeChange -= OnSoundVolumeChange;
        }
    }
}
