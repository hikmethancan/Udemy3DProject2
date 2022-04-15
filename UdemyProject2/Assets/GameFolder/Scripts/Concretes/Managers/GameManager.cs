using UdemyProject2.Utilities;
using UnityEngine;

namespace UdemyProject2.Managers
{
    public class GameManager : SingletonObjects<GameManager>
    {
        private void Awake()
        {
            SingletonObject(this);
        }

        public void StopGame()
        {
            // Time.timeScale stopped the game
            Time.timeScale = 0f;
        }
    }
}