using UdemyProject2.Abstracts.Controllers;
using UdemyProject2.Abstracts.Movements;
using UnityEngine;

namespace UdemyProject2.Movements
{
    public class HorizontalMover : IMover
    {
        private IEntityController _playerController;
        private float _moveSpeed;
        private float _moveBoundary;

        public HorizontalMover(IEntityController entityController)
        {
            _playerController = entityController;
            _moveSpeed = _playerController.MoveSpeed;
            _moveBoundary = _playerController.MoveBoundary;
        }


        public void FixedTick(float direction)
        {
            if (direction == 0f) return;
            // var playerTransform = _playerController.transform;
            _playerController.transform.Translate(Vector3.right * direction * Time.deltaTime * _moveSpeed);

            var boundary = Mathf.Clamp(_playerController.transform.position.x, -_moveBoundary, _moveBoundary);

            _playerController.transform.position = new Vector3(boundary, _playerController.transform.position.y, 0f);
        }
    }
}