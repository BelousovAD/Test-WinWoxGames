using CharacterMovement;
using Inputs;
using Triggers;
using UnityEngine;

namespace EnemyLogic
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyInput _input;
        [SerializeField] private TargetReachMeter _targetReachMeter;
        [SerializeField] private Way _way;
        [SerializeField] private Trigger _playerTrigger;

        private void OnEnable()
        {
            _playerTrigger.StateChanged += ChangeFocus;
            _targetReachMeter.TargetReached += ChooseNextWaypoint;
            FocusOnCurrentTarget();
        }

        private void OnDisable()
        {
            _playerTrigger.StateChanged -= ChangeFocus;
            _targetReachMeter.TargetReached -= ChooseNextWaypoint;
        }

        private void ChooseNextWaypoint()
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
            _input.SetTarget(_way.Current);
        }

        private void FocusOnPlayer()
        {
            _targetReachMeter.MoveTo(_playerTrigger.Tag.transform);
            _input.SetTarget(_playerTrigger.Tag.transform);
        }
    }
}