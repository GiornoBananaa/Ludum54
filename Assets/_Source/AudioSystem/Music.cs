using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AudioSystem
{
    public class Music : MonoBehaviour
    {
        [SerializeField] private AudioClip[] _scenesMusic;
        [SerializeField] private AudioSource _music;
        [Range(0,1)][SerializeField] private float _musicVolumeDeafult;

        public static Action OnSoundVolumeChange;
        
        
        public static Music Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                return;
            }
            Destroy(gameObject);
        }

        private void Start()
        {
            _music.transform.parent = null;
            _music.volume = MusicVolume;
            SetMusicClip(SceneManager.GetActiveScene().buildIndex);
        }
    
        private void OnLevelWasLoaded(int level)
        {
            SetMusicClip(level);
        }

        private bool SetMusicClip(int level)
        {
            if (_scenesMusic[level] != null)
            {
                if (_music.clip is null || _scenesMusic[level].name != _music.clip.name)
                {
                    _music.clip = _scenesMusic[level];
                    _music.Play();
                }

                return true;
            }
            else
            {
                _music.clip = null;
            
                return false;
            }
        }
    
        public void MuteAudio(bool value)
        {
            Mute = value;
        }
        public void MusicVolumeChange(float value)
        {
            MusicVolume = value;
        }
        public void SoundVolumeChange(float value)
        {
            SoundVolume = value;
            OnSoundVolumeChange.Invoke();
        }


        public bool Mute
        {
            get
            {
                return PlayerPrefs.GetInt("Mute", 0) == 1 ? true : false;
            }
            set
            {
                _music.mute = !value;
                PlayerPrefs.SetInt("Mute", value ? 1 : 0);
            }
        }

        public float SoundVolume
        {
            get
            {
                return PlayerPrefs.GetFloat("Sound", 1f);
            }
            private set
            {
                PlayerPrefs.SetFloat("Sound", (float)value);
            }
        }

        public float MusicVolume
        {
            get
            {
                return PlayerPrefs.GetFloat("Music", _musicVolumeDeafult);
            }
            private set
            {
                PlayerPrefs.SetFloat("Music", (float)value);
                _music.volume = value;
            }
        }
    }
}
