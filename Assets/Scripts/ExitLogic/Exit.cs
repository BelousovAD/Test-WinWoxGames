using Collectibles;
using Reflex.Attributes;
using UnityEngine;

namespace ExitLogic
{
    internal class Exit : MonoBehaviour
    {
        private Gem _gem;

        [Inject]
        private void Initialize(Gem gem) =>
            _gem = gem;

        private void OnEnable()
        {
            _gem.Changed += UpdateView;
            UpdateView();
        }

        private void OnDisable() =>
            _gem.Changed -= UpdateView;

        private void UpdateView()
        {
            if (_gem.Value == _gem.Max)
            {
                gameObject.SetActive(false);
            }
        }
    }
}