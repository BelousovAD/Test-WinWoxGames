using Collectibles;
using Reflex.Attributes;
using UnityEngine;

namespace ExitLogic
{
    internal class Exit : MonoBehaviour
    {
        private ResourceAccumulator _gemAccumulator;

        [Inject]
        private void Initialize(ResourceAccumulator resourceAccumulator) =>
            _gemAccumulator = resourceAccumulator;

        private void OnEnable() =>
            _gemAccumulator.Filled += DisableObject;

        private void OnDisable() =>
            _gemAccumulator.Filled -= DisableObject;

        private void DisableObject() =>
            gameObject.SetActive(false);
    }
}