using UnityEngine;

namespace Inputs
{
    public class CursorLocker : MonoBehaviour
    {
        [SerializeField] private bool _lock;
        
        private void OnEnable() =>
            UpdateCursorState();

        private void OnDisable() =>
            UpdateCursorState();

        private void UpdateCursorState()
        {
            Cursor.lockState = _lock ? CursorLockMode.Locked : CursorLockMode.None;
            _lock = !_lock;
        }
    }
}