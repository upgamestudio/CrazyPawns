using Code.Gameplay.Feature.Connector.Behaviour;
using UnityEngine;

namespace Code.Gameplay.Feature.Connect.Behaviour
{
    public class ConnectLine : MonoBehaviour
    {
        [SerializeField] private LineRenderer lineRenderer;
        
        public void Setup(params ConnectorView[] connectors)
        {
            for (var i = 0; i < connectors.Length; i++)
            {
                var connector = connectors[i];
                
                lineRenderer.SetPosition(i, connector.Position);
                var index = i;
                
                connector.OnPositionUpdated += (position) =>
                {
                    lineRenderer.SetPosition(index, position);
                };
            }
        }
    }
}