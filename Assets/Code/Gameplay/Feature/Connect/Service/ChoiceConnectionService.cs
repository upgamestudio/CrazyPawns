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
        
        public ChoiceConnectionService(
            InputService inputService, 
            RaycastDetectorService raycastDetector)
        {
            this.inputService = inputService;
            this.raycastDetector = raycastDetector;
        }
        
        public void Tick()
        {
            //TODO: небольшое пояснение :)
            //Я знаю что так делать нельзя,
            //и лучше распределить логику клика и дропа по разным сервисам, но уж очень захотелось попробовать сработает ли, сработало)
            //все таки это тестовое, хотелось чуть чуть веселья, в проде обещаю такого не творить))
            
            if(!raycastDetector.Target)
                return;

            if (!raycastDetector.Target.TryGetComponent<ConnectorView>(out var connector))
            {
                if (inputService.GetMouseButtonDown())
                {
                    OnSelectDisabled?.Invoke();
                    firstConnector = null;
                }
                
                return;
            }
            
            if (inputService.GetMouseButtonDown() && !firstConnector)
            {
                firstConnector = connector;
                OnFirstConnectorSelected?.Invoke(firstConnector);
                return;
            }
            
            if (inputService.GetMouseButtonUp() && firstConnector && firstConnector != connector)
            {
                OnSecondConnectorSelected?.Invoke(connector);
                OnSelectDisabled?.Invoke();
                firstConnector = null;
            }
        }
    }
}