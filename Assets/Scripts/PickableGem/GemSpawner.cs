using Pickable;
using UnityEngine;

namespace PickableGem
{
    public class GemSpawner : AbstractPickableSpawner<Gem>
    {
        private void Start() =>
            SpawnAtPoints();

        protected override void PickedHandler(IPickable pickable)
        {
            base.PickedHandler(pickable);
            Destroy((pickable as Gem)!.gameObject);
        }

#if UNITY_EDITOR
        [ContextMenu(nameof(RefreshPointsArray))]
        protected override void RefreshPointsArray() =>
            base.RefreshPointsArray();
#endif
    }
}
