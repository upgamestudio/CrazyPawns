using Code.Gameplay.Feature.ChessPiece.Behaviour;
using Code.Infrastructure.Loaders.StaticData;
using UnityEngine;

namespace Code.Gameplay.Feature.ChessPiece.Factory
{
    public class ChessFactory
    {
        private readonly StaticDataProvider staticDataProvider;

        public ChessFactory(StaticDataProvider staticDataProvider)
        {
            this.staticDataProvider = staticDataProvider;
        }
        
        public Chess Create(Vector3 at, Material baseMaterial, Material deleteMaterial)
        {
            var chess = GameObject.Instantiate(staticDataProvider.GetChessTemplate());
            chess.Setup(at, baseMaterial, deleteMaterial);
            return chess;
        }
    }
}