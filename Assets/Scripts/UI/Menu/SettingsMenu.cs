using UnityEngine;
using UnityEngine.Audio;

namespace UI.Menu
{
    public class SettingsMenu : MonoBehaviour
    {
        public AudioMixer audioMixer;

        private void ApplyVolumeTo(string groupName, float volume) => audioMixer.SetFloat(groupName, volume <= -40 ? -80 : volume);

        public void SetMasterVolume(float volume) => ApplyVolumeTo("MasterVolume", volume);

        public void SetSoundVolume(float volume) => ApplyVolumeTo("SoundVolume", volume);

        public void SetMusicVolume(float volume) => ApplyVolumeTo("MusicVolume", volume);

        public void SetFullScreen(bool isFullScreen) => Screen.fullScreen = isFullScreen;
    }
}
