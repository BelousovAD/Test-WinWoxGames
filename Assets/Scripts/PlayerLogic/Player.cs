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

        private Gem _gem;

        [Inject]
        private void Initialize(Gem gem) =>
            _gem = gem;

        private void OnEnable() =>
            _picker.Picking += HandlePickUp;

        private void OnDisable() =>
            _picker.Picking -= HandlePickUp;

        private void HandlePickUp(IPickable pickable)
        {
            if (pickable is PickableGem.Gem)
            {
                _gem.Earn(EarnAmount);
            }
        }
    }
}