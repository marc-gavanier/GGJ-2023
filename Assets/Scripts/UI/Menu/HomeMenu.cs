using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Menu
{
    public class HomeMenu : MonoBehaviour
    {
        public void PlayGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
