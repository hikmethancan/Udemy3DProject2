using System;
using UdemyProject2.Movements;
using UnityEngine;

namespace UdemyProject2.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 10f;
        [SerializeField] private float _direction;
        [SerializeField] private float _jumpForce;
        [SerializeField] private bool _isJump;
        
        private HorizontalMover _horizontalMover;
        private JumpWithRigidbody _jump;
        private void Awake()
        {
            _horizontalMover = new HorizontalMover(this);
            _jump = new JumpWithRigidbody(this);
        }


        private void FixedUpdate()
        {
            _horizontalMover.TickFixed(_direction,_moveSpeed);

            if (_isJump)
            {
                _jump.TickFixed(_jumpForce);
            }
            _isJump = false;

        }
    }
}