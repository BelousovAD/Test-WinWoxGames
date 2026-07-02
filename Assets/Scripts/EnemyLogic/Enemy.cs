using CharacterMovement;
using Inputs;
using Triggers;
using UnityEngine;

namespace EnemyLogic
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyInputReader _inputReader;
        [SerializeField] private TargetReachMeter _targetReachMeter;
        [SerializeField] private Way _way;
        [SerializeField] private Trigger _playerTrigger;

        private void OnEnable()
        {
            _playerTrigger.StateChanged += ChangeFocus;
            _targetReachMeter.TargetReached += ChooseNextTarget;
            FocusOnCurrentTarget();
        }

        private void OnDisable()
        {
            _playerTrigger.StateChanged -= ChangeFocus;
            _targetReachMeter.TargetReached -= ChooseNextTarget;
        }

        private void ChooseNextTarget()
        {
            _way.Next();
            FocusOnCurrentTarget();
        }

        private void ChangeFocus(bool hasPlayer)
        {
            if (hasPlayer)
            {
                FocusOnPlayer();
            }
            else
            {
                FocusOnCurrentTarget();
            }
        }

        private void FocusOnCurrentTarget()
        {
            _targetReachMeter.MoveTo(_way.Current);
            _inputReader.SetTarget(_way.Current);
        }

        private void FocusOnPlayer()
        {
            _targetReachMeter.MoveTo(_playerTrigger.Tag.transform);
            _inputReader.SetTarget(_playerTrigger.Tag.transform);
        }
    }
}