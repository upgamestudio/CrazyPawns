using System;
using Code.Gameplay.Feature.Dragging.Behaviour;
using UnityEngine;

namespace Code.Gameplay.Feature.ChessPiece.Behaviour
{
    public class Chess : MonoBehaviour
    {
        [SerializeField] private DraggingTarget draggingTarget;

        private void Awake()
        {
            draggingTarget.OnGragging += Move;
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
            draggingTarget.OnGragging -= Move;
        }
    }
}