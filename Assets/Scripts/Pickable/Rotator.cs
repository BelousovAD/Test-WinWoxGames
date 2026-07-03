using UnityEngine;

namespace Pickable
{
    internal class Rotator : MonoBehaviour
    {
        [SerializeField] private Vector3 _rotationPerSecond;
        [SerializeField] private bool _isLocal;

        private void Update() =>
            transform.Rotate(_rotationPerSecond * Time.deltaTime, _isLocal ? Space.Self : Space.World);
    }
}