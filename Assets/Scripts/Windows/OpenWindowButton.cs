using Reflex.Attributes;
using UnityEngine;

namespace Windows
{
    internal class OpenWindowButton : AbstractButton
    {
        [SerializeField] private string _windowId;
        [SerializeField][Min(0)] private int _countToClose;

        private IWindowService _windowService;

        [Inject]
        private void Initialize(IWindowService windowService) =>
            _windowService = windowService;

        protected override void HandleClick() =>
            _windowService.Open(_windowId, _countToClose);
    }
}