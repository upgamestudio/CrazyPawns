using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Gameplay.Feature.Board.Service;
using Code.Gameplay.Feature.ChessPiece.Behaviour;
using Code.Gameplay.Feature.ChessPiece.Factory;
using UnityEngine;

namespace Code.Gameplay.Feature.ChessPiece.Service
{
    public class ChessPieceService
    {
        private readonly BoardService boardService;
        private readonly ChessFactory chessFactory;

        private List<Chess> chesses;
        
        public ChessPieceService(BoardService boardService, ChessFactory chessFactory)
        {
            this.boardService = boardService;
            this.chessFactory = chessFactory;

            chesses = new List<Chess>();
        }

        public void CircleGeneration(float radius, int count, Material baseMaterial, Material deleteMaterial)
        {
            var points = boardService
                .GetCellInCircle(radius)
                .Shuffle();

            count = Mathf.Min(count, points.Count);
            
            for (var i = 0; i < count; i++)
            {
                var chess = chessFactory.Create(points[i], baseMaterial, deleteMaterial);
                
                chesses.Add(chess);
                chess.OnRemoved += Remove;
            }
        }

        private void Remove(Chess chess)
        {
            chess.OnRemoved -= Remove;
            chesses.Remove(chess);
            GameObject.Destroy(chess.gameObject);
        }
    }
}