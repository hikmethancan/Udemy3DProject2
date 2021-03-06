using UdemyProject2.Managers;
using UnityEngine;

namespace UdemyProject2.UI
{
    public class MenuPanel : MonoBehaviour
    {
        public void StartButton()
        {
            GameManager.Instance.LoadScene("Game");
        }

        public void ExitButton()
        {
            GameManager.Instance.ExitGame();
        }
    }
}