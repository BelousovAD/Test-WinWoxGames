using Reflex.Attributes;
using TMPro;
using UnityEngine;

namespace Collectibles
{
    [RequireComponent(typeof(TMP_Text))]
    internal class ResourceAccumulatorTMPView : MonoBehaviour
    {
        [SerializeField] private string _format = "{0}/{1}";

        private TMP_Text _textField;
        private ResourceAccumulator _resourceAccumulator;
        private int _max;

        [Inject]
        private void Initialize(ResourceAccumulator resourceAccumulator) =>
            _resourceAccumulator = resourceAccumulator;

        private void Awake()
        {
            _textField = GetComponent<TMP_Text>();
            _max = _resourceAccumulator.Max;
        }

        private void OnEnable()
        {
            _resourceAccumulator.Changed += UpdateView;
            UpdateView();
        }

        private void OnDisable() =>
            _resourceAccumulator.Changed -= UpdateView;

        private void UpdateView(int value = 0) =>
            _textField.text = string.Format(_format, value, _max);
    }
}