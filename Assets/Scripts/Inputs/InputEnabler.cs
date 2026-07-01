using Reflex.Attributes;
using UnityEngine;

namespace Inputs
{
    public class InputEnabler : MonoBehaviour
    {
        private InputReader _inputReader;

        [Inject]
        private void Initialize(InputReader inputReader) =>
            _inputReader = inputReader;

        private void OnEnable()
        {
            Cursor.lockState = CursorLockMode.Locked;
            _inputReader.Enable();
        }

        private void OnDisable()
        {
            _inputReader.Disable();
            Cursor.lockState = CursorLockMode.None;
        }
    }
}