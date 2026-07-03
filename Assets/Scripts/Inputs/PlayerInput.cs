using System;
using Reflex.Attributes;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Inputs
{
    internal class PlayerInput : MonoBehaviour, IInput
    {
        private Input _input;

        public event Action<Vector2> MoveRequested;

        public event Action<Vector2> RotateRequested;

        public event Action<bool> SprintRequested;

        [Inject]
        private void Initialize(Input input) =>
            _input = input;

        public void OnEnable()
        {
            _input.Enable();
            _input.Player.Move.performed += RequestMove;
            _input.Player.Move.canceled += RequestMove;
            _input.Player.Look.performed += RequestRotate;
            _input.Player.Sprint.performed += RequestSprint;
            _input.Player.Sprint.canceled += RequestSprint;
        }

        public void OnDisable()
        {
            _input.Disable();
            _input.Player.Move.performed -= RequestMove;
            _input.Player.Move.canceled -= RequestMove;
            _input.Player.Look.performed -= RequestRotate;
            _input.Player.Sprint.performed -= RequestSprint;
            _input.Player.Sprint.canceled -= RequestSprint;
        }

        private void RequestMove(InputAction.CallbackContext context) =>
            MoveRequested?.Invoke(context.ReadValue<Vector2>());
        
        private void RequestRotate(InputAction.CallbackContext context) =>
            RotateRequested?.Invoke(context.ReadValue<Vector2>());

        private void RequestSprint(InputAction.CallbackContext context) =>
            SprintRequested?.Invoke(context.ReadValueAsButton());
    }
}