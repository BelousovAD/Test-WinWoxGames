using System;
using PlayerLogic;
using UnityEngine;

namespace EnemyMovement
{
    [RequireComponent(typeof(Collider))]
    public class PlayerTrigger : MonoBehaviour
    {
        private Player _player;

        public event Action<bool> StateChanged;
        
        public Player Player => _player;

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.TryGetComponent(out _player))
            {
                StateChanged?.Invoke(true);
            }
        }

        private void OnTriggerExit(Collider collision)
        {
            if (collision.TryGetComponent(out _player))
            {
                StateChanged?.Invoke(false);
            }
        }
    }
}
