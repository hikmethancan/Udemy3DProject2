using System;
using UdemyProject2.Abstracts.Inputs;
using UdemyProject2.Inputs;
using UdemyProject2.Managers;
using UdemyProject2.Movements;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UdemyProject2.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _moveBoundary = 4.5f;
        [SerializeField] private float _moveSpeed = 10f;
        [SerializeField] private float _jumpForce;
        [SerializeField] private bool _isJump;
        [SerializeField] private bool _isDead;
        
        private HorizontalMover _horizontalMover;
        private JumpWithRigidbody _jump;
        private IInputReader _ınput;
        private float _horizontal;

        public float MoveSpeed => _moveSpeed;
        public float MoveBoundary => _moveBoundary;
        private void Awake()
        {
            _horizontalMover = new HorizontalMover(this);
            _jump = new JumpWithRigidbody(this);
            _ınput = new InputReader(GetComponent<PlayerInput>());
        }

        private void Update()
        {
            if(_isDead) return;
            
             _horizontal = _ınput.Horizontal ;

             if (_ınput.Jump)
             {
                 _isJump = true;
             }
        }

        private void FixedUpdate()
        {
            if(_isDead) return;
            
            _horizontalMover.TickFixed(_horizontal);

            if (_isJump)
            {
                _jump.TickFixed(_jumpForce);
            }
            _isJump = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            var enemyController = other.gameObject.GetComponent<EnemyController>();

            if (enemyController != null)
            {
                GameManager.Instance.StopGame();
                _isDead = true;
            }
        }
    }
}