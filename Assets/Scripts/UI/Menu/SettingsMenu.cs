using UnityEngine;
using UnityEngine.Audio;

namespace UI.Menu
{
    public class SettingsMenu : MonoBehaviour
    {
        public AudioMixer audioMixer;

        public void SetMasterVolume(float volume)
        {
            audioMixer.SetFloat("MasterVolume", volume);
        }
        
        public void SetSoundVolume(float volume)
        {
            audioMixer.SetFloat("SoundVolume", volume);
        }
        
        public void SetMusicVolume(float volume)
        {
            audioMixer.SetFloat("MusicVolume", volume);
        }
        
        public void SetFullScreen(bool isFullScreen)
        {
            Screen.fullScreen = isFullScreen;
        }
    }
}
