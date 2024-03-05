using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class GameSceneManager : MonoBehaviour
    {
        public void RestartScene()
        {
            Time.timeScale = 1;
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }

        public void ChangeScene(string _sceneName)
        {
            Time.timeScale = 1;
            SceneManager.LoadSceneAsync(_sceneName);
        }

        public void QuitGame()
        {
            PlayerPrefs.DeleteAll();
            Application.Quit();
        }
    }
}

