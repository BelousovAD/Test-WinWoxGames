using System;
using System.Collections;
using UnityEngine;

namespace CharacterMovement
{
    public class TargetReachMeter : MonoBehaviour
    {
        [SerializeField] private float _targetRadius = 0.25f;
        [SerializeField] private Transform _transform;

        private Transform _target;
        private float _sqrTargetRadius;
        private Coroutine _moving;

        public event Action TargetReached;

        private void Awake() =>
            _sqrTargetRadius = _targetRadius * _targetRadius;

        private void OnEnable()
        {
            if (_target != null && _moving == null)
            {
                _moving = StartCoroutine(Moving());
            }
        }

        private void OnDisable()
        {
            if (_moving != null)
            {
                StopCoroutine(_moving);
                _moving = null;
            }
        }

        public void MoveTo(Transform target)
        {
            if (_moving != null)
            {
                StopCoroutine(_moving);
            }

            _target = target;

            if (_target is not null)
            {
                _moving = StartCoroutine(Moving());
            }
        }

        private IEnumerator Moving()
        {
            while (IsTargetReached() == false)
            {
                yield return null;
            }

            _target = null;
            TargetReached?.Invoke();
        }

        private bool IsTargetReached() =>
            Vector3.SqrMagnitude(_target.position - _transform.position) <= _sqrTargetRadius;
    }
}