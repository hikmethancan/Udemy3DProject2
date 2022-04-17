using System;
using UdemyProject2.Managers;
using UdemyProject2.Movements;
using UnityEngine;

namespace UdemyProject2.Controllers
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private float _maxLifeTime = 10f;
        
        private VerticalMover _verticalMover;
        private float _currentLifeTime;
        
        private void Awake()
        {
            _verticalMover = new VerticalMover(this);
        }


        private void Update()
        {
            _currentLifeTime += Time.deltaTime;

            if (_currentLifeTime > _maxLifeTime)
            {
                _currentLifeTime = 0f;

                KillYourSelf();
            }
        }

        private void KillYourSelf()
        {
            EnemyManager.Instance.SetPool(this);
        }

        private void FixedUpdate()
        {
            _verticalMover.FixedTick();
        }

    }
}