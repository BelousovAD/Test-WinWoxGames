using System;
using Windows;
using Triggers;

namespace Gameplay
{
    public class Judge : IDisposable
    {
        private const int WindowCountToClose = 0;

        private readonly string _defeatWindowId;
        private readonly string _victoryWindowId;
        private readonly EnemyTrigger _enemyTrigger;
        private readonly PlayerTrigger _exitTrigger;
        private IWindowService _windowService;

        public Judge(string defeatWindowId, string victoryWindowId, EnemyTrigger enemyTrigger,
            PlayerTrigger exitTrigger)
        {
            _defeatWindowId = defeatWindowId;
            _victoryWindowId = victoryWindowId;
            _enemyTrigger = enemyTrigger;
            _exitTrigger = exitTrigger;

            _enemyTrigger.Triggered += OpenDefeatWindow;
            _exitTrigger.StateChanged += OpenVictoryWindow;
        }

        public void Initialize(IWindowService windowService) =>
            _windowService = windowService;

        public void Dispose()
        {
            _enemyTrigger.Triggered -= OpenDefeatWindow;
            _exitTrigger.StateChanged -= OpenVictoryWindow;
        }

        private void OpenDefeatWindow() =>
            _windowService.Open(_defeatWindowId, WindowCountToClose);

        private void OpenVictoryWindow(bool _) =>
            _windowService.Open(_victoryWindowId, WindowCountToClose);
    }
}