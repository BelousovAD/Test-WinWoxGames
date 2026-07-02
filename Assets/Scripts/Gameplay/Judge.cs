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
        private readonly Trigger _enemyTrigger;
        private readonly Trigger _exitTrigger;
        private IWindowService _windowService;

        public Judge(string defeatWindowId, string victoryWindowId, Trigger enemyTrigger,
            Trigger exitTrigger)
        {
            _defeatWindowId = defeatWindowId;
            _victoryWindowId = victoryWindowId;
            _enemyTrigger = enemyTrigger;
            _exitTrigger = exitTrigger;

            _enemyTrigger.StateChanged += OpenDefeatWindow;
            _exitTrigger.StateChanged += OpenVictoryWindow;
        }

        public void Initialize(IWindowService windowService) =>
            _windowService = windowService;

        public void Dispose()
        {
            _enemyTrigger.StateChanged -= OpenDefeatWindow;
            _exitTrigger.StateChanged -= OpenVictoryWindow;
        }

        private void OpenDefeatWindow(bool _) =>
            _windowService.Open(_defeatWindowId, WindowCountToClose);

        private void OpenVictoryWindow(bool _) =>
            _windowService.Open(_victoryWindowId, WindowCountToClose);
    }
}