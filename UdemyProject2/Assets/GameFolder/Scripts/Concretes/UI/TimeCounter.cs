using TMPro;
using UnityEngine;

namespace UdemyProject2.UI
{
    public class TimeCounter : MonoBehaviour
    {
        private TMP_Text _text;
        private float _currentTime;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
        }

        private void Update()
        {
            _currentTime += Time.deltaTime;
            _text.text = _currentTime.ToString("0");
        }
    }
}