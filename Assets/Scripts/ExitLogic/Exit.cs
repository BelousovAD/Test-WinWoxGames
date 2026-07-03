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

        private void OnEnable()
        {
            _gemAccumulator.Changed += UpdateView;
            UpdateView();
        }

        private void OnDisable() =>
            _gemAccumulator.Changed -= UpdateView;

        private void UpdateView(int value = 0)
        {
            if (_gemAccumulator.Value == _gemAccumulator.Max)
            {
                gameObject.SetActive(false);
            }
        }
    }
}