using System;
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
        private ConnectBuildService connectBuildService;
        private StaticDataProvider staticDataProvider;
        private CameraProvider cameraProvider;
        private BoardService boardService;
        private ChessPieceService chessPieceService;

        private void Awake()
        {
            var inputService = new InputService();
            var connectorService = new ConnectorService();

            staticDataProvider = new StaticDataProvider();
            cameraProvider = new CameraProvider();

            boardService = new BoardService(new BoardFactory(staticDataProvider));
            chessPieceService = new ChessPieceService(boardService, new ChessFactory(staticDataProvider), connectorService);
            
            raycastDetectorService = new RaycastDetectorService(cameraProvider, inputService);
            onBoardDraggingService = new OnBoardDraggingService(raycastDetectorService, cameraProvider, inputService, boardService);
            choiceConnectionService = new ChoiceConnectionService(inputService, raycastDetectorService);

            connectBuildService = new ConnectBuildService(choiceConnectionService, connectorService, new ConnectFactory(staticDataProvider));
        }

        private void Start()
        {
            staticDataProvider.Initialize();
            cameraProvider.SetMainCamera(mainCamera);
            boardService.Create(settings.CheckerboardSize, settings.WhiteCellColor, settings.BlackCellColor);
            
            chessPieceService.CircleGeneration(
                settings.InitialZoneRadius,
                settings.InitialPawnCount,
                settings.BaseMaterial,
                settings.DeleteMaterial,
                settings.ActiveConnectorMaterial);
            
            connectBuildService.Initialize();
        }

        private void Update()
        {
            raycastDetectorService.Tick();
            onBoardDraggingService.Tick();
            choiceConnectionService.Tick();
        }

        private void OnDestroy()
        {
            connectBuildService?.Disable();
        }
    }
}

