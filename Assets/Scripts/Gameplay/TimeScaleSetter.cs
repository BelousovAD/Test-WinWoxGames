using UnityEngine;

namespace Gameplay
{
    internal class TimeScaleSetter : MonoBehaviour
    {
        [SerializeField][Min(0f)] private float _timeScale;
        [SerializeField] private Moment _moment;

        private enum Moment
        {
            OnEnable = 0,
            OnDisable = 1,
        }

        private void OnEnable()
        {
            if (_moment == Moment.OnEnable)
            {
                Time.timeScale = _timeScale;
            }
        }

        private void OnDisable()
        {
            if (_moment == Moment.OnDisable)
            {
                Time.timeScale = _timeScale;
            }
        }
    }
}