using System.Collections.Generic;
using Code.Gameplay.Feature.Connect.Factory;
using Code.Gameplay.Feature.Connector.Behaviour;
using Code.Gameplay.Feature.Connector.Service;
using Code.Gameplay.Feature.RaycastDetector.Service;
using Code.Gameplay.Input.Services;

namespace Code.Gameplay.Feature.Connect.Service
{
    public class ChoiceConnectionService
    {
        private readonly InputService inputService;
        private readonly RaycastDetectorService raycastDetector;
        private readonly ConnectFactory connectFactory;
        private readonly ConnectorService connectorService;
        private readonly ConnectBuildService connectBuildService;

        private ConnectorView firstConnector;
        private List<ConnectorView> avaliableConnectors;
        
        public ChoiceConnectionService(
            InputService inputService, 
            RaycastDetectorService raycastDetector,
            ConnectFactory connectFactory,
            ConnectorService connectorService,
            ConnectBuildService connectBuildService)
        {
            this.inputService = inputService;
            this.raycastDetector = raycastDetector;
            this.connectFactory = connectFactory;
            this.connectorService = connectorService;
            this.connectBuildService = connectBuildService;
        }
        
        public void Tick()
        {
            if (inputService.GetMouseButtonDown() && raycastDetector.Target)
            {
                if (raycastDetector.Target.TryGetComponent<ConnectorView>(out var connector))
                {
                    if (!firstConnector)
                    {
                        firstConnector = connector;
                        avaliableConnectors = connectorService.GetAvailableConnectors(firstConnector);

                        foreach (var avaliableConnector in avaliableConnectors)
                        {
                            avaliableConnector.SelectVisual();
                        }
                    }
                    else if (
                        firstConnector != connector && 
                        avaliableConnectors != null && 
                        avaliableConnectors.Contains(connector))
                    {
                        connectFactory.Create(firstConnector, connector);
                        
                        foreach (var avaliableConnector in avaliableConnectors)
                        {
                            avaliableConnector.BaseVisual();
                        }
                        
                        avaliableConnectors = null;
                        firstConnector = null;
                    }
                }
                else
                {
                    if (avaliableConnectors != null)
                    {
                        foreach (var avaliableConnector in avaliableConnectors)
                        {
                            avaliableConnector.BaseVisual();
                        }
                    }
                        
                    firstConnector = null;
                    avaliableConnectors = null;
                }
            }
        }
    }
}