using Reflex.Attributes;
using TMPro;
using UnityEngine;

namespace Collectibles
{
    [RequireComponent(typeof(TMP_Text))]
    internal class GemTMPView : MonoBehaviour
    {
        [SerializeField] private string _format = "{0}/{1}";

        private TMP_Text _textField;
        private Gem _gem;

        [Inject]
        private void Initialize(Gem gem) =>
            _gem = gem;

        private void Awake() =>
            _textField = GetComponent<TMP_Text>();

        private void OnEnable()
        {
            _gem.Changed += UpdateView;
            UpdateView();
        }

        private void OnDisable() =>
            _gem.Changed -= UpdateView;

        private void UpdateView() =>
            _textField.text = string.Format(_format, _gem.Value, _gem.Max);
    }
}