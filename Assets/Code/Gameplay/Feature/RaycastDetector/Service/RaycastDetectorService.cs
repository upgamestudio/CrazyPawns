using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Feature.RaycastDetector.Behaviour;
using Code.Gameplay.Input.Services;
using UnityEngine;

namespace Code.Gameplay.Feature.RaycastDetector.Service
{
    public class RaycastDetectorService
    {
        private readonly LayerMask layersToCheck = ~0;
        
        private readonly CameraProvider cameraProvider;
        private readonly InputService inputService;
        
        public DetectObject Target { get; private set; }
        public RaycastHit Hit { get; private set; }

        public RaycastDetectorService(CameraProvider cameraProvider, InputService inputService)
        {
            this.cameraProvider = cameraProvider;
            this.inputService = inputService;
        }

        public void Tick()
        {
            var ray = cameraProvider.MainCamera.ScreenPointToRay(inputService.MousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layersToCheck))
            {
                if(hit.collider.gameObject.TryGetComponent<DetectObject>(out var target))
                {
                    Target = target;
                    Hit = hit;
                }
            }
            else
            {
                if (Target)
                {
                    Target = null;
                }
            }
        }
        
    }
}