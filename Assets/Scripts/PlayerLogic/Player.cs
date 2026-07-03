using Collectibles;
using Pickable;
using Reflex.Attributes;
using UnityEngine;

namespace PlayerLogic
{
    public class Player : MonoBehaviour
    {
        private const int EarnAmount = 1;
        
        [SerializeField] private Picker _picker;

        private ResourceAccumulator _gemAccumulator;

        [Inject]
        private void Initialize(ResourceAccumulator resourceAccumulator) =>
            _gemAccumulator = resourceAccumulator;

        private void OnEnable() =>
            _picker.Picking += HandlePickUp;

        private void OnDisable() =>
            _picker.Picking -= HandlePickUp;

        private void HandlePickUp(IPickable pickable)
        {
            if (pickable is PickableGem.Gem)
            {
                _gemAccumulator.Collect(EarnAmount);
            }
        }
    }
}