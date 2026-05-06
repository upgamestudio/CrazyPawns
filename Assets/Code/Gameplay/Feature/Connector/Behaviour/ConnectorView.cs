using System;
using UnityEngine;

namespace Code.Gameplay.Feature.Connector.Behaviour
{
    public class ConnectorView : MonoBehaviour
    {
        public event Action<Vector3> OnPositionUpdated; 
        
        [SerializeField] private Renderer renderer;
        
        private Material baseMaterial;
        private Material activeMaterial;

        public Vector3 Position => transform.position;

        public void Setup(Material baseMaterial, Material activeMaterial)
        {
            this.activeMaterial = activeMaterial;
            this.baseMaterial = baseMaterial;
        }

        public void ActivateVisual()
        {
            renderer.material = activeMaterial;
        }

        public void BaseVisual()
        {
            renderer.material = baseMaterial;
        }

        public void UpdateConnectPosition()
        {
            OnPositionUpdated?.Invoke(Position);
        }
    }
}