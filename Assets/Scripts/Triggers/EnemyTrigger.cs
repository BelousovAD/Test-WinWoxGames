using System;
using UnityEngine;

namespace Triggers
{
    [RequireComponent(typeof(Collider))]
    public class EnemyTrigger : MonoBehaviour
    {
        public event Action Triggered;

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.TryGetComponent(out EnemyTag _))
            {
                Triggered?.Invoke();
            }
        }
    }
}