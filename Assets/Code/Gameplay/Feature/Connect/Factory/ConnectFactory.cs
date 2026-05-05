using Code.Gameplay.Feature.Connect.Behaviour;
using Code.Gameplay.Feature.Connector.Behaviour;
using Code.Infrastructure.Loaders.StaticData;
using UnityEngine;

namespace Code.Gameplay.Feature.Connect.Factory
{
    public class ConnectFactory
    {
        private readonly StaticDataProvider staticDataProvider;

        public ConnectFactory(StaticDataProvider staticDataProvider)
        {
            this.staticDataProvider = staticDataProvider;
        }
        
        public ConnectLine Create(ConnectorView firstConnector, ConnectorView secondConnector)
        {
            var line = GameObject.Instantiate(staticDataProvider.GetConnectLineTemplate());
            line.Setup(firstConnector.Position, secondConnector.Position);

            return line;
        }
    }
}