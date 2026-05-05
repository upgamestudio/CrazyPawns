using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Input.Services;
using UnityEngine;

namespace Code.Gameplay.Feature.RaycastDetector.Service
{
    public class RaycastDetectorService
    {
        public GameObject DetectObject { get; private set; }
        
        private readonly CameraProvider cameraProvider;
        private readonly InputService inputService;

        private LayerMask layersToCheck = ~0;

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
                DetectObject = hit.collider.gameObject;
            }
            else
            {
                if (DetectObject)
                {
                    DetectObject = null;
                }
            }
        }
        
    }
}