using System;
using Code.Gameplay.Feature.Dragging.Behaviour;
using UnityEngine;

namespace Code.Gameplay.Feature.ChessPiece.Behaviour
{
    public class Chess : MonoBehaviour
    {
        public event Action<Chess> OnRemoved;
        
        [SerializeField] private DraggingTarget draggingTarget;

        private void Awake()
        {
            draggingTarget.OnDragging += Move;
            draggingTarget.OnRemoved += Remove;
        }

        public void Setup(Vector3 at)
        {
            transform.position = at;
        }

        private void Move(Vector3 at)
        {
            transform.position = at;
        }

        private void OnDestroy()
        {
            draggingTarget.OnDragging -= Move;
            draggingTarget.OnRemoved -= Remove;
        }

        private void Remove()
        {
            OnRemoved?.Invoke(this);
        }
    }
}