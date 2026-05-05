using Code.Gameplay.ChessPiece.Behaviour;
using Code.Infrastructure.Loaders.StaticData;
using UnityEngine;

namespace Code.Gameplay.ChessPiece.Factory
{
    public class ChessFactory
    {
        private readonly StaticDataProvider staticDataProvider;

        public ChessFactory(StaticDataProvider staticDataProvider)
        {
            this.staticDataProvider = staticDataProvider;
        }
        
        public Chess Create(Vector3 at)
        {
            var chess = GameObject.Instantiate(staticDataProvider.GetChessTemplate());
            chess.Setup(at);
            return chess;
        }
    }
}