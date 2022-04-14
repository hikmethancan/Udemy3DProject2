using UdemyProject2.Controllers;
using UnityEngine;

namespace UdemyProject2.Movements
{
    public class JumpWithRigidbody
    {
        private Rigidbody _rigidbody;
        public bool CanJump => _rigidbody.velocity.y != 0f;

        public JumpWithRigidbody(PlayerController playerController)
        {
            _rigidbody = playerController.GetComponent<Rigidbody>();
        }

        public void TickFixed(float jumpForce)
        {
            if(CanJump) return;
            
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(Vector3.up * jumpForce);
        }
        
    }
}