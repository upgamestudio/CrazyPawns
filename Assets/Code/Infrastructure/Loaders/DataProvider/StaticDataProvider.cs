using Code.Gameplay.Feature.Board.Behaviour;
using Code.Gameplay.Feature.ChessPiece.Behaviour;
using Code.Gameplay.Feature.Connect.Behaviour;
using UnityEngine;

namespace Code.Infrastructure.Loaders.StaticData
{
    public class StaticDataProvider
    {
        private const string BoardCellPath = "Gameplay/BoardCell/Cell";
        private const string ChessPath = "Gameplay/Chess/Pawn";
        private const string ConnectLinePath = "Gameplay/ConnectLine/ConnectLine";

        private Cell cellTemplate;
        private Chess chessTemplate;
        private ConnectLine connectLineTemplate;

        public void Initialize()
        {
            LoadCellTemplate();
            LoadChessTemplate();
            LoadConnectLineTemplate();
        }

        public Cell GetCellTemplate() => cellTemplate;
        public Chess GetChessTemplate() => chessTemplate;
        public ConnectLine GetConnectLineTemplate() => connectLineTemplate;

        private void LoadCellTemplate() =>
            cellTemplate = Resources
                .Load<Cell>(BoardCellPath);

        private void LoadChessTemplate() =>
            chessTemplate = Resources
                .Load<Chess>(ChessPath);
        
        private void LoadConnectLineTemplate() =>
            connectLineTemplate = Resources
                .Load<ConnectLine>(ConnectLinePath);
    }
}