using Code.Common.Extensions;
using Code.Gameplay.Board.Service;
using Code.Gameplay.ChessPiece.Factory;
using UnityEngine;

namespace Code.Gameplay.ChessPiece.Service
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
            var points = boardService.GetCellInCircle(radius);
            points.Shuffle();

            count = Mathf.Min(count, points.Count);
            
            for (int i = 0; i < count; i++)
            {
                chessFactory.Create(points[i]);
            }
        }
    }
}