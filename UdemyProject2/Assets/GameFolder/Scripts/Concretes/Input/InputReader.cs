using UdemyProject2.Abstracts.Inputs;
using UnityEngine.InputSystem;

namespace UdemyProject2.Inputs
{
    public class InputReader : IInputReader
    {
        private PlayerInput _playerInput;

        public float Horizontal { get; private set; }
        public bool Jump { get; private set; }

        public InputReader(PlayerInput playerInput)
        {
            _playerInput = playerInput;
            _playerInput.currentActionMap.actions[0].performed += OnHorizontalMove;
            _playerInput.currentActionMap.actions[1].started += OnJump;
            _playerInput.currentActionMap.actions[1].canceled += OnJump;
        }

        private void OnJump(InputAction.CallbackContext obj)
        {
            Jump = obj.ReadValueAsButton();
        }

        private void OnHorizontalMove(InputAction.CallbackContext obj)
        {
            Horizontal = obj.ReadValue<float>();
        }
    }
}