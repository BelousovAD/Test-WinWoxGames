using Windows;
using Reflex.Core;
using Triggers;
using UnityEngine;

namespace Gameplay
{
    internal class GameplayInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private string _defeatWindowId;
        [SerializeField] private string _victoryWindowId;
        [SerializeField] private Trigger _enemyTrigger;
        [SerializeField] private Trigger _exitTrigger;

        private ContainerBuilder _builder;
        private Judge _judge;

        public void InstallBindings(ContainerBuilder builder)
        {
            _builder = builder;
            _judge = new Judge(_defeatWindowId, _victoryWindowId, _enemyTrigger, _exitTrigger);

            _builder.RegisterValue(_judge);

            _builder.OnContainerBuilt += Initialize;
        }

        private void Initialize(Container container)
        {
            _builder.OnContainerBuilt -= Initialize;

            _judge.Initialize(container.Resolve<IWindowService>());
        }
    }
}