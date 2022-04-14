using UdemyProject2.Controllers;
using UnityEngine;

namespace UdemyProject2.Movements
{
    public class HorizontalMover
    {
        private PlayerController _playerController;
        private float _moveSpeed;
        private float _moveBoundary;
        public HorizontalMover(PlayerController playerController)
        {
            _playerController = playerController;
            _moveSpeed = _playerController.MoveSpeed;
            _moveBoundary = _playerController.MoveBoundary;
        }

        public void TickFixed(float horizontal)
        {
            if (horizontal == 0f) return;
            // var playerTransform = _playerController.transform;
            _playerController.transform.Translate(Vector3.right * horizontal * Time.deltaTime * _moveSpeed);

            var boundary = Mathf.Clamp(_playerController.transform.position.x, -_moveBoundary, _moveBoundary);

            _playerController.transform.position = new Vector3(boundary, _playerController.transform.position.y, 0f);
        }
    }
}