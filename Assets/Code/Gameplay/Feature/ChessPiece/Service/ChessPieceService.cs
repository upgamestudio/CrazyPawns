using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Gameplay.Feature.Board.Service;
using Code.Gameplay.Feature.ChessPiece.Behaviour;
using Code.Gameplay.Feature.ChessPiece.Factory;
using Code.Gameplay.Feature.Connector.Service;
using UnityEngine;

namespace Code.Gameplay.Feature.ChessPiece.Service
{
    public class ChessPieceService
    {
        private readonly BoardService boardService;
        private readonly ChessFactory chessFactory;
        private readonly ConnectorService connectorService;

        private List<Chess> chesses;
        
        public ChessPieceService(
            BoardService boardService, 
            ChessFactory chessFactory, 
            ConnectorService connectorService)
        {
            this.boardService = boardService;
            this.chessFactory = chessFactory;
            this.connectorService = connectorService;

            chesses = new List<Chess>();
        }

        public void CircleGeneration(float radius, int count, Material baseMaterial, Material deleteMaterial, Material activeMaterial)
        {
            var points = boardService
                .GetCellInCircle(radius)
                .Shuffle();

            count = Mathf.Min(count, points.Count);
            
            for (var i = 0; i < count; i++)
            {
                var chess = chessFactory.Create(points[i], baseMaterial, deleteMaterial);
                
                chesses.Add(chess);
                connectorService.Registration(chess, baseMaterial,activeMaterial, chess.Connectors);
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