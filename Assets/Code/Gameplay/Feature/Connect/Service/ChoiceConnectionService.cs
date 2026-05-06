using System;
using System.Collections.Generic;
using Code.Gameplay.Feature.Connector.Behaviour;
using Code.Gameplay.Feature.RaycastDetector.Service;
using Code.Gameplay.Input.Services;

namespace Code.Gameplay.Feature.Connect.Service
{
    public class ChoiceConnectionService
    {
        public event Action<ConnectorView> OnFirstConnectorSelected;
        public event Action<ConnectorView> OnSecondConnectorSelected;
        public event Action OnSelectDisabled;
        
        private readonly InputService inputService;
        private readonly RaycastDetectorService raycastDetector;

        private ConnectorView firstConnector;
        private List<ConnectorView> avaliableConnectors;
        
        public ChoiceConnectionService(
            InputService inputService, 
            RaycastDetectorService raycastDetector)
        {
            this.inputService = inputService;
            this.raycastDetector = raycastDetector;
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
                        OnFirstConnectorSelected?.Invoke(firstConnector);
                    }
                    else if (
                        firstConnector != connector)
                    {
                        OnSecondConnectorSelected?.Invoke(connector);
                        OnSelectDisabled?.Invoke();
                        firstConnector = null;
                    }
                }
                else
                {
                    OnSelectDisabled?.Invoke();
                    firstConnector = null;
                }
            }
        }
    }
}