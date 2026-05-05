using Code.Gameplay.Feature.Board.Factory;
using Code.Gameplay.Feature.Board.Service;
using Code.Gameplay.Feature.ChessPiece.Factory;
using Code.Gameplay.Feature.ChessPiece.Service;
using Code.Infrastructure.Loaders.StaticData;
using UnityEngine;

namespace CrazyPawn.Infrastructure.Initializer
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private CrazyPawnSettings settings;
        
        private void Awake()
        {
            var staticDataProvider = new StaticDataProvider();
            
            staticDataProvider.Initialize();
            
            var boardService = new BoardService(new BoardFactory(staticDataProvider));
            boardService.Create(settings.CheckerboardSize, settings.WhiteCellColor, settings.BlackCellColor);

            var chessPieceService = new ChessPieceService(boardService, new ChessFactory(staticDataProvider));
            chessPieceService.CircleGeneration(settings.InitialZoneRadius, settings.InitialPawnCount);
        }
    }
}

