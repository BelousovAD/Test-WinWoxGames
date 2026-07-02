using System;
using UnityEngine;

namespace Triggers
{
    [RequireComponent(typeof(Collider))]
    public class PlayerTrigger : MonoBehaviour
    {
        public event Action<bool> StateChanged;

        public Transform PlayerTransform { get; private set; }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.TryGetComponent(out PlayerTag playerTag))
            {
                PlayerTransform = playerTag.transform;
                StateChanged?.Invoke(true);
            }
        }

        private void OnTriggerExit(Collider collision)
        {
            if (collision.TryGetComponent(out PlayerTag _))
            {
                PlayerTransform = null;
                StateChanged?.Invoke(false);
            }
        }
    }
}
