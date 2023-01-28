using UnityEngine;
using UnityEngine.Audio;

namespace UI.Menu
{
    public class SettingsMenu : MonoBehaviour
    {
        public void SetFullScreen(bool isFullScreen) => Screen.fullScreen = isFullScreen;
    }
}
