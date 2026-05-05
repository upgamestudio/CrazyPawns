using Code.Gameplay.Feature.Board.Behaviour;
using Code.Gameplay.Feature.ChessPiece.Behaviour;
using UnityEngine;

namespace Code.Infrastructure.Loaders.StaticData
{
    public class StaticDataProvider
    {
        private const string BoardCellPath = "Gameplay/BoardCell/Cell";
        private const string ChessPath = "Gameplay/Chess/Pawn";

        private Cell cellTemplate;
        private Chess chessTemplate;

        public void Initialize()
        {
            LoadCellTemplate();
            LoadChessTemplate();
        }

        public Cell GetCellTemplate() => cellTemplate;
        public Chess GetChessTemplate() => chessTemplate;

        private void LoadCellTemplate() =>
            cellTemplate = Resources
                .Load<Cell>(BoardCellPath);

        private void LoadChessTemplate() =>
            chessTemplate = Resources
                .Load<Chess>(ChessPath);
    }
}