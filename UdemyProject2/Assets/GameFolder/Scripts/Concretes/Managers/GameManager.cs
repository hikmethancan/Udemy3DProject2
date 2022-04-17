using System.Collections;
using UdemyProject2.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UdemyProject2.Managers
{
    public class GameManager : SingletonObjects<GameManager>
    {
        public event System.Action OnGameStop;
        private void Awake()
        {
            SingletonObject(this);
        }

        public void StopGame()
        {
            // Time.timeScale stopped the game
            Time.timeScale = 0f;
            OnGameStop?.Invoke();
        }

        public void LoadScene(string sceneName)
        {
            Debug.Log("Load Scene");
            StartCoroutine(SceneLoaderAsync(sceneName));
        }

        private IEnumerator SceneLoaderAsync(string sceneName)
        {
            //Time.timeScale = 1f when load scene timeScale must be 1;
            Time.timeScale = 1f;
            yield return SceneManager.LoadSceneAsync(sceneName);
        }

        public void ExitGame()
        {
            Debug.Log("Exit Game");
            Application.Quit();
        }
    }
}