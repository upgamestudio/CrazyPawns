using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Gameplay.Feature.Connector.Behaviour
{
    public class ConnectorView : MonoBehaviour
    {
        public event Action<ConnectorView> OnRemoved;
        public event Action<ConnectorView> OnPositionUpdated; 
        
        [SerializeField] private Renderer renderer;
        
        private Material baseMaterial;
        private Material activeMaterial;

        public List<ConnectorView> AttachedConnectors { get; private set; }
        public Vector3 Position => transform.position;

        public void Setup(Material baseMaterial, Material activeMaterial)
        {
            this.activeMaterial = activeMaterial;
            this.baseMaterial = baseMaterial;

            AttachedConnectors = new List<ConnectorView>();
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
            OnPositionUpdated?.Invoke(this);
        }

        public void AddConnector(ConnectorView attached)
        {
            AttachedConnectors.Add(attached);
        }

        private void RemoveConnector(ConnectorView disconnected)
        {
            AttachedConnectors.Remove(disconnected);
        }

        public void Remove()
        {
            OnRemoved?.Invoke(this);

            foreach (var connector in AttachedConnectors)
            {
                connector.RemoveConnector(this);
            }
        }
    }
}