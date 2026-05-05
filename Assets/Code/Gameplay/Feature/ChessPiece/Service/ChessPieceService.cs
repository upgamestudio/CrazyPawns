using Code.Common.Extensions;
using Code.Gameplay.Feature.Board.Service;
using Code.Gameplay.Feature.ChessPiece.Factory;
using UnityEngine;

namespace Code.Gameplay.Feature.ChessPiece.Service
{
    public class ChessPieceService
    {
        private readonly BoardService boardService;
        private readonly ChessFactory chessFactory;

        public ChessPieceService(BoardService boardService, ChessFactory chessFactory)
        {
            this.boardService = boardService;
            this.chessFactory = chessFactory;
        }
        
        public void CircleGeneration(float radius, int count)
        {
            var points = boardService
                .GetCellInCircle(radius)
                .Shuffle();

            count = Mathf.Min(count, points.Count);
            
            for (var i = 0; i < count; i++)
            {
                chessFactory.Create(points[i]);
            }
        }
    }
}