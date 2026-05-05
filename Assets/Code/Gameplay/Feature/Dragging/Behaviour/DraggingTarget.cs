using System;
using UnityEngine;

namespace Code.Gameplay.Feature.Dragging.Behaviour
{
    public class DraggingTarget : MonoBehaviour
    {
        public event Action<Vector3> OnDragging;
        public event Action OnRemoved;
        public event Action OnBoard;
        public event Action OnBehindBoard;

        [SerializeField] private Transform target;
        
        public Vector3 Position => target.position;

        public void UpdatePosition(Vector3 draggingPosition) => OnDragging?.Invoke(draggingPosition);

        public void IsOnBoard(bool onBoard)
        {
            if(onBoard)
                OnBoard?.Invoke();
            else
                OnBehindBoard.Invoke();
        }

        public void Remove() => OnRemoved?.Invoke();
    }
}