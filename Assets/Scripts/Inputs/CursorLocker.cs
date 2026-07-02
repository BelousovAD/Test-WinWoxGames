using Reflex.Attributes;
using UnityEngine;

namespace Inputs
{
    public class CursorLocker : MonoBehaviour
    {
        [SerializeField] private bool _lock;

        private Input _input;

        [Inject]
        private void Initialize(Input input) =>
            _input = input;
        
        private void OnEnable() =>
            UpdateCursorState();

        private void OnDisable() =>
            UpdateCursorState();

        private void UpdateCursorState()
        {
            if (_lock)
            {
                Cursor.lockState = CursorLockMode.Locked;
                _input.Player.Enable();
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                _input.Player.Disable();
            }
            
            _lock = !_lock;
        }
    }
}