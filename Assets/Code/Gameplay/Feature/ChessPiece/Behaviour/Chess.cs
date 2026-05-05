using System;
using Code.Common.Extensions;
using Code.Gameplay.Feature.Dragging.Behaviour;
using UnityEngine;

namespace Code.Gameplay.Feature.ChessPiece.Behaviour
{
    public class Chess : MonoBehaviour
    {
        public event Action<Chess> OnRemoved;
        
        [SerializeField] private DraggingTarget draggingTarget;
        [SerializeField] private Renderer[] renderers;
        
        private Material baseMaterial;
        private Material deleteMaterial;

        private void Awake()
        {
            draggingTarget.OnDragging += Move;
            draggingTarget.OnBoard += BoardVisualization;
            draggingTarget.OnBehindBoard += BehindBoardVisualization;
            draggingTarget.OnRemoved += Remove;
        }

        public void Setup(Vector3 at, Material baseMaterial, Material deleteMaterial)
        {
            this.deleteMaterial = deleteMaterial;
            this.baseMaterial = baseMaterial;
            transform.position = at;
        }

        private void BoardVisualization()
        {
            foreach (var renderer in renderers)
            {
                renderer.material = baseMaterial;
            }
        }

        private void BehindBoardVisualization()
        {
            foreach (var renderer in renderers)
            {
                renderer.material = deleteMaterial;
            }
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