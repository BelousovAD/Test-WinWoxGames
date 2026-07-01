using Inputs;
using UnityEngine;

namespace PlayerMovement
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _speed = 1f;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private MonoBehaviour _inputReaderComponent;

        private IInputReader _inputReader;
        private Vector3 _horizontalVelocity;

        private void OnValidate()
        {
            if (_inputReaderComponent is null)
            {
                return;
            }
            
            if (_inputReaderComponent is IInputReader inputReader)
            {
                _inputReader = inputReader;
            }
            else
            {
                _inputReaderComponent = null;
                Debug.LogError($"Field:{nameof(_inputReaderComponent)} must inherited from {nameof(IInputReader)}");
            }
        }

        private void OnEnable() =>
            _inputReader.MoveRequested += UpdateHorizontalVelocity;

        private void OnDisable() =>
            _inputReader.MoveRequested -= UpdateHorizontalVelocity;

        private void FixedUpdate() =>
            _rigidbody.linearVelocity = transform.rotation * _horizontalVelocity;

        private void UpdateHorizontalVelocity(Vector2 direction) =>
            _horizontalVelocity = new Vector3(direction.x, 0f, direction.y) * _speed;
    }
}