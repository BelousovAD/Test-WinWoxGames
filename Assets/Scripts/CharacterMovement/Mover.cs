using Inputs;
using UnityEngine;

namespace CharacterMovement
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _speed = 3f;
        [SerializeField] private float _speedSprint = 6f;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private MonoBehaviour _inputReaderComponent;

        private IInput _input;
        private Vector3 _horizontalVelocity;
        private float _currentSpeed;

        private void OnValidate()
        {
            if (_inputReaderComponent is null)
            {
                return;
            }
            
            if (_inputReaderComponent is IInput inputReader)
            {
                _input = inputReader;
            }
            else
            {
                _inputReaderComponent = null;
                Debug.LogError($"Field:{nameof(_inputReaderComponent)} must inherited from {nameof(IInput)}");
            }
        }

        private void Awake() =>
            _currentSpeed = _speed;

        private void OnEnable()
        {
            _input.MoveRequested += UpdateHorizontalVelocity;
            _input.SprintRequested += UpdateSpeed;
        }

        private void OnDisable()
        {
            _input.MoveRequested -= UpdateHorizontalVelocity;
            _input.SprintRequested -= UpdateSpeed;
        }

        private void FixedUpdate() =>
            _rigidbody.linearVelocity = transform.rotation * _horizontalVelocity;

        private void UpdateHorizontalVelocity(Vector2 direction) =>
            _horizontalVelocity = new Vector3(direction.x, 0f, direction.y) * _currentSpeed;

        private void UpdateSpeed(bool isSprint)
        {
            _horizontalVelocity /= _currentSpeed;
            _currentSpeed = isSprint ? _speedSprint : _speed;
            _horizontalVelocity *= _currentSpeed;
        }
    }
}