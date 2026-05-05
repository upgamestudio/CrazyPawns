using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Feature.Board.Service;
using Code.Gameplay.Feature.Dragging.Behaviour;
using Code.Gameplay.Feature.RaycastDetector.Service;
using Code.Gameplay.Input.Services;
using UnityEngine;

namespace Code.Gameplay.Feature.Dragging.Service
{
    public class OnBoardDraggingService
    {
        private readonly RaycastDetectorService raycastDetector;
        private readonly CameraProvider cameraProvider;
        private readonly InputService inputService;
        private readonly BoardService boardService;

        private DraggingTarget target;
        private Vector3 offset;

        public OnBoardDraggingService(
            RaycastDetectorService raycastDetector,
            CameraProvider cameraProvider,
            InputService inputService,
            BoardService boardService)
        {
            this.raycastDetector = raycastDetector;
            this.cameraProvider = cameraProvider;
            this.inputService = inputService;
            this.boardService = boardService;
        }
        
        public void Tick()
        {
            if (!target && inputService.GetMouseButtonDown() && raycastDetector.Target)
            {
                if (raycastDetector.Target.TryGetComponent<DraggingTarget>(out var draggingTarget))
                {
                    target = draggingTarget;
                    offset = target.Position - GetGroundHitPoint(raycastDetector.Hit.point);
                }
            }

            if (target && inputService.GetMouseButton())
            {
                UpdateDraggedPosition();
            }
            
            if (target && inputService.GetMouseButtonUp())
            {
                PositionAdjustment();
                target = null;
            }
        }

        private void PositionAdjustment()
        {
            if (boardService.IsOnBoard(target.Position))
            {
                var position = boardService
                    .ClosestCellToPoint(target.Position);
            
                target.UpdatePosition(position);
            }
            else
            {
                target.Remove();
            }
        }

        private void UpdateDraggedPosition()
        {
            var ray = cameraProvider.MainCamera.ScreenPointToRay(inputService.MousePosition);
            
            if (new Plane(Vector3.up, Vector3.zero).Raycast(ray, out var enter))
            {
                var groundPoint = ray.GetPoint(enter);
                
                groundPoint.y = 0;
            
                if (groundPoint != Vector3.negativeInfinity)
                {
                    var draggingPosition = groundPoint + offset;
                    target.UpdatePosition(draggingPosition);
                }
            }
        }
        
        private Vector3 GetGroundHitPoint(Vector3 worldPoint) => new(worldPoint.x, 0f, worldPoint.z);
    }
}