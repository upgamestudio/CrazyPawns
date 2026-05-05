using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Feature.Board.Factory;
using Code.Gameplay.Feature.Board.Service;
using Code.Gameplay.Feature.ChessPiece.Factory;
using Code.Gameplay.Feature.ChessPiece.Service;
using Code.Gameplay.Feature.Connect.Factory;
using Code.Gameplay.Feature.Connect.Service;
using Code.Gameplay.Feature.Connector.Service;
using Code.Gameplay.Feature.Dragging.Service;
using Code.Gameplay.Feature.RaycastDetector.Service;
using Code.Gameplay.Input.Services;
using Code.Infrastructure.Loaders.StaticData;
using UnityEngine;

namespace CrazyPawn.Infrastructure.Initializer
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private CrazyPawnSettings settings;
        [SerializeField] private Camera mainCamera;

        private RaycastDetectorService raycastDetectorService;
        private OnBoardDraggingService onBoardDraggingService;
        private ChoiceConnectionService choiceConnectionService;
        
        private void Awake()
        {
            var staticDataProvider = new StaticDataProvider();
            var cameraProvider = new CameraProvider();
            var inputService = new InputService();
            
            var boardService = new BoardService(new BoardFactory(staticDataProvider));
            var connectorService = new ConnectorService();
            var chessPieceService = new ChessPieceService(boardService, new ChessFactory(staticDataProvider), connectorService);
            
            raycastDetectorService = new RaycastDetectorService(cameraProvider, inputService);
            onBoardDraggingService = new OnBoardDraggingService(raycastDetectorService, cameraProvider, inputService, boardService);
            choiceConnectionService = new ChoiceConnectionService(inputService, raycastDetectorService,
                new ConnectFactory(staticDataProvider), connectorService);

            staticDataProvider.Initialize();
            cameraProvider.SetMainCamera(mainCamera);
            boardService.Create(settings.CheckerboardSize, settings.WhiteCellColor, settings.BlackCellColor);
            chessPieceService.CircleGeneration(
                settings.InitialZoneRadius,
                settings.InitialPawnCount,
                settings.BaseMaterial,
                settings.DeleteMaterial,
                settings.ActiveConnectorMaterial);
        }

        private void Update()
        {
            raycastDetectorService.Tick();
            onBoardDraggingService.Tick();
            choiceConnectionService.Tick();
        }
    }
}

