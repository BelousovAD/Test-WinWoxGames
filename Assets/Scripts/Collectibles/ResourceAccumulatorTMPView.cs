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

        [Inject]
        private void Initialize(ResourceAccumulator resourceAccumulator) =>
            _resourceAccumulator = resourceAccumulator;

        private void Awake() =>
            _textField = GetComponent<TMP_Text>();

        private void OnEnable()
        {
            _resourceAccumulator.Changed += UpdateView;
            UpdateView();
        }

        private void OnDisable() =>
            _resourceAccumulator.Changed -= UpdateView;

        private void UpdateView() =>
            _textField.text = string.Format(_format, _resourceAccumulator.Value, _resourceAccumulator.Max);
    }
}