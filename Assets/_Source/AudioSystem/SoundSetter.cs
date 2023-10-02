using UnityEngine;

namespace AudioSystem
{
    public class SoundSetter : MonoBehaviour
    {
        private AudioSource _audioSource;
        private float _maxSound;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _maxSound = _audioSource.volume;
            _audioSource.volume *= Audio.Instance.SoundVolume;
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
