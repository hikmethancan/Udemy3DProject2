
using UnityEngine;

namespace UdemyProject2.Controllers
{
    public class FloorController : MonoBehaviour
    {
        private Material _material;
        [SerializeField]private float _speed;

        private void Awake()
        {
            _material = GetComponentInChildren<MeshRenderer>().material;
        }

        private void Update()
        {
            _material.mainTextureOffset += Vector2.down * Time.deltaTime * _speed;
        }
    }
}