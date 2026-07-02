using Reflex.Core;
using UnityEngine;

namespace Collectibles
{
    internal class GemInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField][Min(1)] private int _targetCount = 1;
        
        public void InstallBindings(ContainerBuilder builder) =>
            builder.RegisterValue(new Gem(max: _targetCount));
    }
}