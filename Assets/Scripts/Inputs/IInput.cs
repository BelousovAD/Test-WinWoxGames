using System;
using UnityEngine;

namespace Inputs
{
    public interface IInput
    {
        public event Action<Vector2> MoveRequested;
        
        public event Action<Vector2> RotateRequested;

        public event Action<bool> SprintRequested;
    }
}