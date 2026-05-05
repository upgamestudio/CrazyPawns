using System;
using UnityEngine;

namespace Code.Gameplay.Feature.Dragging.Behaviour
{
    public class DraggingTarget : MonoBehaviour
    {
        public event Action<Vector3> OnGragging;

        [SerializeField] private Transform target;
        
        public Vector3 Position => target.position;
        public void UpdatePosition(Vector3 draggingPosition) => OnGragging?.Invoke(draggingPosition);
    }
}