using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Inputs
{
    internal class InputReader
    {
        private readonly Input _input;

        public InputReader(Input input) =>
            _input = input;

        public event Action<Vector2> MoveRequested;

        public event Action<Vector2> RotateRequested;

        public void Enable()
        {
            _input.Enable();
            _input.Player.Move.performed += RequestMove;
            _input.Player.Move.canceled += RequestMove;
            _input.Player.Look.performed += RequestRotate;
        }

        public void Disable()
        {
            _input.Disable();
            _input.Player.Move.performed -= RequestMove;
            _input.Player.Move.canceled -= RequestMove;
            _input.Player.Look.performed -= RequestRotate;
        }

        private void RequestMove(InputAction.CallbackContext context) =>
            MoveRequested?.Invoke(context.ReadValue<Vector2>());
        
        private void RequestRotate(InputAction.CallbackContext context) =>
            RotateRequested?.Invoke(context.ReadValue<Vector2>());
    }
}