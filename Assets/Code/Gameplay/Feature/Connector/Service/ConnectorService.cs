using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Feature.ChessPiece.Behaviour;
using Code.Gameplay.Feature.Connector.Behaviour;
using UnityEngine;

namespace Code.Gameplay.Feature.Connector.Service
{
    public class ConnectorService
    {
        private Dictionary<Chess, List<ConnectorView>> connectors;

        public ConnectorService()
        {
            connectors = new Dictionary<Chess, List<ConnectorView>>();
        }
        
        public void Registration(Chess parent, Material baseMaterial, Material activeMaterial, params ConnectorView[] connectors)
        {
            if (!this.connectors.ContainsKey(parent))
            {
                this.connectors.Add(parent, new List<ConnectorView>());
                parent.OnRemoved += OnRemoveParent;
            }

            foreach (var connector in connectors)
            {
                connector.Setup(baseMaterial, activeMaterial);
                this.connectors[parent].Add(connector);
            }
        }
        
        public List<ConnectorView> GetAvailableConnectors(ConnectorView connecting)
        {
            var result = new List<ConnectorView>();

            foreach (var connectors in connectors)
            {
                if (connectors.Value.Any(x => x == connecting))
                {
                    continue;
                }

                foreach (var connector in connectors.Value)
                {
                    if(connecting.AttachedConnectors.Contains(connector))
                        continue;
                    
                    result.Add(connector);
                }
            }
            
            return result;
        }

        public void EnableConnectionMode(List<ConnectorView> connectors)
        {
            if (connectors == null)
                return;
            
            foreach (var connector in connectors)
            {
                connector.ActivateVisual();
            }
        }
        
        public void DisableConnectionMode(List<ConnectorView> connectors)
        {
            
            if (connectors == null)
                return;
            
            foreach (var connector in connectors)
            {
                connector.BaseVisual();
            }
        }

        private void OnRemoveParent(Chess parent)
        {
            if (this.connectors.TryGetValue(parent, out var connectors))
            {
                foreach (var connector in connectors)
                {
                    connector.Remove();
                }
            }
            
            this.connectors.Remove(parent);
            parent.OnRemoved -= OnRemoveParent;
        }
    }
}