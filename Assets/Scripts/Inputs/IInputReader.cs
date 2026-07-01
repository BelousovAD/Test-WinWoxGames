using System;
using UnityEngine;

namespace Inputs
{
    public interface IInputReader
    {
        public event Action<Vector2> MoveRequested;
        
        public event Action<Vector2> RotateRequested;

        public event Action<bool> SprintRequested;
    }
}