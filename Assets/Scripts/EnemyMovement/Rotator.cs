using Inputs;
using UnityEngine;

namespace EnemyMovement
{
    internal class Rotator : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour _inputReaderComponent;
        [SerializeField] private Transform _target;

        private IInputReader _inputReader;
        private float _horizontalAngle;

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
            _inputReader.RotateRequested += Rotate;

        private void OnDisable() =>
            _inputReader.RotateRequested -= Rotate;
        
        private void Rotate(Vector2 delta)
        {
            _horizontalAngle += delta.x;
            _target.rotation = Quaternion.AngleAxis(_horizontalAngle, Vector3.up);
        }
    }
}