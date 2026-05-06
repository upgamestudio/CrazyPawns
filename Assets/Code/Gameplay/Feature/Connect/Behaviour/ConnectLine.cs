using System;
using Code.Gameplay.Feature.Connector.Behaviour;
using UnityEngine;

namespace Code.Gameplay.Feature.Connect.Behaviour
{
    public class ConnectLine : MonoBehaviour
    {
        [SerializeField] private LineRenderer lineRenderer;
        
        private ConnectorView[] connectors;

        public void Setup(params ConnectorView[] connectors)
        {
            this.connectors = connectors;
            for (var i = 0; i < connectors.Length; i++)
            {
                var connector = connectors[i];
                
                lineRenderer.SetPosition(i, connector.Position);

                connector.OnRemoved += Destruct;
                connector.OnPositionUpdated += UpdatePosition;
            }
        }

        private void UpdatePosition(ConnectorView connector)
        {
            var index = Array.IndexOf(connectors,connector);
            lineRenderer.SetPosition(index, connector.Position);
        }

        private void Destruct(ConnectorView connectorView)
        {
            foreach (var connector in connectors)
            {
                connector.OnRemoved -= Destruct;
                connector.OnPositionUpdated -= UpdatePosition;
            }
            
            GameObject.Destroy(gameObject);
        }
    }
}