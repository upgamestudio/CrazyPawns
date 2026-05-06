using System.Collections.Generic;
using Code.Gameplay.Feature.Connect.Factory;
using Code.Gameplay.Feature.Connector.Behaviour;
using Code.Gameplay.Feature.Connector.Service;

namespace Code.Gameplay.Feature.Connect.Service
{
    public class ConnectBuildService
    {
        private readonly ChoiceConnectionService choiceConnectionService;
        private readonly ConnectorService connectorService;
        private readonly ConnectFactory connectFactory;

        private ConnectorView beginConnector;
        private List<ConnectorView> avaliableConnectors;
        
        public ConnectBuildService(
            ChoiceConnectionService choiceConnectionService,
            ConnectorService connectorService,
            ConnectFactory connectFactory)
        {
            this.choiceConnectionService = choiceConnectionService;
            this.connectorService = connectorService;
            this.connectFactory = connectFactory;
        }

        public void Initialize()
        {
            choiceConnectionService.OnFirstConnectorSelected += OnFirstConnectSelect;
            choiceConnectionService.OnSecondConnectorSelected += Build;
            choiceConnectionService.OnSelectDisabled += CleanupBuilding;
        }

        private void OnFirstConnectSelect(ConnectorView connector)
        {
            beginConnector = connector;
            
            avaliableConnectors = connectorService.GetAvailableConnectors(connector);
            connectorService.EnableConnectionMode(avaliableConnectors);
        }

        private void Build(ConnectorView connecting)
        {
            if (avaliableConnectors.Contains(connecting))
            {
                connectFactory.Create(beginConnector, connecting);
            }
        }

        private void CleanupBuilding()
        {
            connectorService.DisableConnectionMode(avaliableConnectors);
            beginConnector = null;
        }

        public void Disable()
        {
            choiceConnectionService.OnFirstConnectorSelected -= OnFirstConnectSelect;
            choiceConnectionService.OnSecondConnectorSelected -= Build;
            choiceConnectionService.OnSelectDisabled -= CleanupBuilding;
        }
    }
}