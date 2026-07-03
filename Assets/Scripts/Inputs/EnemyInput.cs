using System;
using UnityEngine;

namespace Inputs
{
    public class EnemyInput : MonoBehaviour, IInput
    {
        [SerializeField] private Transform _transform;

        private Transform _target;
        private float _sqrTargetRadius;
        private Vector2 _lastDirection = Vector2.up;

        public event Action<Vector2> MoveRequested;

        public event Action<Vector2> RotateRequested;

        public event Action<bool> SprintRequested;

        private void Start() =>
            MoveRequested?.Invoke(Vector2.up);

        private void Update()
        {
            if (_target is null)
            {
                return;
            }
            
            Vector3 direction3 = (_target.position - _transform.position).normalized;
            Vector2 direction2 = new (direction3.x, direction3.z);
            RotateRequested?.Invoke(new Vector2(Vector2.SignedAngle(direction2, _lastDirection), 0f));
            _lastDirection = direction2;
        }

        public void SetTarget(Transform target) =>
            _target = target;
    }
}
