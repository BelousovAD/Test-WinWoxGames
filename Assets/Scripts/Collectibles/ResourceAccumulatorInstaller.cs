using Reflex.Core;
using UnityEngine;

namespace Collectibles
{
    internal class ResourceAccumulatorInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField][Min(1)] private int _targetCount = 1;
        
        public void InstallBindings(ContainerBuilder builder) =>
            builder.RegisterValue(new ResourceAccumulator(max: _targetCount));
    }
}