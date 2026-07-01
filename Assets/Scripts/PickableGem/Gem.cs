using System;
using Pickable;
using UnityEngine;

namespace PickableGem
{
    public class Gem : MonoBehaviour, IPickable
    {
        public event Action<IPickable> Picked;

        public void PickUp() =>
            Picked?.Invoke(this);
    }
}
