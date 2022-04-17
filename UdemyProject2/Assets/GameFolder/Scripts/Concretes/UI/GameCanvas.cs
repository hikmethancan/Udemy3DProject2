using System;
using UdemyProject2.Managers;
using UnityEngine;

namespace UdemyProject2.UI
{
    public class GameCanvas : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverPanel;

        private void Awake()
        {
            _gameOverPanel.SetActive(false);
        }

        private void OnEnable()
        {
            GameManager.Instance.OnGameStop += HandleOnGameStop;
        }
        private void OnDisable()
        {
            GameManager.Instance.OnGameStop -= HandleOnGameStop;
        }
        private void HandleOnGameStop()
        {
            _gameOverPanel.SetActive(true);
        }
    }
}