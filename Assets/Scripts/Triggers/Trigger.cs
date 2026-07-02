using System;
using UnityEngine;

namespace Triggers
{
    [RequireComponent(typeof(Collider))]
    public class Trigger : MonoBehaviour
    {
        [SerializeField] private TagType _type;
        
        public event Action<bool> StateChanged;

        public Tag Tag { get; private set; }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.TryGetComponent(out Tag tagComponent) && tagComponent.Type == _type)
            {
                Tag = tagComponent;
                StateChanged?.Invoke(true);
            }
        }

        private void OnTriggerExit(Collider collision)
        {
            if (collision.TryGetComponent(out Tag tagComponent) && tagComponent.Type == _type)
            {
                Tag = tagComponent;
                StateChanged?.Invoke(false);
            }
        }
    }
}