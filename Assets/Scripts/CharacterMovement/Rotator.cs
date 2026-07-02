using Inputs;
using UnityEngine;

namespace CharacterMovement
{
    internal class Rotator : MonoBehaviour
    {
        [SerializeField, Range(-89f, 0f)] private float _minVerticalAngle = -89f;
        [SerializeField, Range(1f, 89f)] private float _maxVerticalAngle = 89f;
        [SerializeField] private MonoBehaviour _inputReaderComponent;
        [SerializeField] private Camera _camera;
        [SerializeField] private Transform _target;

        private IInputReader _inputReader;
        private float _horizontalAngle;
        private float _verticalAngle;
        private Transform _cameraTransform;

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

        private void Awake()
        {
            if (_camera)
            {
                _cameraTransform = _camera.transform;
            }
        }

        private void OnEnable() =>
            _inputReader.RotateRequested += Rotate;

        private void OnDisable() =>
            _inputReader.RotateRequested -= Rotate;
        
        private void Rotate(Vector2 delta)
        {
            _horizontalAngle += delta.x;
            _target.rotation = Quaternion.AngleAxis(_horizontalAngle, Vector3.up);

            if (_cameraTransform is not null)
            {
                _verticalAngle -= delta.y;
                _verticalAngle = Mathf.Clamp(_verticalAngle, _minVerticalAngle, _maxVerticalAngle);
                _cameraTransform.forward = Quaternion.AngleAxis(_verticalAngle, _target.right) * _target.forward;
            }
        }
    }
}