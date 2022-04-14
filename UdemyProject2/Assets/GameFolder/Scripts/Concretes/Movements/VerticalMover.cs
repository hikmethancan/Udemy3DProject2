using UdemyProject2.Controllers;
using UnityEngine;

namespace UdemyProject2.Movements
{
    public class VerticalMover
    {
        private EnemyController _enemyController;
        private float _moveSpeed = 10f;

        public VerticalMover(EnemyController enemyController)
        {
            _enemyController = enemyController;
        }

        public void FixedTick(float vertical = 1f)
        {
            _enemyController.transform.Translate(Vector3.back * Time.deltaTime * vertical * _moveSpeed);
        }
        
    }
}