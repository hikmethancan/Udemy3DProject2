using UdemyProject2.Abstracts.Controllers;
using UdemyProject2.Abstracts.Movements;
using UnityEngine;

namespace UdemyProject2.Movements
{
    public class VerticalMover : IMover
    {
        private IEntityController _enemyController;
        private float _moveSpeed = 10f;

        public VerticalMover(IEntityController entityController)
        {
            _enemyController = entityController;
        }

        public void FixedTick(float vertical = 1f)
        {
            _enemyController.transform.Translate(Vector3.back * Time.deltaTime * vertical * _moveSpeed);
        }
        
    }
}