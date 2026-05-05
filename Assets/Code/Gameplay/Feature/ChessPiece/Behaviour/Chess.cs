using System;
using Code.Gameplay.Feature.Connector.Behaviour;
using Code.Gameplay.Feature.Dragging.Behaviour;
using UnityEngine;

namespace Code.Gameplay.Feature.ChessPiece.Behaviour
{
    public class Chess : MonoBehaviour
    {
        public event Action<Chess> OnRemoved;
        
        [SerializeField] private BoardDraggingTarget boardDraggingTarget;
        [SerializeField] private Renderer[] renderers;
        
        private Material baseMaterial;
        private Material deleteMaterial;
        
        [field: SerializeField] public ConnectorView[] Connectors { get; private set; }

        private void Awake()
        {
            boardDraggingTarget.OnDragging += Move;
            boardDraggingTarget.OnBoard += BoardVisualization;
            boardDraggingTarget.OnBehindBoard += BehindBoardVisualization;
            boardDraggingTarget.OnRemoved += Remove;
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
            boardDraggingTarget.OnDragging -= Move;
            boardDraggingTarget.OnRemoved -= Remove;
        }

        private void Remove()
        {
            OnRemoved?.Invoke(this);
        }
    }
}